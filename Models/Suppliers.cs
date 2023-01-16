using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }

        // Navigation properties.
        // Child.
        [JsonIgnore]
        public virtual ICollection<ProduceSupplier>? ProduceSuppliers { get; set; }
    }
}
