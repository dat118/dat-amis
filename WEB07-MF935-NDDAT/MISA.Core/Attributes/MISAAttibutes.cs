using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    class MISARequire : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Property)]
    class MISAEmail : Attribute
    {

    }
    [AttributeUsage(AttributeTargets.Property)]
    class MISACode : Attribute
    {

    }
    [AttributeUsage(AttributeTargets.Property)]
    class MISANotMap : Attribute
    {

    }
}
