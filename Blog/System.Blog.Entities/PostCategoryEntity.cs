using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace System.Blog.Entities
{
    [Table("PostCategory")]
   public class PostCategoryEntity:BaseEntity
    {
        #region Property
       // public virtual PostEntity Post { get; set; }
        [ForeignKey(nameof(PostEntity))]
        public int PostId { get; set; }
        //public virtual CategoryEntity Category { get; set; }
        [ForeignKey(nameof(CategoryEntity))]
        public int CategoryId { get; set; } 
        #endregion
    }
}
