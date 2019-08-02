using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace System.Blog.Entities
{
    [Table("Users")]
    public class UserEntity : BaseEntity
    {
        #region Property
        [Required]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Portrait { get; set; }
        public int FansCount { get; set; }
        #endregion
    }
}
