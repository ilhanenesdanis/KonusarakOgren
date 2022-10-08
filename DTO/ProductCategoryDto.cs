using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductCategoryDto:BaseDTO
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        public CategoryDto Category { get; set; }
        public ProductDto Product { get; set; }
    }
}
