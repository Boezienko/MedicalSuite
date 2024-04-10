using System.ComponentModel.DataAnnotations;

namespace MedicalSuiteWeb.Model
{
    public class InventoryItem
    {
        public int InventoryItemId { get; set; }
        [Required]
        [Display(Name = "Item Code")]
        public string InventoryItemCode { get; set; }
        [Display(Name = "Item Name")]
        public string InventoryItemName { get; set; }
        [Display(Name = "Description")]
        public string InventoryItemDescription { get; set;}
        [Display(Name = "Price")]
        public decimal InventoryItemPrice { get; set; }
        [Display(Name = "Category")]
        public int CategoryId {  get; set; }
    }
}
