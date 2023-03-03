using Microsoft.EntityFrameworkCore;

namespace ReadWriteExcelSql.Models
{
    public class ContextBase : DbContext
    {
        public ContextBase()
        { }

        public ContextBase(DbContextOptions<DbContext> options) : base(options)
        {
        }

        public virtual DbSet<UpExcel> UpExcels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=UpExcel;uid=root;pwd=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.6.41-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UpExcel>().ToTable("UpExcel").HasKey(t => t.ExcelId);
            base.OnModelCreating(builder);
        }
    }
}
