using EFCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repo
{
    public interface IEFCoreRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangeAsync();
        Task<Hero[]> GetAllHeroes(bool includeBattles = false);
        Task<Hero> GetHeroById(int id, bool includeBattles = false);
        Task<Hero[]> GetHeroesByName(string name, bool includeBattles = false);
        Task<Battle[]> GetAllBattles(bool includeHeroes = false);
        Task<Battle> GetBattleById(int id, bool includeHeroes = false);
    }
}
