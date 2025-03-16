using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matalaGUI4
{
        internal static class CompareFiles
        {

            public static bool EqualFiles(DataFile obj1, DataFile obj2)
            {
                if (obj1.getFile() == obj2.getFile() && obj1.getData() == obj2.getData())
                    return true;
                return false;
            }

            public static int CompareSizeFiles(DataFile obj1, DataFile obj2)
            {
                obj1.getData();
                obj2.getData();

                if (obj1.GetSize() > obj2.GetSize())
                    return 0;
                else if (obj1.GetSize() < obj2.GetSize())
                    return 1;
                else
                    return -1;
            }
        }
    }
