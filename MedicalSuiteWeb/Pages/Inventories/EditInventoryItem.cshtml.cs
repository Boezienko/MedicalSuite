using MedicalSuiteBusiness;
using MedicalSuiteWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace MedicalSuiteWeb.Pages.Inventories
{
    [BindProperties]
    public class EditInventoryItemModel : PageModel
    {
        public InventoryItem Item { get; set; } = new InventoryItem();

        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        public void OnGet(int id)
        {
            PopulateInventoryItem(id);
            PopulateCategoryDDL();
            
        }

        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    string cmdText = "UPDATE InventoryItem SET InventoryItemCode = @itemCode, InventoryItemName = @itemName, InventoryItemDescription = @itemDescription, InventoryItemPrice = @itemPrice, CategoryId = @categoryId  WHERE InventoryItemId = @itemId";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@itemCode", Item.InventoryItemCode);
                    cmd.Parameters.AddWithValue("@itemName", Item.InventoryItemName);
                    cmd.Parameters.AddWithValue("@itemDescription", Item.InventoryItemDescription);
                    cmd.Parameters.AddWithValue("@itemPrice", Item.InventoryItemPrice);
                    cmd.Parameters.AddWithValue("@categoryId", Item.CategoryId);
                    cmd.Parameters.AddWithValue("@itemId", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return RedirectToPage("ViewInventoryItems");

                }
            }
            else
            {
                return Page();
            }
        }

        private void PopulateCategoryDDL()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT CategoryId, CategoryName FROM Category ORDER BY CategoryName";
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
                        if (category.Value == Item.CategoryId.ToString())
                        {
                            category.Selected = true;
                        }
                        Categories.Add(category);
                    }

                }
            }
        }

        private void PopulateInventoryItem(int id)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT InventoryItemId, InventoryItemCode, InventoryItemName, InventoryItemDescription, InventoryItemPrice, CategoryId WHERE InventoryItem = @itemId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@itemId", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var InventoryItemId = id;
                        Item.InventoryItemCode = reader.GetString(1);
                        Item.InventoryItemName = reader.GetString(2);
                        Item.InventoryItemDescription = reader.GetString(3);
                        Item.InventoryItemPrice = reader.GetDecimal(4);
                        Item.CategoryId = reader.GetInt32(5);

                    }
                }
            }
        }
    }
}
