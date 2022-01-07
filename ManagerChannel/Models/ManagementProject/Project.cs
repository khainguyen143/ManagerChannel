﻿using API.Models;
using API.Models.Authorization;
using System;
using System.Collections.Generic;

namespace ManagerChannel.Models.ManagementProject
{
    public class Project : BaseModel, ISoftDeletableModel, ILoggableUserActionModel
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public DateTime StartDate { get; set; }
        public List<ProjectRegulation>  ProjectRegulations { get; set; }

        //------------------------------------------
        public string CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
        public string UpdatedByUserId { get; set; }
        public User UpdatedByUser { get; set; }
        public string DeletedByUserId { get; set; }
        public User DeletedByUser { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}