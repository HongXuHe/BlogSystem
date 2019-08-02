using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace System.Blog.Web.Models.Category
{
    public class AddCategoryViewModel
    {
        [DisplayName("Category Name")]
        [Required]
        public string Name { get; set; }
    }
}
