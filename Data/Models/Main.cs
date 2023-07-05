using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WebAPITask_1.Data.Models
{
    //[DataContract]
    public class Main
    {
        [JsonPropertyName("Id")]
        public Guid Id { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
    }
}
