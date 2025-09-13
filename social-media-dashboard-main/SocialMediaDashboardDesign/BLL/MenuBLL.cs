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

        // Toggle trạng thái
        public bool ToggleAvailability(int id)
        {
            return menuDAL.ToggleAvailability(id);
        }
    }
}
