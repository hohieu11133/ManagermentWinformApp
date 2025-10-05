using System;
using System.Data;
using System.IO;
using ExcelDataReader;



namespace SocialMediaDashboardDesign.BusinessLogic
{
    public static class ExcelHelper
    {
        public static DataTable ReadDataFromFile(string filePath)
        {
            DataTable dt = new DataTable();
            FileInfo fileInfo = new FileInfo(filePath);

            // Cần có System.Text.Encoding.CodePages.dll và System.IO.Packaging.dll cho ExcelDataReader
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader reader = null;

                if (fileInfo.Extension.Equals(".xls") || fileInfo.Extension.Equals(".xlsx"))
                {
                    reader = ExcelReaderFactory.CreateReader(stream);
                }
                else if (fileInfo.Extension.Equals(".csv"))
                {
                    // Nếu là CSV, cần cấu hình tùy chọn đọc (ví dụ: dấu phân cách)
                    reader = ExcelReaderFactory.CreateCsvReader(stream);
                }
                else
                {
                    throw new InvalidOperationException("Định dạng file không được hỗ trợ.");
                }

                if (reader != null)
                {
                    DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            // Lấy dòng đầu tiên làm tên cột
                            UseHeaderRow = true
                        }
                    });

                    // Lấy Sheet đầu tiên
                    if (result.Tables.Count > 0)
                    {
                        dt = result.Tables[0];
                    }
                }
            }
            return dt;
        }
        }
    }
