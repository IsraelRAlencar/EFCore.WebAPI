using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repo
{
    public class EFCoreRepository : IEFCoreRepository
    {
        private readonly HeroContext _context;
        public EFCoreRepository(HeroContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Hero[]> GetAllHeroes(bool includeBattles = false)
        {
            IQueryable<Hero> query = _context.Heroes.Include(h => h.Identity).Include(h => h.Weapons);

            if (includeBattles) {
                query.Include(h => h.HeroesBattles).ThenInclude(h => h.Battle);
            }

            query = query.AsNoTracking().OrderBy(h => h.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Hero> GetHeroById(int id, bool includeBattles = false)
        {
            IQueryable<Hero> query = _context.Heroes.Include(h => h.Identity).Include(h => h.Weapons);

            if (includeBattles)
            {
                query.Include(h => h.HeroesBattles).ThenInclude(h => h.Battle);
            }

            query = query.AsNoTracking().OrderBy(h => h.Id);

            return await query.FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<Hero[]> GetHeroesByName(string name, bool includeBattles = false)
        {
            IQueryable<Hero> query = _context.Heroes.Include(h => h.Identity).Include(h => h.Weapons);

            if (includeBattles)
            {
                query.Include(h => h.HeroesBattles).ThenInclude(h => h.Battle);
            }

            query = query.AsNoTracking().Where(h => h.Name.Contains(name)).OrderBy(h => h.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Battle[]> GetAllBattles(bool includeHeroes = false)
        {
            IQueryable<Battle> query = _context.Battles;

            if (includeHeroes)
            {
                query.Include(h => h.HeroesBattles).ThenInclude(h => h.Hero);
            }

            query = query.AsNoTracking().OrderBy(h => h.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Battle> GetBattleById(int id, bool includeHeroes = false)
        {
            IQueryable<Battle> query = _context.Battles;

            if (includeHeroes)
            {
                query.Include(h => h.HeroesBattles).ThenInclude(h => h.Hero);
            }

            query = query.AsNoTracking().OrderBy(h => h.Id);

            return await query.FirstOrDefaultAsync();
        }
    }
}
