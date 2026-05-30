using KursMVVM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KursMVVM.Services
{
    public class ProductPageService
    {
        public async Task<List<Product>> getProducts()
        {
            using (KursContext db = new KursContext())
            {
                var list = db.Products.ToListAsync();
                if (list != null) return await list;
                return null!;
            }
        }
    }
}
