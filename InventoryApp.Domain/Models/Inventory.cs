using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Domain.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required] 
        public string Category { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Value must be non-negative.")]

        public int OriginalStock {  get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Value must be non-negative.")]

        public int Stock { get; set; }

        [Required] 
        public DateTime LastUpdatedDate {  get; set; }
    }
}
