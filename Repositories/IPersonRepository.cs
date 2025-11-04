using System.Collections.Generic;
using System.Threading.Tasks;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Persona>> GetAllAsync();
        Task<Persona?> GetByIdAsync(long cc);
        Task<Persona> CreateAsync(Persona persona);
        Task<bool> UpdateAsync(Persona persona);
        Task<bool> DeleteAsync(long cc);
        Task<int> CountAsync();
    }
}
