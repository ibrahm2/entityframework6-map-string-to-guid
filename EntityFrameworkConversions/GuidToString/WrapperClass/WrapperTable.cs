using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkConversions.GuidToString.WrapperClass
{
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
