namespace DataAccess;
using Domain.Models;
public interface IRepositoryParametro
{
    void Add(Parametro item);
    void Update(Parametro item);
    void Remove(Parametro item);
    Parametro Get(string clave);
    IEnumerable<Parametro> GetManyByKey(string clave);
}