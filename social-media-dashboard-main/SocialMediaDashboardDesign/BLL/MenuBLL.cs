using SocialMediaDashboardDesign.DataAccess;
using System;
using System.Data;

namespace SocialMediaDashboardDesign.BLL
{
    public class MenuBLL
    {
        private MenuDAL menuDAL;

        public MenuBLL()
        {
            menuDAL = new MenuDAL();
        }
        /// <summary>
        /// Cập nhật thông tin món ăn cơ bản và thay thế toàn bộ công thức cũ bằng công thức mới.
        /// </summary>
        public bool UpdateMenuItemWithRecipe(int menuItemId, string name, int categoryId, decimal price,
                                             bool isAvailable, string imageUrl, DataTable recipeData)
        {
            // Để đảm bảo tính toàn vẹn, toàn bộ logic này cần được bọc trong một Transaction.
            // Tuy nhiên, vì C# không thể bọc SqlTransaction từ BLL, ta sẽ chuyển giao trách nhiệm 
            // Transaction cho một hàm duy nhất trong DAL.

            // Giả định menuDAL có hàm bọc Transaction: ExecuteUpdateMenuItemTransaction
            return menuDAL.ExecuteUpdateMenuItemTransaction(
                menuItemId,
                name,
                categoryId,
                price,
                isAvailable,
                imageUrl,
                recipeData
            );
        }
        // Lấy danh mục
        public DataTable GetCategories()
        {
            return menuDAL.GetCategories();
        }

        // Lấy toàn bộ menu
        public DataTable GetMenuItems()
        {
            return menuDAL.GetMenuItems();
        }
        // Trong MenuBLL
        public DataRow GetMenuItemByName(string name)
        {
            return menuDAL.GetMenuItemByName(name);
        }

        // Tìm kiếm
        public DataTable SearchMenuItems(string keyword, int? categoryId)
        {
            return menuDAL.SearchMenuItems(keyword, categoryId);
        }

        // Lấy món theo ID
        public DataRow GetMenuItemById(int id)
        {
            return menuDAL.GetMenuItemById(id);
        }
        public DataTable GetRecipeByMenuItemId(int menuItemId)
        {
            // BLL chuyển tiếp yêu cầu đến DAL
            return menuDAL.GetRecipeByMenuItemId(menuItemId);
        }
        public bool AddMenuItemWithRecipe(string name, int categoryId, decimal price, bool isAvailable, string imageUrl, DataTable recipeData)
        {
            // BƯỚC 1: Gọi DAL để thêm MenuItem và lấy ID món ăn mới
            int newMenuItemID = menuDAL.AddMenuItemAndGetID(name, categoryId, price, isAvailable, imageUrl);

            if (newMenuItemID > 0)
            {
                // BƯỚC 2: Gọi DAL để chèn công thức vào MenuItemIngredients
                bool recipeSuccess = menuDAL.AddRecipeItems(newMenuItemID, recipeData);

                // TÙY CHỌN: Nếu bước 2 thất bại, bạn có thể gọi hàm xóa món ăn (Rollback)
                if (!recipeSuccess)
                {
                    // menuDAL.DeleteMenuItem(newMenuItemID); // Hoàn tác
                    return false;
                }

                return true;
            }
            return false;
        }
        // Thêm món
        public bool AddMenuItem(string name, int categoryId, decimal price, bool isAvailable, string imageUrl)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Tên món không được để trống");
            if (price <= 0)
                throw new Exception("Giá phải lớn hơn 0");

            return menuDAL.AddMenuItem(name, categoryId, price, isAvailable, imageUrl);
        }

        // Cập nhật món
        public bool UpdateMenuItem(int id, string name, int categoryId, decimal price, bool isAvailable, string imageUrl)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Tên món không được để trống");
            if (price <= 0)
                throw new Exception("Giá phải lớn hơn 0");

            return menuDAL.UpdateMenuItem(id, name, categoryId, price, isAvailable, imageUrl);
        }

        // Xóa món
        public bool DeleteMenuItem(int id)
        {
            return menuDAL.DeleteMenuItem(id);
        }
        /// <summary>
        /// Kiểm tra sự tồn tại của món ăn.
        /// </summary>
        /// <param name="name">Tên món ăn.</param>
        /// <param name="currentId">ID món ăn hiện tại (0 nếu là Thêm mới).</param>
        /// <returns>True nếu món ăn trùng tên tồn tại và không phải là món đang chỉnh sửa.</returns>
        public bool MenuItemExists(string name, int currentId = 0)
        {
            // BLL chuyển tiếp yêu cầu kiểm tra trùng tên và loại trừ ID hiện tại.
            return menuDAL.MenuItemExists(name, currentId);
        }
        // Toggle trạng thái
        public bool ToggleAvailability(int id)
        {
            return menuDAL.ToggleAvailability(id);
        }

    }
}
