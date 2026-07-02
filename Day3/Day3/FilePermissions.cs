using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3Assignment
{
    [Flags]
    public enum FilePermission
    {
        Read = 1,
        Write = 2,
        Execute = 4
    }
}
