using System.Text.Json.Serialization;

namespace WebAPITask_1.Data.Models
{
    public class StudentCreate
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("SurName")]
        public string SurName { get; set; }

        [JsonPropertyName("Patronymic")]
        public string Patronymic { get; set; }

        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [JsonPropertyName("GroupId")]
        public string GroupId { get; set; }

        [JsonPropertyName("GroupName")]
        public string GroupName { get; set; }
    }
}
