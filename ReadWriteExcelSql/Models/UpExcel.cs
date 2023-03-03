using System.ComponentModel.DataAnnotations.Schema;

namespace ReadWriteExcelSql.Models
{
    public class UpExcel
    {
        [Column("Id")]
        public int ExcelId { get; set; }
        public string Col1 { get; set; }
        public string Col2 { get; set; }
        public string Col3 { get; set; }
        public string Col4 { get; set; }
    }
}
