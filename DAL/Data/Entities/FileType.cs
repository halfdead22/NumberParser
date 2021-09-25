using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Data.Entities
{
    public class FileType
    {
        public int Id { get; set; }
        public string FileTypeFormat { get; set; }
        public ICollection<InputOutputResult> InputOutputResults { get; set; }
    }
}
