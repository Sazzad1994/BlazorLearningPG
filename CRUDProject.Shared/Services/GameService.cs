using CRUDProject.Shared.Entities;
using CRUDProject.Shared.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace CRUDProject.Shared.Services
{
    public class GameService : IGameService
    {
        private readonly DataContext _dataContext;
        public GameService(DataContext dataContext) { 
            _dataContext = dataContext;
        }
        public async Task<Game>AddGames(Game game1)
        {
             _dataContext.Games.Add(game1);
            await _dataContext.SaveChangesAsync();
            return game1;
        }

        public async Task<bool> DeleteGames(int Id)
        {
            var result = await _dataContext.Games.FindAsync(Id);
            if (result != null) {
                _dataContext.Remove(result);
                _dataContext.SaveChanges();
                return true;
            }
            
            return false;
        }

        public async Task<Game> EditGames(int Id, Game game1)
        {
            var result = await _dataContext.Games.FindAsync(Id);
            if (result != null)
            {
                result.GameName = game1.GameName;
                _dataContext.SaveChanges();
                return result;
            }
            throw new Exception("No GAME! Found!! ");
        }

        public async Task<List<Game>> GetAllGames()
        {
         // await Task.Delay(1000);
         var games= await  _dataContext.Games.ToListAsync();
            return games;
        }

        public async Task<Game> GetGameById(int Id)
        {
            var result = await _dataContext.Games.FindAsync(Id);
            return result;
        }
    }
}
