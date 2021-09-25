using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Data.Entities
{
    public class InputOutputResult
    {
        [Key]
        public int Id { get; set; }
        public string InputList { get; set; }
        public string OutputList { get; set; }
        public DateTime InputTime { get; set; }
        public DateTime OutputTime { get; set; }
        public FileType FileType { get; set; }
        public int FileTypeId { get; set; }
    }
}
