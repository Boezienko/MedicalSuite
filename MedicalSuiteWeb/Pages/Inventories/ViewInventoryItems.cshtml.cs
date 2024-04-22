using MedicalSuiteBusiness;
using MedicalSuiteWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace MedicalSuiteWeb.Pages.Inventories
{
    [BindProperties]
    public class ViewInventoryItemsModel : PageModel
    {
        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();

        public List<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>();

        public int SelectedCategoryId { get; set; }
        public void OnGet()
        {
            PopulateCategoryDDL();
        }

        public void OnPost()
        {
            PopulateInventoryItem(SelectedCategoryId);
            PopulateCategoryDDL();
        }

        private void PopulateInventoryItem(int id)
        {
            using(SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT InventoryItemId, InventoryItemCode, InventoryItemName, InventoryItemDescription, InventoryItemPrice FROM InventoryItem WHERE CategoryId = @categoryId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@categoryId", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        var item = new InventoryItem();
                        item.InventoryItemCode = reader.GetString(0);
                        item.InventoryItemName = reader.GetString(1);
                        item.InventoryItemDescription = reader.GetString(2);
                        item.InventoryItemPrice = reader.GetDecimal(3);
                        item.InventoryItemId = reader.GetInt32(4);
                        InventoryItems.Add(item);

                    }
                }
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
                        if(category.Value == SelectedCategoryId.ToString())
                        {
                            category.Selected = true;
                        }
                        Categories.Add(category);
                    }

                }
            }
        }
    }
}
