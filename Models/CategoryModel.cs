using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reformation.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Image { get; set; }
        public required string Slug { get; set; }
        public required string MetaTitle { get; set; }
        public required string MetaDescription { get; set; }
        public required string MetaKeywords { get; set; }
        public required bool IsActive { get; set; }
        public required bool IsFeatured { get; set; }
        public required int ParentId { get; set; }
        public required int SortOrder { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
    }
}

