using System.Runtime.Serialization;

namespace KingfisherIT.Service.Models
{
    [DataContract]
    public class Activity
    {
        [DataMember(Name = "activity_id")]
        public int Id { get; set; }


        [DataMember(Name = "created_at")]
        public string CreatedAt { get; set; }


        [DataMember(Name = "updated_at")]
        public string UpdatedAt { get; set; }


        [DataMember(Name = "name")]
        public string Name { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }
}