﻿using KnnApp.Core.Entityes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnnApp.Core.Entityes;
public class Product:BaseEntity
{
    public string ProductName { get; set; } 
    public string Description { get; set; }
    public int Price { get; set; }  
    public int? OldPrice { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }

}
