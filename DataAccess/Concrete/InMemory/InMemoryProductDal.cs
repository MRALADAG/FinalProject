using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        // Naming convention (İsimlendirme Kuralı) bir .NET standardıdır.
        // Naming convention'a göre _products bir global değişkendir.
        // _products'ı biz metodlarımıza ve constructor yapılarımıza injection yapmak için tanımlarız.
        public InMemoryProductDal()
        {
            _products = new List<Product> {
                new Product{ProductId=1, CategoryId=1, ProductName="Bardak", UnitPrice=15, UnitInStock=15},
                new Product{ProductId=2, CategoryId=1, ProductName="Kamera", UnitPrice=500, UnitInStock=3},
                new Product{ProductId=3, CategoryId=2, ProductName="Telefon", UnitPrice=1500, UnitInStock=2},
                new Product{ProductId=4, CategoryId=2, ProductName="Klavye", UnitPrice=150, UnitInStock=65},
                new Product{ProductId=5, CategoryId=2, ProductName="Mouse", UnitPrice=85, UnitInStock=1}
                // Burada Product bilgileri hazır verilerek sanki bir veritabanından örneğin; Oracle,
                // Postgre, Sql Server, MongoDb den geliyormuş gibi simule edildi.
            };
            // Burada proje ilk çalıştıştığı anda ürün listesi global değişkene bir 
            // constructor vasıtasıyla aktarılmıştır.
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(prod => prod.ProductId == product.ProductId);
            //Product productToDelete = null;

            // Burada Generic List'den eleman silmek için öncelikle listedeki Product tipindeki nesnenin
            // referans numarası verildi.
            // Aksi taktirde bu metoda göndereceğimiz product nesnesi silinemeyecekti. Çünkü Product bir değer tip
            // değil bir referans tipdeki değişkendir.

            // Burada referans numarası zaten foreach döngüsünde atanacağından 
            // gereksiz yere new'leyip de bellekte aslında hiç kullanılmayacak olan yeni bir referans oluşturulmadı.
            // Sadece referansın aktarılacağı değişken oluşturulup bırakıldı.

            // LINQ - Lenguage Integrated Query
            // LINQ ile SQL bazlı yapılar, listeler filtrelenebiliyor.
            // Aşağıdaki yapı LINQ metodu kullanılmadan alternatif olarak klasik döngüyle yapılmaya çalışıldı.
            // Aşağıdaki yöntem LINQ metoduna göre pek pratik bir kullanım değildir.

            //foreach (var prod in _products)
            //{
            //    if (product.ProductId == prod.ProductId)
            //    {
            //        productToDelete = prod;
            //    }
            //}

            // _products.SingleOrDefault(prod=>prod.ProductId == product.ProductId) Bu ifade yukarıdaki foreach ile 
            // aynı işlevi görmektedir. Bu kullanım daha pratiktir.
            // Burada kullanılan prod kelimesi bir Alias dır.
            // Aşağıdaki kod her prod için listeyi tek tek dolaşmaya yarıyor.
            // Her prod için metoda gönderilen product'ın ID'sine eşitmi kontrolü yapılıyor.
            // Burada ProoductId property'si herbir ürün için benzersiz olduğu için tercih edilmiştir.

            // productToDelete = _products.SingleOrDefault(prod => prod.ProductId == product.ProductId);
            // => bu işaret Laambda olarak adlandırılır.
            // productToDelete = _products.FirstOrDefault(prod => prod.ProductId == product.ProductId);
            // productToDelete = _products.First(prod => prod.ProductId == product.ProductId);
            // SingleOrDefault() metoduna alternatif olarak FirstOrDefault() ve First() metodlarıda kullanılabilir.
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategoryId(int categoryIdCh)
        {
            return _products.Where(p => p.CategoryId == categoryIdCh).ToList();
            // Burada Where anahatar kelimesi metod içindeki koşula uygun olan bütün elemanları yeni bir liste haline
            // getirip bu listeyi döndürür.
        }

        public void Update(Product product)
        {
            // Gönderdiğim ürün Id'sine sahip olan listedeki ürünü bul demek.
            Product productToUpdate = _products.SingleOrDefault(prod => prod.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitInStock = product.UnitInStock;
        }
    }
}
