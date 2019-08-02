using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace System.Blog.Entities
{
    
    [Table("Posts")]
    public class PostEntity : BaseEntity
    {
        #region Property
        [Required]
        public string Title { get; set; }
        [Required]
        [Column(TypeName = "ntext")]
        public string Content { get; set; }
        #endregion
        #region nav
        /// <summary>
        /// navigate to user
        /// </summary>
      //  public virtual UserEntity User { get; set; }
        [ForeignKey(nameof(UserEntity))]
        public int UserId { get; set; }
        #endregion
    }
}
