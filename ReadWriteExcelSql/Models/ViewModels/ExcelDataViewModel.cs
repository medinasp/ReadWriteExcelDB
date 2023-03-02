namespace ReadWriteExcelSql.Models.ViewModels
{
    public class ExcelDataViewModel
    {
        public List<string> valores { get; set; }

        public ExcelDataViewModel()
        {
            valores = new List<string>();
        }
    }
}
