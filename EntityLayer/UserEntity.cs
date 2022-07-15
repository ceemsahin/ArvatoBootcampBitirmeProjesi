using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class UserEntity
    {

        // Token almak için giriş yapılan user için oluşturulmuş model
        public int Id { get; set; }
        public string Username { get; set; } //admin veya cem
        public string Password { get; set; } // 123


    }


  
}
