using Domain.Entities;

namespace WepApis92.Services
{
    //paso1
    public interface IAutorServices
    {
        //paso 4
        public Task<Response<List<Autor>>> GetAutores();

        public Task<Response<Autor>> Crear(Autor i);

        public Task<Response<Autor>> Editar(int id, Autor autor);
        public Task<Response<bool>> Eliminar(int id);

    }
}
