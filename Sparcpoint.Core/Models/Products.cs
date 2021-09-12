using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sparcpoint.Models
{
    [Table("Products", Schema = "Instances")]
    public class Products
    {
        [Key]
        public Int32 InstanceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductImageUris { get; set; }
        public string ValidSkus { get; set; }
        
        [NotMapped]
        public List<ProductCategories> productCategories { get; set; }
        [NotMapped]
        public List<string> ValidSkusList { get; set; }

    }
}
