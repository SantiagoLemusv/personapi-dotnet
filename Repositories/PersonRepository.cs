using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _ctx;
        private DbSet<Persona> Entities => _ctx.Set<Persona>();
        public PersonRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Persona>> GetAllAsync()
        {
            return await Entities.AsNoTracking().ToListAsync();
        }

        public async Task<Persona?> GetByIdAsync(long cc)
        {
            return await Entities.FindAsync(cc);
        }

        public async Task<Persona> CreateAsync(Persona persona)
        {
            Entities.Add(persona);
            await _ctx.SaveChangesAsync();
            return persona;
        }

        public async Task<bool> UpdateAsync(Persona persona)
        {
            var key = await Entities.FindAsync(persona.Cc);
            if (key == null) return false;
            _ctx.Entry(key).CurrentValues.SetValues(persona);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(long cc)
        {
            var entity = await Entities.FindAsync(cc);
            if (entity == null) return false;
            Entities.Remove(entity);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<int> CountAsync()
        {
            return await Entities.CountAsync();
        }
    }

}