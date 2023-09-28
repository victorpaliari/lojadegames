using lojadegames.Model;

namespace lojadegames.Service
{
    public interface ICategoriaService
    {

        Task<IEnumerable<Categoria>> GetAll();

        Task<Categoria?> GetById(long id);

        Task<IEnumerable<Categoria>> GetByConsole(string console);

        Task<Categoria?> Create(Categoria Categoria);

        Task<Categoria?> Update(Categoria Categoria);

        Task Delete(Categoria Categoria);

    }
}
