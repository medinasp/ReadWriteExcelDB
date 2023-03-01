using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace ReadWriteExcelSql.Controllers
{
    public class FileController : Controller
    {
        public IActionResult Index()
        {
            string pathtext = @"C:\1A\file1.txt";
            List<string> linesText = new List<string>();

            try
            {
               using (StreamReader sr = new StreamReader(pathtext))
                    {
                        while (!sr.EndOfStream)
                        {
                            string linetxt = sr.ReadLine();
                            linesText.Add(linetxt);
                        }
                    }
            }
            catch(IOException erro)
            {
                Console.WriteLine("Deu erro");
                Console.WriteLine(erro.Message);
            }
            ViewBag.linesText = linesText;


            string path = @"C:\1A\TemplateDefinicaoDosSonhos.xlsx";
            List<string> lines = new List<string>();
            try
            {
                using (var package = new ExcelPackage(new FileInfo(path)))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;
                    for (int row = 1; row <= rowCount; row++)
                    {
                        string line = "";
                        for (int col = 1; col <= colCount; col++)
                        {
                            var cellValue = worksheet.Cells[row, col].Value;
                            line += (cellValue ?? "").ToString() + " ";
                        }
                        lines.Add(line);
                    }
                }
            }
            catch (IOException erro)
            {
                Console.WriteLine("Deu erro");
                Console.WriteLine(erro.Message);
            }

            ViewBag.Lines = lines;
            return View();

        }
    }
}
