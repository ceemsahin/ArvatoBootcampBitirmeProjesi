using BusinessLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
    public class ListManager : IListService
    {

        IListRepository _listRepository;
        public ListManager(IListRepository listReposiyory)
        {
            _listRepository = listReposiyory;   
        }

        public async Task<List<Mytable>> GetListRate()
        {
            return await _listRepository.GetListRate();

        }
    }
}
