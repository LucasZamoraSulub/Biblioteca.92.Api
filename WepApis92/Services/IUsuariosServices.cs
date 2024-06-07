using Domain.Entities;

namespace WepApis92.Services
{
    public interface IUsuariosServices
    {
        public Task<Response<List<Usuario>>> GetUsuarios();

        public Task<Response<UsuariosResponse>> CrearUsuario(UsuariosResponse request);

        public Task<Response<UsuariosResponse>> EditarUsuario(int PkUsuario, UsuariosResponse request);

        public Task<Response<bool>> EliminarUsuario(int PkUsuario);
        public Task<Response<Usuario>> GetByID(int id);

    }
}
