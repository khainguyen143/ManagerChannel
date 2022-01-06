using API.Constants;
using API.Exceptions;
using API.Models;
using API.Models.Authorization;
using API.Models.Notifications;
using API.Models.Support;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public string UserId { get; set; }


        /*-------------------------------------------------------AUTHORIZATION-----------------------------------------------------*/
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<RolePermission> RolePermission { get; set; }
        public DbSet<UserRestriction> UserRestriction { get; set; }


        /*-------------------------------------------------------NOTIFICATION-----------------------------------------------------*/
        public DbSet<SendingEmailJob> SedingEmailJob { get; set; }
        public DbSet<Notification> Notification { get; set; }

        public DbSet<Tutorial> Tutorials { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ConfigRelationship(builder);
            ConfigDefaultValue(builder);
            ConfigGlobalFilter(builder);
            ConfigConversion(builder);
            SeedData(builder);
        }

        private void SeedData(ModelBuilder builder)
        {
            /*-------------------------------------------------------AUTHORIZATION-----------------------------------------------------*/
            builder.Entity<User>().HasData(new List<User>()
            {
                // application_admin
                new User { Id = AuthConst.ApplicationAdminUserId , CreatedDate = DateTime.Now, UserName = AuthConst.ApplicationAdminUserName}
            });

            builder.Entity<Role>().HasData(new List<Role>()
            {
                new Role { Id = AuthConst.ApplicationAdminRoleId , CreatedDate = DateTime.Now, CreatedByUserId = AuthConst.ApplicationAdminUserId, Name = AuthConst.ApplicationAdminRoleName},
                new Role { Id = AuthConst.ApplicationUserRoleId , CreatedDate = DateTime.Now, CreatedByUserId = AuthConst.ApplicationAdminUserId, Name = AuthConst.ApplicationUserRoleName}
            });

            builder.Entity<UserRole>().HasData(new List<UserRole>
            {
                // admin - application_admin
                new UserRole { CreatedDate = DateTime.Now, UserId = AuthConst.ApplicationAdminUserId, RoleId = AuthConst.ApplicationAdminRoleId}
            });

            builder.Entity<RolePermission>().HasData(new List<RolePermission>
            {
                // application_admin
                new RolePermission { Id = Guid.NewGuid().ToString(), CreatedDate = DateTime.Now, CreatedByUserId = AuthConst.ApplicationAdminUserId, RoleId = AuthConst.ApplicationAdminRoleId, Permission = Permission.Access_Application},
                new RolePermission { Id = Guid.NewGuid().ToString(), CreatedDate = DateTime.Now, CreatedByUserId = AuthConst.ApplicationAdminUserId, RoleId = AuthConst.ApplicationAdminRoleId, Permission = Permission.Authorize_User},
                new RolePermission { Id = Guid.NewGuid().ToString(), CreatedDate = DateTime.Now, CreatedByUserId = AuthConst.ApplicationAdminUserId, RoleId = AuthConst.ApplicationAdminRoleId, Permission = Permission.Manage_Notification},
                new RolePermission { Id = Guid.NewGuid().ToString(), CreatedDate = DateTime.Now, CreatedByUserId = AuthConst.ApplicationAdminUserId, RoleId = AuthConst.ApplicationAdminRoleId, Permission = Permission.Manage_Service},

                // application_user
                new RolePermission { Id = Guid.NewGuid().ToString(), CreatedDate = DateTime.Now, CreatedByUserId = AuthConst.ApplicationAdminUserId, RoleId = AuthConst.ApplicationUserRoleId, Permission = Permission.Access_Application},
            });
        }

        private void ConfigRelationship(ModelBuilder builder)
        {
            builder.Entity<UserRole>().HasKey(entity => new { entity.UserId, entity.RoleId });
            builder.Entity<UserRole>()
                .HasOne(entity => entity.User)
                .WithMany(entity => entity.UserRoles)
                .HasForeignKey(entity => entity.UserId);
            builder.Entity<UserRole>()
                .HasOne(entity => entity.Role)
                .WithMany(entity => entity.UserRoles)
                .HasForeignKey(entity => entity.RoleId);

            builder.Entity<UserRestriction>().HasOne(entity => entity.User).WithMany(entity => entity.UserRestrictions);
            builder.Entity<UserRestriction>().HasOne(entity => entity.CreatedByUser).WithMany();
            builder.Entity<UserRestriction>().HasOne(entity => entity.UpdatedByUser).WithMany();

        }

        private void ConfigDefaultValue(ModelBuilder builder)
        {
            builder.Entity<UserRole>().Property(entity => entity.CreatedDate).HasDefaultValueSql("getdate()");
        }

        private void ConfigConversion(ModelBuilder builder)
        {
            /*builder.Entity<Resource>().Property(entity => entity.DownloadSourceUrls)
                .HasConversion(
                    urls => JsonConvert.SerializeObject(urls),
                    urls => JsonConvert.DeserializeObject<List<string>>(urls));*/
        }

        private void ConfigGlobalFilter(ModelBuilder builder)
        {
            /*-------------------------------------------------------AUTHORIZATION-----------------------------------------------------*/
            builder.Entity<User>().HasQueryFilter(e => !e.IsDeleted);
            builder.Entity<Role>().HasQueryFilter(e => !e.IsDeleted);
            builder.Entity<RolePermission>().HasQueryFilter(e => !e.IsDeleted);
            builder.Entity<UserRestriction>().HasQueryFilter(e => !e.IsDeleted);

            builder.Entity<SendingEmailJob>().HasQueryFilter(e => !e.IsDeleted);
            builder.Entity<Notification>().HasQueryFilter(e => !e.IsDeleted);

            builder.Entity<Tutorial>().HasQueryFilter(e => !e.IsDeleted);
            //builder.Entity<Resource_Editing>().HasQueryFilter(e => !e.IsDeleted);
        }

        public override int SaveChanges()
        {
            HandleChangedEntries();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            HandleChangedEntries();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void HandleChangedEntries()
        {
            // check locked entity but change/delete
            var anyLockedEntriesButDeleted = ChangeTracker.Entries()
                .Any(e => e.Entity is ILockableModel && ((ILockableModel)e.Entity).IsLocked && e.State == EntityState.Deleted);
            if (anyLockedEntriesButDeleted)
            {
                throw new ModifyLockedEntityException();
            }

            var LockedEntriesButModified = ChangeTracker.Entries()
                .Where(e => e.Entity is ILockableModel && ((ILockableModel)e.Entity).IsLocked && e.State == EntityState.Modified);
            foreach (var entry in LockedEntriesButModified)
            {
                /*
                 * Nếu thực hiện thao tác unlock entity: IsLocked == false => không vấn đề gì
                 * Nếu thực hiện thao tác lock: IsLocked == true => sẽ k đc edit => lỗi =>
                 * Cần xử lý để phân biệt với entitiy bị lock nhưng thay đổi các thuộc tính khác.
                 * Giải pháp: xem giá trị IsLocked trước, nếu là true thì tức đã bị lock trước rồi nhưng đang cố modify => không cho
                 */
                if (entry.OriginalValues.GetValue<bool>("IsLocked") == true)
                {
                    throw new ModifyLockedEntityException();
                }
            }

            var AddedEntries = ChangeTracker.Entries().Where(e => e.Entity is BaseModel && (e.State == EntityState.Added));
            foreach (var entry in AddedEntries)
            {
                ((BaseModel)entry.Entity).CreatedDate = DateTime.Now;
                if(entry.Entity is ILoggableUserActionModel)
                {
                    ((ILoggableUserActionModel)entry.Entity).CreatedByUserId = UserId;
                }
            }

            var updatedEntries = ChangeTracker.Entries().Where(e => e.Entity is BaseModel && (e.State == EntityState.Modified));
            foreach (var entry in updatedEntries)
            {
                ((BaseModel)entry.Entity).UpdatedDate = DateTime.Now;
                if(entry.Entity is ILoggableUserActionModel)
                {
                    ((ILoggableUserActionModel)entry.Entity).UpdatedByUserId = UserId;
                }
            }

            var deletedEntries = ChangeTracker.Entries().Where(e => e.Entity is ISoftDeletableModel && (e.State == EntityState.Deleted));
            foreach (var entry in deletedEntries)
            {
                HandleDeleteEntity(entry);
                // RecursiveSoftDeleteDependentEntity(entry);
            }
        }

        //private void RecursiveSoftDeleteDependentEntity(EntityEntry entry)
        //{
        //    if(entry.Navigations == null || entry.Navigations.Count() == 0)
        //    {
        //        return;
        //    }

        //    foreach (var navigationEntries in entry.Navigations.Where(n => !n.Metadata.IsDependentToPrincipal()))
        //    {
        //        navigationEntries.Load();

        //        if (navigationEntries is CollectionEntry dependentEntities)
        //        {
        //            foreach (var dependentEntity in dependentEntities.CurrentValue)
        //            {
        //                if(dependentEntity is BaseModel)
        //                {
        //                    var dependentEntry = Entry(dependentEntity);
        //                    HandleDeleteEntity(dependentEntry);
        //                    RecursiveSoftDeleteDependentEntity(dependentEntry);
        //                }
        //                else
        //                {
        //                    break;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            var dependentEntity = navigationEntries.CurrentValue;
        //            if (dependentEntity != null)
        //            {
        //                var dependentEntry = Entry(dependentEntity);
        //                HandleDeleteEntity(dependentEntry);
        //                RecursiveSoftDeleteDependentEntity(dependentEntry);
        //            }
        //        }
        //    }
        //}

        private void HandleDeleteEntity(EntityEntry entry)
        {
            if(entry.Entity is ISoftDeletableModel)
            {
                entry.State = EntityState.Modified;
                ((ISoftDeletableModel)entry.Entity).DeletedDate = DateTime.Now;
                ((ISoftDeletableModel)entry.Entity).IsDeleted = true;

                if(entry.Entity is ILoggableUserActionModel)
                {
                    ((ILoggableUserActionModel)entry.Entity).DeletedByUserId = UserId;
                }
            }
            else
            {
                entry.State = EntityState.Deleted;
            }
        }
    }
}
