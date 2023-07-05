using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WebAPITask_1.Data.Models
{
    public class Student : Main
    {
        [JsonPropertyName("SurName")]
        public string SurName { get; set; }
        [JsonPropertyName("Patronymic")]
        public string Patronymic { get; set; }
        [JsonPropertyName("Email")]
        public string Email { get; set; }
        [JsonPropertyName("GroupId")]
        public Guid GroupId { get; set; }
        //[DataMember]
        public virtual Group Group { get; set; } 

    }
    public class GroupStudent : Student
    {
        public override Group Group { get => base.Group; set => base.Group = value; }
    }
}
