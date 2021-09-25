using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class InputOutputResultModel
    {
            public string InputList { get; set; }
            public string OutputList { get; set; }
            public DateTime InputTime { get; set; }
            public DateTime OutputTime { get; set; }
            public FileType FileType { get; set; }
    }

    public enum FileType
    {
        Text = 1,
        Json = 2,
        Xml = 3
    }
}
