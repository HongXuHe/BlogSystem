using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace System.Blog.Entities
{
    [Table("Comments")]
    public class CommentEntity:BaseEntity
    {
        #region Property
        [Required]
        [Column(TypeName = "ntext")]
        public string Comment { get; set; }
        #endregion
        #region nav
        /// <summary>
        /// navigate to user
        /// </summary>
       // public virtual UserEntity User { get; set; }
        [ForeignKey(nameof(UserEntity))]
        public int UserId { get; set; }
        /// <summary>
        /// navigate to post
        /// </summary>
        //public virtual PostEntity Post { get; set; }
        [ForeignKey(nameof(PostEntity))]
        public int PostId { get; set; }
        #endregion
    }
}
