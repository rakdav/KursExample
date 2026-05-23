using KursMVVM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KursMVVM.Services
{
    public class ClientsPageService
    {
        public async Task<List<Client>> getClients()
        {
            using (KursContext db=new KursContext())
            {
                var list = db.Clients.ToListAsync();
                if (list != null) return await list;
                return null!;
            }
        }
    }
}
