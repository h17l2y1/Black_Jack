using BlackJackDataAccess.Domain;
using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackDataAccess.Repositories.Dapper
{
	public class StatisticDapperRepository : MainGameDapperRepository<Statistic>, IStatisticRepository
	{
		public StatisticDapperRepository(IOptions<ConnectionStrings> connectionConfig) : base(connectionConfig)
		{
		}

		public async Task<List<Statistic>> GetAllGames(int offset, int size)
		{
			var sql = $@"
                    SELECT 
		                AspNetUsers.UserName,
		                GameUsers.Winner, 
		                Sum(Value) as Score,
		                CardMoves.GameId
                    FROM 
		                Games
                    Inner JOIN 
		                (Select * From GameUsers ) 
		                as GameUsers ON Games.Id = GameUsers.GameId 
                    Inner JOIN 
		                CardMoves ON Games.Id = CardMoves.GameId And 
		                PlayerId = GameUsers.UserId
                    Inner JOIN 
		                AspNetUsers ON AspNetUsers.Id = UserId
                    WHERE  		
		                CardMoves.Role = 'User'
                    group by
		                CardMoves.GameId, AspNetUsers.UserName, GameUsers.Winner
                    Order By 
                        CardMoves.GameId 
                    OFFSET 
                        {offset} Row 
                    FETCH NEXT {size} ROWS ONLY";


			return (await Connection.QueryAsync<Statistic>(sql)).ToList();

		}

		public async Task<int> CountElements()
		{
			var sql = $@"
                    SELECT COUNT(*) AS total FROM 
                    (
                    SELECT 
		                AspNetUsers.UserName,
		                GameUsers.Winner, 
		                Sum(Value) as Score,
		                CardMoves.GameId
                    FROM 
		                Games
                    Inner JOIN 
		                (Select * From GameUsers ) 
		                as GameUsers ON Games.Id = GameUsers.GameId 
                    Inner JOIN 
		                CardMoves ON Games.Id = CardMoves.GameId And 
		                PlayerId = GameUsers.UserId
                    Inner JOIN 
		                AspNetUsers ON AspNetUsers.Id = UserId
                    WHERE  		
		                CardMoves.Role = 'User'
                    group by
		                CardMoves.GameId, AspNetUsers.UserName, GameUsers.Winner
		                ) AS total;";

			return await Connection.QuerySingleAsync<int>(sql);
		}

		public async Task<List<Statistic>> GetUserGames(int offset, int size, string userName)
		{
			var sql = $@"
                    SELECT 
		                AspNetUsers.UserName,
		                GameUsers.Winner, 
		                Sum(Value) as Score,
		                CardMoves.GameId
                    FROM 
		                Games
                    Inner JOIN 
		                (Select * From GameUsers ) 
		                as GameUsers ON Games.Id = GameUsers.GameId 
                    Inner JOIN 
		                CardMoves ON Games.Id = CardMoves.GameId And 
		                PlayerId = GameUsers.UserId
                    Inner JOIN 
		                AspNetUsers ON AspNetUsers.Id = UserId
                    WHERE  		
		                CardMoves.Role = 'User' and AspNetUsers.UserName = '{userName}'
                    group by
		                CardMoves.GameId, AspNetUsers.UserName, GameUsers.Winner
                    Order By 
                        CardMoves.GameId 
                    OFFSET 
                        {offset} Row 
                    FETCH NEXT {size} ROWS ONLY";

			return (await Connection.QueryAsync<Statistic>(sql)).ToList();
		}

		public async Task<int> CountUsers(string userName)
		{
			var sql = $@"
                    SELECT COUNT(*) AS total FROM 
                    (
                    SELECT 
		                AspNetUsers.UserName,
		                GameUsers.Winner, 
		                Sum(Value) as Score,
		                CardMoves.GameId
                    FROM 
		                Games
                    Inner JOIN 
		                (Select * From GameUsers ) 
		                as GameUsers ON Games.Id = GameUsers.GameId 
                    Inner JOIN 
		                CardMoves ON Games.Id = CardMoves.GameId And 
		                PlayerId = GameUsers.UserId
                    Inner JOIN 
		                AspNetUsers ON AspNetUsers.Id = UserId
                    WHERE  		
		                CardMoves.Role = 'User' and AspNetUsers.UserName = '{userName}'
                    group by
		                CardMoves.GameId, AspNetUsers.UserName, GameUsers.Winner
		                ) AS total;";

			return (await Connection.QuerySingleAsync<int>(sql));
		}
	}

}
