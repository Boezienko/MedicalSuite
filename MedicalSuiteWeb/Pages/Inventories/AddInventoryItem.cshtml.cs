using MedicalSuiteWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedicalSuiteWeb.Pages.Inventories
{
    [BindProperties]
    public class AddInventoryItemModel : PageModel
    {
        public InventoryItem newInventoryItem { get; set; } = new InventoryItem();

        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        public void OnGet()
        {
        }
    }
}
