using MedicalSuiteBusiness;
using MedicalSuiteWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace MedicalSuiteWeb.Pages.Inventories
{
    [BindProperties]
    public class AddInventoryItemModel : PageModel
    {
        public InventoryItem newInventoryItem { get; set; } = new InventoryItem();

        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        public void OnGet()
        {
            PopulateCategoryDDL();
        }
        public void OnPost()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                //string cmdText = "INSERT INTO Inventory(Id, InventoryItemCode, InventoryItemName, InventoryItemDescription, InventoryItemPrice, CategoryId) " +
                //    "VALUES (@itemId, doctorsOfficeId, @itemName, @itemDescription, "
            }
        }

        private void PopulateCategoryDDL()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT CategoryId, CategoryName FROM Category";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        var category = new SelectListItem();
                        category.Value = reader.GetInt32(0).ToString();
                        category.Text = reader.GetString(1);
                        Categories.Add(category);
                    }
                    
                }
            }
        }
    }
}
