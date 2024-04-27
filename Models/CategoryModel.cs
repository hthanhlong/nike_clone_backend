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
    }
}

