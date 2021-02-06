using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    // DAO (Data Access Object) JAVA programlama da kullanılır.
    // DAL (Data Access Layer) .NET programlama da kullanılır.
    // IProductDal (Interface Product Data Access Layer) Katman belirtir.
    // IProductDal Entities katmanındaki Product nesnesine bağımlıdır.
    public interface IProductDal
    {
        // Veri tabanında yapılacak olan operasyonları içeren interface (Product tablosu için)
        List<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        List<Product> GetAllByCategoryId(int categoryId);
    }
}
