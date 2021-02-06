using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    // Burada Manager sınıfı Business iş katmanının somut sınıfıdır.
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        // Burada constructor ile injection yapıldı.
        // Burada InMemory ve EntityFramework ismi geçmeyecek.

        public List<Product> GetAll()
        {
            // iş kodları yazılır.
            // InMemoryProductDal ınMemoryProductDal = new InMemoryProductDal();
            // Bir iş sınıfı başka sınıfları new'lemez.  
            return _productDal.GetAll();
        }
        // Yukarıda DAL katmanının soyut sınıfı türünde injection yapılarak veri erişim operasyonları çağırıldı.
        // Burada DAL katmanınının soyut sınıfının kullanılması ileride veri erişim teknolojilerinde ihtiyaç halinde 
        // herhangi bir değişim olması durumunda soyut sınıf vasıtasıyla diğer DAL teknolojilerinin dinamik bir 
        // şekilde sisteme entegre edilip coding kısmında çok az değişikliğe gidilerek kullanılmak istenilen veri
        // veri erişim teknolojilerinin operasyonlarının kullanılmasını sağlıyor.
    }
}
