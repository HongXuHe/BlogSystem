using System;
using System.Blog.Entities;
using System.Blog.IBLL;
using System.Blog.IDAL;
using System.Collections.Generic;
using System.Text;

namespace System.Blog.Bll
{
   public class CommentBll : BaseBll<CommentEntity>, ICommentBll
    {
        private readonly ICommentDal _commentDal;
        private readonly EntityDbContext _context;
        public CommentBll(ICommentDal commentDal, EntityDbContext context) : base(commentDal, context)
        {
            _commentDal = commentDal;
            _context = context;
        }
    }
}
