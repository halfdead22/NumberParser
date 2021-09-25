using System;
using System.Collections.Generic;
using System.Text;

namespace BAL
{
    public interface IFileOperation
    {
        bool WriteToSpecifiedFile(int[] intArray,string fileType);
    }
}
