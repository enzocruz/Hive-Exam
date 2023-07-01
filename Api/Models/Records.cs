
using System.ComponentModel.DataAnnotations;
namespace Api.Models
{
    public class Record
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Company { get; set; }

        public string Project { get; set; }

        public string Role { get; set; }

    }
}