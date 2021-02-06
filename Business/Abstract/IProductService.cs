using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    // Business iş katmanı Entity ve DataAccess katmanlarını kullanacağı için bu katmandaki projelere bağımlıdır.
    // Business iş katmanındaki class yapılarıu genelde service diye adlandırılır.
    public interface IProductService
    {
        List<Product> GetAll();

    }
}
