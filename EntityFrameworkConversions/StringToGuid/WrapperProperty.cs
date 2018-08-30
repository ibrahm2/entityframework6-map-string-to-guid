namespace EntityFrameworkConversions.StringToGuid
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using EntityFrameworkConversions.Entities;

    public partial class DbUsingWrapperProperty : DbContext
    {
        public DbUsingWrapperProperty()
            : base("name=DbUsingWrapperProperty")
        {
        }

        public virtual DbSet<WrapperTable> Tables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WrapperTable>().ToTable("Table");
        }
    }

    public class WrapperTable : Table
    {
        public new Guid Id
        {
            get
            {
                return new Guid(base.Id);
            }
            set
            {
                base.Id = value.ToString();
            }
        }
    }
}
