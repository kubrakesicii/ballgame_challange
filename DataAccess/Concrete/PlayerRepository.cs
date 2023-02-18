using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO.Player;

namespace DataAccess.Concrete
{
    public class PlayerRepository : IPlayerRepository
    {
        public List<Player> CreatePlayerList(StartGameDto gameDto)
        {
            int pCount = gameDto.PlayerCount;
            List<Player> playerList = new List<Player>();
            for(int i = 0; i< pCount; i++)
            {
                playerList.Add(new Player
                {
                    Id = i + 1,
                    HaveBall = 0,
                    IsTurn = 0
                });
            }
            return playerList;
        }

        public string GetPlayer(List<Player> players, int id)
        {
            throw new NotImplementedException();
        }

        public List<Player> TurnPlayersOnce(List<Player> curPlayers, int startInd)
        {
            curPlayers.ForEach(it => it.IsTurn = 0);
            List<Player> newItems = new List<Player>(); 

            for (int i = startInd; i < curPlayers.Count(); i += 2)
            {
                if (i + 2 > curPlayers.Count() - 1 && curPlayers.ElementAtOrDefault(i + 1) != null) curPlayers[i].IsTurn = 1;
                newItems.Add(curPlayers[i]);
            }
            return newItems;
        }
    }
}
