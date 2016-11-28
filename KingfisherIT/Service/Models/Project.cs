using System.Collections.Generic;
using System.Runtime.Serialization;

namespace KingfisherIT.Service.Models
{
    [DataContract]
    public class Pivot
    {
        [DataMember(Name = "user_id")]
        public string UserId { get; set; }


        [DataMember(Name = "project_id")]
        public string ProjectId { get; set; }
    }

    [DataContract]
    public class Task
    {
        [DataMember(Name = "task_id")]
        public int Id { get; set; }


        [DataMember(Name = "created_at")]
        public string CreatedAt { get; set; }


        [DataMember(Name = "updated_at")]
        public string UpdatedAt { get; set; }


        [DataMember(Name = "project_id")]
        public string ProjectId { get; set; }


        [DataMember(Name = "name")]
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    [DataContract]
    public class Project
    {
        [DataMember(Name = "project_id")]
        public int Id { get; set; }


        [DataMember(Name = "created_at")]
        public string CreatedAt { get; set; }


        [DataMember(Name = "updated_at")]
        public string UpdatedAt { get; set; }


        [DataMember(Name = "name")]
        public string Name { get; set; }


        [DataMember(Name = "status")]
        public string Status { get; set; }


        [DataMember(Name = "manager_user_id")]
        public string ManagerUserId { get; set; }


        [DataMember(Name = "customer_id")]
        public string CustomerId { get; set; }


        [DataMember(Name = "pivot")]
        public Pivot Pivot { get; set; }


        [DataMember(Name = "tasks")]
        public List<Task> Tasks { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}