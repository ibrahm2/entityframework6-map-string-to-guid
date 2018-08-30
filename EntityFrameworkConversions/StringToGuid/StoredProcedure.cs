namespace EntityFrameworkConversions.StringToGuid
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using EntityFrameworkConversions.Entities;

    public partial class DbMappedToStoredProcedure : DbContext
    {
        public DbMappedToStoredProcedure()
            : base("name=DbMappedToStoredProcedure")
        {
        }

        public virtual DbSet<Table> Tables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table>().MapToStoredProcedures(prop=>prop.Insert(sp=>sp.HasName("sp_InsertTable").Parameter(pm => pm.Id, "@id")));
        }
    }
}
