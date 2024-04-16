using Nest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest.Domain.Entities;

public class Category:BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public string Logo { get; set; } = null!;
    public int? ParentCategoryId { get; set; }
    public Category? ParentId { get; set; }
    public ICollection<Category>? SubCategories { get; set; }

    public Category()
    {
        SubCategories = new HashSet<Category>();
    }
}
