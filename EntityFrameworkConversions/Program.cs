using EntityFrameworkConversions.StringToGuid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkConversions
{
    class Program
    {
        static void Main(string[] args)
        {
            //sample code created to address Stack Overflow post on how to map a string property to a Guid/uniqueidentifier
            //field in the database when using EF6. In EF Core you can use a value converter but this feature is not available
            //in EF 6
            //https://stackoverflow.com/questions/52013323/entity-framework-how-to-set-the-type-of-a-column-as-uniqueidentifier-with-fluen/52043545?noredirect=1#comment91125675_52043545

            //method 1 - stored procedure: map the entity to a stored procedure that will insert the string property
            //into the uniqueidentifier field
            var dbMappedToStoredProcedure = new DbMappedToStoredProcedure();
            dbMappedToStoredProcedure.Tables.Add(new Table()
            {
                Id = Guid.NewGuid().ToString()
            });
            dbMappedToStoredProcedure.SaveChanges();
            Console.WriteLine("Inserted string id to uniqueidentifier field using a stored procedure.");

            //method 2 - wrapper class: create a class that either inherits or wraps around the entity and cast the string as a guid
            var dbUsingWrapperProperty = new DbUsingWrapperProperty();
            dbUsingWrapperProperty.Tables.Add(new WrapperTable()
            {
                Id = Guid.NewGuid()
            });
            dbUsingWrapperProperty.SaveChanges();
            Console.WriteLine("Inserted string id to uniqueidentifier field using a wrapped property.");
        }
    }
}
