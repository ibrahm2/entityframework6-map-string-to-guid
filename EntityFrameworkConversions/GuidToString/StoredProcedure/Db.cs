namespace EntityFrameworkConversions.GuidToString.StoredProcedure
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Db : DbContext
    {
        public Db()
            : base("name=Db")
        {
        }

        public virtual DbSet<Table> Tables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table>().MapToStoredProcedures(prop=>prop.Insert(sp=>sp.HasName("sp_InsertTable").Parameter(pm => pm.Id, "@id")));
        }
    }
}
