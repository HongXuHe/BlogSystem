using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace System.Blog.Entities
{
    [Table("Categories")]
    public class CategoryEntity : BaseEntity
    {
        #region Property
        [Required]
        public string Name { get; set; } 
        #endregion
    }
}
