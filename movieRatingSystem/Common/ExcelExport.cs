using OfficeOpenXml;

namespace movieRatingSystem.Common;

public class ExcelExport
{
    public static void ExportToExcel(DataGridView dataGridView, string filePath)
    {
        // 创建一个新的ExcelPackage
        using (ExcelPackage package = new ExcelPackage())
        {
            // 添加一个工作表
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

            // 将DataGridView中的数据写入Excel工作表中
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    worksheet.Cells[i + 1, j + 1].Value = dataGridView.Rows[i].Cells[j].Value?.ToString();
                }
            }

            // 保存Excel文件
            FileInfo file = new FileInfo(filePath);
            package.SaveAs(file);
        }

        MessageBox.Show("导出成功！");
    }
}