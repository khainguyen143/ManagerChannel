using API.Constants;
using API.Exceptions;
using API.Models;
using API.Models.Authorization;
using API.Models.Notifications;
using API.Models.Support;
using ManagerChannel.Models.Channels;
using ManagerChannel.Models.ManagementProject;
using ManagerChannel.Models.Networks;
using ManagerChannel.Models.Pay;
using ManagerChannel.Models.ProjectGoogleApies;
using ManagerChannel.Models.Regulations;
using ManagerChannel.Models.Teams;
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

        public DbSet<Team> Teams { get; set; } 
        public DbSet<RolePermissionInTeam> RolePermissionInTeams { get; set; }
        public DbSet<UserRoleInTeam> UserRoleInTeams { get; set; }
        public DbSet<RoleInTeam> RoleInTeams { get; set; }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Project_UserRoleInTeam> ProjectUserRoleInTeams { get; set;}

        public DbSet<NetWork> NetWorks { get; set; }
        public DbSet<Network_UserRoleInTeam> Network_UserRoleIns { get; set; }
        public DbSet<Network_PaymentAccount> Network_PaymentAccount { get; set;}

        public DbSet<PaymentAccount> PaymentAccounts { get; set; }
        
        public DbSet<YoutubeChannel> YoutubeChannels { get; set; }
        public DbSet<UserRole_YoutubeChannel> UserRole_YoutubeChannels { get; set; }
        public DbSet<ReportDataChannelDaily> ReportDataChannelDailies { get; set; }

        public DbSet<Video> Videos { get; set; }
        public DbSet<ReportDataVideoDaily> ReportDataVideoDaily { get; set;}
        public DbSet<ProjectGoogleApi> ProjectGoogleApis { get; set; }

        public DbSet<Regulation> Regulations { get; set; }
        public DbSet<Project_Regulation> Project_Regulations { get; set;}
        public DbSet<Network_Regulation> Network_Regulations { get; set; }
        public DbSet<Team_Regulation> Team_Regulations { get; set; }


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
            builder.Entity<UserRestriction>().HasOne(entity => entity.DeletedByUser).WithMany();

            builder.Entity<UserRoleInTeam>().HasOne(entity => entity.User).WithMany(entity => entity.UserRoleInTeams);
            builder.Entity<UserRoleInTeam>().HasOne(entity => entity.Role).WithMany(entity => entity.UserRoles);
            builder.Entity<UserRoleInTeam>().HasOne(entity => entity.Team).WithMany(entity => entity.UserRolesInTeam);
            builder.Entity<UserRoleInTeam>().HasMany(entity => entity.ProjectRoles).WithOne(entity => entity.UserRoleInTeam);
            builder.Entity<UserRoleInTeam>().HasMany(entity => entity.NetWorkRoles).WithOne(entity => entity.UserRoleInTeam);
            builder.Entity<UserRoleInTeam>().HasMany(entity => entity.UserRole_YoutubeChannels).WithOne(entity => entity.UserRoleInTeam);
            builder.Entity<UserRoleInTeam>().HasOne(entity => entity.CreatedByUser).WithMany();
            builder.Entity<UserRoleInTeam>().HasOne(entity => entity.UpdatedByUser).WithMany();
            builder.Entity<UserRoleInTeam>().HasOne(entity => entity.DeletedByUser).WithMany();

            builder.Entity<RoleInTeam>().HasMany(entity => entity.RolePermissions).WithOne(entity => entity.Role);
            builder.Entity<RoleInTeam>().HasOne(entity => entity.CreatedByUser).WithMany();
            builder.Entity<RoleInTeam>().HasOne(entity => entity.UpdatedByUser).WithMany();
            builder.Entity<RoleInTeam>().HasOne(entity => entity.DeletedByUser).WithMany();

            builder.Entity<RolePermissionInTeam>().HasOne(entity => entity.Role).WithMany(entity => entity.RolePermissions);
            builder.Entity<RolePermissionInTeam>().HasOne(entity => entity.CreatedByUser).WithMany();
            builder.Entity<RolePermissionInTeam>().HasOne(entity => entity.UpdatedByUser).WithMany();
            builder.Entity<RolePermissionInTeam>().HasOne(entity => entity.DeletedByUser).WithMany();

            builder.Entity<Team>()
                .HasMany(entity => entity.SubTeams)
                .WithOne(entity => entity.ParentTeam)
                .HasForeignKey(entity => entity.ParentTeamId);
            builder.Entity<Team>().HasMany(entity => entity.UserRolesInTeam).WithOne(entity => entity.Team);
            builder.Entity<Team>().HasOne(entity => entity.CreatedByUser).WithMany();
            builder.Entity<Team>().HasOne(entity => entity.UpdatedByUser).WithMany();
            builder.Entity<Team>().HasOne(entity => entity.DeletedByUser).WithMany();

            builder.Entity<Project>().HasMany(entity => entity.Project_UserRoleInTeams).WithOne(entity => entity.Project);
            builder.Entity<Project>().HasOne(entity => entity.CreatedByUser).WithMany();
            builder.Entity<Project>().HasOne(entity => entity.UpdatedByUser).WithMany();
            builder.Entity<Project>().HasOne(entity => entity.DeletedByUser).WithMany();

            builder.Entity<Project_UserRoleInTeam>().HasKey( entity => new { entity.ProjectId, entity.UserRoleInTeamId});
            builder.Entity<Project_UserRoleInTeam>()
                .HasOne(entity => entity.UserRoleInTeam)
                .WithMany(entity => entity.ProjectRoles)
                .HasForeignKey(entity => entity.UserRoleInTeamId);
            builder.Entity<Project_UserRoleInTeam>()
                .HasOne(entity => entity.Project)
                .WithMany(entity => entity.Project_UserRoleInTeams)
                .HasForeignKey(entity => entity.ProjectId);

            builder.Entity<NetWork>().HasMany(entity => entity.Network_PaymentAccounts).WithOne(entity => entity.NetWork);
            builder.Entity<NetWork>().HasOne(entity => entity.CreatedByUser).WithMany();
            builder.Entity<NetWork>().HasOne(entity => entity.UpdatedByUser).WithMany();

            builder.Entity<PaymentAccount>().HasMany(entity => entity.Network_PaymentAccounts);
            builder.Entity<PaymentAccount>().HasOne(entity => entity.CreatedByUser).WithMany();
            builder.Entity<PaymentAccount>().HasOne(entity => entity.UpdatedByUser).WithMany();
            builder.Entity<PaymentAccount>().HasOne(entity => entity.DeletedByUser).WithMany();

            builder.Entity<Network_PaymentAccount>().HasOne(entity => entity.NetWork).WithMany(entity => entity.Network_PaymentAccounts);
            builder.Entity<Network_PaymentAccount>().HasOne(entity => entity.PaymentAccount).WithMany(entity => entity.Network_PaymentAccounts);
            builder.Entity<Network_PaymentAccount>().HasOne(entity => entity.CreatedByUser).WithMany();
            builder.Entity<Network_PaymentAccount>().HasOne(entity => entity.UpdatedByUser).WithMany();
            builder.Entity<Network_PaymentAccount>().HasOne(entity => entity.DeletedByUser).WithMany();

            builder.Entity<Network_UserRoleInTeam>().HasKey(entity => new { entity.UserRoleInTeamId, entity.Network_PaymentAccountId });
            builder.Entity<Network_UserRoleInTeam>()
                .HasOne(entity => entity.UserRoleInTeam)
                .WithMany(entity => entity.NetWorkRoles)
                .HasForeignKey(entity => entity.UserRoleInTeamId);
            builder.Entity<Network_UserRoleInTeam>()
                .HasOne(entity => entity.Network_PaymentAccount)
                .WithMany(entity => entity.Network_UserRoleInTeams)
                .HasForeignKey(entity => entity.Network_PaymentAccountId);

            builder.Entity<YoutubeChannel>().HasKey(entity => entity.ChannelId);
            builder.Entity<YoutubeChannel>().HasOne(entity => entity.NetWork).WithMany();
            builder.Entity<YoutubeChannel>().HasOne(entity => entity.CreatedByUser).WithMany();
            builder.Entity<YoutubeChannel>().HasOne(entity => entity.UpdatedByUser).WithMany();
            builder.Entity<YoutubeChannel>().HasOne(entity => entity.DeletedByUser).WithMany();
            builder.Entity<YoutubeChannel>().HasMany(entity => entity.NetWorkHistories).WithOne(entity => entity.YoutubeChannel);
            builder.Entity<YoutubeChannel>().HasMany(entity => entity.UserRole_YoutubeChannels).WithOne(entity => entity.YoutubeChannel);
            builder.Entity<YoutubeChannel>().HasMany(entity => entity.ReportDataChannelDailies).WithOne(entity => entity.YoutubeChannel);
            builder.Entity<YoutubeChannel>().HasMany(entity => entity.UserChannelHistories).WithOne(entity => entity.YoutubeChannel);
            builder.Entity<YoutubeChannel>()
                .HasOne(entity => entity.ProjectGoogleApi)
                .WithMany(entity => entity.YoutubeChannels)
                .HasForeignKey(entity => entity.ProjectGoogleApiId);

            builder.Entity<ReportDataChannelDaily>()
                .HasOne(entity => entity.YoutubeChannel)
                .WithMany(entity => entity.ReportDataChannelDailies)
                .HasForeignKey(entity => entity.ChannelId);

            builder.Entity<UserRole_YoutubeChannel>().HasKey(entity => new { entity.UserRoleInTeamId, entity.ChannelId });
            builder.Entity<UserRole_YoutubeChannel>()
                .HasOne(entity => entity.UserRoleInTeam)
                .WithMany(entity => entity.UserRole_YoutubeChannels)
                .HasForeignKey(entity => entity.UserRoleInTeamId);
            builder.Entity<UserRole_YoutubeChannel>()
                .HasOne(entity => entity.YoutubeChannel)
                .WithMany(entity => entity.UserRole_YoutubeChannels)
                .HasForeignKey(entity => entity.ChannelId);

            builder.Entity<Video>()
                .HasOne(entity => entity.Channel)
                .WithMany(entity => entity.Videos)
                .HasForeignKey(entity => entity.ChannelId);
            builder.Entity<Video>().HasMany(entity => entity.ReportDataVideoDailies).WithOne(entity => entity.Video);
            builder.Entity<Video>().HasOne(entity => entity.CreatedByUser).WithMany();
            builder.Entity<Video>().HasOne(entity => entity.UpdatedByUser).WithMany();
            builder.Entity<Video>().HasOne(entity => entity.DeletedByUser).WithMany();

            builder.Entity<ReportDataVideoDaily>()
                .HasOne(entity => entity.Video)
                .WithMany(entity => entity.ReportDataVideoDailies)
                .HasForeignKey(entity => entity.VideoId);

            builder.Entity<User_YoutubeChannelHistory>().HasOne(entity => entity.YoutubeChannel).WithMany(entity => entity.UserChannelHistories);
            builder.Entity<User_YoutubeChannelHistory>().HasOne(entity => entity.User).WithMany(entity => entity.User_YoutubeChannelHistories);

            builder.Entity<Regulation>().HasMany(entity => entity.Project_Regulations).WithOne(entity => entity.Regulation);
            builder.Entity<Regulation>().HasMany(entity => entity.Network_Regulations).WithOne(entity => entity.Regulation);
            builder.Entity<Regulation>().HasMany(entity => entity.Team_Regulations).WithOne(entity => entity.Regulation);
            builder.Entity<Regulation>().HasOne(entity => entity.CreatedByUser).WithMany();
            builder.Entity<Regulation>().HasOne(entity => entity.UpdatedByUser).WithMany();
            builder.Entity<Regulation>().HasOne(entity => entity.DeletedByUser).WithMany();

            builder.Entity<Project_Regulation>().HasKey(entity => new { entity.RegulationId, entity.ProjectId });
            builder.Entity<Project_Regulation>()
                .HasOne(entity => entity.Regulation)
                .WithMany(entity => entity.Project_Regulations)
                .HasForeignKey(entity => entity.RegulationId);
            builder.Entity<Project_Regulation>()
                .HasOne(entity => entity.Project)
                .WithMany(entity => entity.Project_Regulations)
                .HasForeignKey(entity => entity.ProjectId);

            builder.Entity<Network_Regulation>().HasKey(entity => new { entity.RegulationId, entity.NetworkId });
            builder.Entity<Network_Regulation>()
                .HasOne(entity => entity.Regulation)
                .WithMany(entity => entity.Network_Regulations)
                .HasForeignKey(entity => entity.RegulationId);
            builder.Entity<Network_Regulation>()
                .HasOne(entity => entity.NetWork)
                .WithMany(entity => entity.Network_Regulations)
                .HasForeignKey(entity => entity.NetworkId);

            builder.Entity<Team_Regulation>().HasKey(entity => new { entity.RegulationId, entity.TeamId });
            builder.Entity<Team_Regulation>()
                .HasOne(entity => entity.Regulation)
                .WithMany(entity => entity.Team_Regulations)
                .HasForeignKey(entity => entity.RegulationId);
            builder.Entity<Team_Regulation>()
                .HasOne(entity => entity.Team)
                .WithMany(entity => entity.Team_Regulations)
                .HasForeignKey(entity => entity.TeamId);
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
