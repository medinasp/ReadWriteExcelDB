using ReadWriteExcelSql.Models.ViewModels;
using System.Collections.Generic;

namespace ReadWriteExcelSql.Models.Interfaces
{
    public interface IServiceExcel
    {
        List<ExcelDataViewModel> ReadExcelFile();
        void SaveToDatabase(string[][] recebida, int totalLinhas);
    }
}