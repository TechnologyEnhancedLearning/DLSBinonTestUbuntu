﻿using System;

namespace DigitalLearningSolutions.Data.Models.Supervisor
{
    public class SupervisorDelegate
    {
        public int ID { get; set; }
        public string SupervisorEmail { get; set; }
        public string SupervisorName { get; set; }
        public int? SupervisorAdminID { get; set; }
        public int CentreId { get; set; }
        public string DelegateEmail { get; set; }
        public int? DelegateUserID { get; set; }
        public DateTime Added { get; set; }
        public bool AddedByDelegate { get; set; }
        public DateTime NotificationSent { get; set; }
        public DateTime? Removed { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
