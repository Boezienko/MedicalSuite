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

        public IActionResult onPost()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "INSERT INTO Inventories(InventoryItemCode, InventoryItemName, InventoryItemDescription, InventoryItemPrice, CategoryId) " + "VALUES (@itemCode, @itemName, @itemDescription, @itemPrice, @categoryId)";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@itemCode", newInventoryItem.InventoryItemCode);
                cmd.Parameters.AddWithValue("@itemName", newInventoryItem.InventoryItemName);
                cmd.Parameters.AddWithValue("@itemDescription", newInventoryItem.InventoryItemDescription);
                cmd.Parameters.AddWithValue("@itemPrice", newInventoryItem.InventoryItemPrice);
                cmd.Parameters.AddWithValue("@categoryId", newInventoryItem.CategoryId);

                conn.Open();
                cmd.ExecuteNonQuery();
                return RedirectToAction("InventoryViewer");

            }
        }
        public void OnGet()
        {
            PopulateCategoryDDl();
        }
        public void OnPost()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "INSERT INTO Inventory(Id, InventoryItemCode, InventoryItemName, InventoryItemDescription, InventoryItemPrice, CategoryId) " + "VALUES (@itemId, doctorsOfficeId, @itemName, @itemDescription, "
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
                    while (reader.Read())
                    {
                        var category = new SelectListItem();
                        category.Value = reader.GetInt32(0).ToString();
                        category.Text = reader.GetString(1).ToString();
                        Categories.Add(category);
                    }

                }
            }
        }
    }
}
