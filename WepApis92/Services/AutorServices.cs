using Dapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WepApis92.Context;

namespace WepApis92.Services
{
    //paso1, crear servicio
    public class AutorServices :IAutorServices
    {
        private readonly ApplicationDBContext _context;
        public AutorServices(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Autor>>> GetAutores()
        {
            try
            {
                List<Autor> Response = new List<Autor>();
                var result = await _context.Database.GetDbConnection().QueryAsync<Autor>("spGetAutores", new {}, commandType: CommandType.StoredProcedure);
                Response = result.ToList();

                return new Response<List<Autor>>(Response);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

        public async Task<Response<Autor>> Crear(Autor i)
        {
            try
            {
                Autor result = (await _context.Database.GetDbConnection().QueryAsync<Autor>("spCrearAutor", new { i.Nombre, i.Nacionalidad }, commandType: CommandType.StoredProcedure)).FirstOrDefault();

                return new Response<Autor>(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }
        public async Task<Response<Autor>> Editar(int id, Autor autor)
        {
            try
            {
                Autor result = (await _context.Database.GetDbConnection().QueryAsync<Autor>("spEditarAutor", new { PkAutor = id, autor.Nombre, autor.Nacionalidad }, commandType: CommandType.StoredProcedure )).FirstOrDefault();

                return new Response<Autor>(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

        public async Task<Response<bool>> Eliminar(int id)
        {
            try
            {
                var result = await _context.Database.GetDbConnection().ExecuteAsync("spEliminarAutor", new { PkAutor = id },commandType: CommandType.StoredProcedure);
                return new Response<bool>(true);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

    }
}
