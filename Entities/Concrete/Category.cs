using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    // Çıplak Class kalmasın standardı.
    // Bu standart ile her somut olan sınıfın bir adet soyut sınftan türetilmesi implemente edilmesi olayıdır.
    // Eğer base sınıf kullanılmaz ise ileride proje büyüdüğünde soyutlama problemi yaşanır.
    // Burada temel sınıf IEntity olarak belirlenmiştir.
    // IEntity'i implemente ettikten sonra using satırını da eklemek gerekir.
    // Varlıkları barındıran Class'ların inheritance veya interface imlementasyonu alması gerekiyor.
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
