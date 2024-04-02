
namespace UsesCases
{
    public interface IServicioCRUD<Dto>
    {
        // Agrega un nuevo elemento y devuelve el DTO del elemento agregado
        Dto Add(Dto dto);

        // Obtiene un elemento por su ID y devuelve el DTO correspondiente
        Dto Get(int id);

        // Elimina un elemento por su ID
        void Remove(int id);

        // Actualiza un elemento existente con el ID proporcionado, basado en los datos del DTO suministrado
        void Update(int id, Dto dto);
    }


}
