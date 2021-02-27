﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnitInStock { get; set; }
        public decimal UnitPrice { get; set; }
    }
}

// Bir class'ın default erişim bildirgeci internal dır.
// Bir property'nin default erişim bildirgeci ise private dır.
// internal access modifiers erişim türünde sadece aynı name space içerisinde bütün Class'larda erişim sağlanır.
