using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sparcpoint.Models
{
    [Table("ProductAttributes", Schema = "Instances")]
    public class ProductAttributes
    {
        [Key]
        //public long InstanceId { get; set; }
        public Int32 InstanceId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
