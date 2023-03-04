using ReadWriteExcelSql.Models.ViewModels;
using System.Collections.Generic;

namespace ReadWriteExcelSql.Models.Interfaces
{
    public interface IServiceExcel
    {
        List<string> ReadTextFile(string path);
        List<ExcelDataViewModel> ReadExcelFile();
        void SaveToDatabase(string[][] recebida, int totalLinhas);
    }
}