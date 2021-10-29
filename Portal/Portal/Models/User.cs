//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Portal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Marks = new HashSet<Mark>();
            this.Notices = new HashSet<Notice>();
            this.Requests = new HashSet<Request>();
        }
    
        public int userid { get; set; }
        public string uid { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string department { get; set; }
        public string cgpa { get; set; }
        public string password { get; set; }
        public string type { get; set; }
        public int courseid { get; set; }
    
        public virtual Cours Cours { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
        public virtual ICollection<Notice> Notices { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
