using System;

namespace System.Blog.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime? ModifiedTime { get; set; }
        public bool IsDelete { get; set; }
    }
}
