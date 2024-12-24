using KnnApp.Core.Entityes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnnApp.Core.Entityes;
public class Category:BaseEntity
{
    public string CategoryName { get; set; }
    public ICollection<Product> Products { get; set; }

}
