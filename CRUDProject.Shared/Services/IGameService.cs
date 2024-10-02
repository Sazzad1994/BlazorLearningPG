using CRUDProject.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDProject.Shared.Services
{
    public interface IGameService
    {
        Task<List<Game>> GetAllGames();
        Task<Game> GetGameById(int Id);
        Task<Game> AddGames(Game game1);
        Task<Game>EditGames(int Id,Game game1);
        Task<bool>DeleteGames(int Id);
        
    }
}
