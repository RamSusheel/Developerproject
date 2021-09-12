using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sparcpoint.Models
{
    [Table("ProductCategories", Schema = "Instances")]
    public class ProductCategories
    {
        [Key]
        public Int32 InstanceId { get; set; }
        public Int32 CategoryInstanceId { get; set; }
        
    }
}
