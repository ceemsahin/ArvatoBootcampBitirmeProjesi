using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    

        public class ApiDbContext :DbContext  //Veri Tabanını Bağladım
        {

            
            //Entities katmanından gelen classlarımla veri tabanına kaydedeceğim tablo adlarını tanıttım.
            public DbSet<Mytable> Mytable { get; set; }
            public DbSet<UserEntity> Users { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Host=localhost;Database=ArvatoBootcamp;Username=postgres;Password=delta");
        }
            
        }
        
}