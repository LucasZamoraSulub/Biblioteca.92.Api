using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WepApis92.Context;

namespace WepApis92.Services
{
    public class UsuarioServices : IUsuariosServices
    {
        private readonly ApplicationDBContext _context;
        public UsuarioServices(ApplicationDBContext context)
        { 
            _context = context;

        }


        public async Task<Response<List<Usuario>>> GetUsuarios()
        {
            try
            {
                //List<Usuario> response = await _context.Usuarios.ToListAsync();
                List<Usuario> response = await _context.Usuarios.Include(y => y.Roles).ToListAsync();

                return new Response<List<Usuario>>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error"+ex.Message);
            }
        }

        public async Task<Response<Usuario>> GetByID(int id)
        {
            try
            {
                //Usuario res = await _context.Usuarios.FindAsync(id);
                //Segunda opcion
                Usuario res = await _context.Usuarios.FirstOrDefaultAsync(x=> x.PkUsuario == id);
                return new Response<Usuario>(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

        public async Task<Response<UsuariosResponse>> CrearUsuario(UsuariosResponse request)
        {
            try
            {
                Usuario usuario = new Usuario()
                {
                    Nombre = request.Nombre,
                    User = request.User,
                    Password = request.Password,
                    FkRol = request.FkRol
                };
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                return new Response<UsuariosResponse>(request);

            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

        public async Task<Response<UsuariosResponse>> EditarUsuario(int PkUsuario, UsuariosResponse request)
        {
            try
            {
                var usuario = await _context.Usuarios.FindAsync(PkUsuario);
                if (usuario == null)
                {
                    return new Response<UsuariosResponse>("Usuario no encontrado");
                }

                usuario.Nombre = request.Nombre;
                usuario.User = request.User;
                usuario.Password = request.Password;
                usuario.FkRol = request.FkRol;

                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();

                return new Response<UsuariosResponse>(request, "Los datos del Usuario fueron actualizados exitosamente");
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error" + ex.Message);
            }
        }

        public async Task<Response<bool>> EliminarUsuario(int PkUsuario)
        {
            try
            {
                var usuario = await _context.Usuarios.FindAsync(PkUsuario);
                if (usuario == null)
                {
                    return new Response<bool>("Usuario no encontrado");
                }

                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();

                return new Response<bool>(true, "El Usuario ha sido eliminado exitosamente");
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error" + ex.Message);
            }
        }

    }
}
