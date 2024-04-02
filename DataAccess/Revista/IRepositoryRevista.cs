using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace DataAccess
{
    public interface IRepositoryRevista: IRepository<Revista>
    {
        IEnumerable<Revista> GetByName(string name);
    }
}
