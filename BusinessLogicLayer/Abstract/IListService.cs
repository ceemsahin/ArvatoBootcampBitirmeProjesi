using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface IListService
    {


        Task<List<Mytable>> GetListRate();//Rate'e göre movie büyükten küçüğe doğru sıralansın


    }
}
