using Entities.Abstract;
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
// Private erişim tipinde sadece aynı Class içersinde erişim sağlanır.
// Protected erişim tipinde ise sadece hem kendi Class'ı içerinde hemde bu Class'ı 
// inherit eden Class'lar içerisinden erişim sağlanır.
// Public de ilgili projeyi using olarak ekleyen bütün Class'larda erşim sağlanbilir.
