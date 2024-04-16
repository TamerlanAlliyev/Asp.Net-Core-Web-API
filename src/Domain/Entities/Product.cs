using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest.Domain.Entities;

public class Product
{
    public string Name { get; set; } = null!;
    public string Image { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }= null!;

}
