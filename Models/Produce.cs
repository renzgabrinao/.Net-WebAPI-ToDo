using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Produce
    {
        [Key]
        public int ProduceID { get; set; }
        public string Description { get; set; }

        // Navigation properties.
        // Child.
        [JsonIgnore]
        public virtual ICollection<ProduceSupplier>? ProduceSuppliers { get; set; }
    }
}
