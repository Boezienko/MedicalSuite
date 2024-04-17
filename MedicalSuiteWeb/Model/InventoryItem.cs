using System.ComponentModel.DataAnnotations;

namespace MedicalSuiteWeb.Model
{
    public class InventoryItem
    {
        public int InventoryItemId { get; set; }
        [Required]
        [Display(Name = "Item Code")]
        public string InventoryItemCode { get; set; }
        [Required]
        [Display(Name = "Item Name")]
        public string InventoryItemName { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string InventoryItemDescription { get; set;}
        [Required]
        [Display(Name = "Price")]
        public decimal InventoryItemPrice { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int CategoryId {  get; set; }
    }
}
