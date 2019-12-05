using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Localizei.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {

        public async Task<IEnumerable> GetAll()
        {
            var lista = new List<int> { 1, 2, 3, 4, 5 };
            return lista;
        }
    }
}
