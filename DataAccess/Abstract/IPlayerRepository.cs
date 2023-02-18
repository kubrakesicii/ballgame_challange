using Entities.Concrete;
using Entities.DTO.Player;

namespace DataAccess.Abstract
{
    public interface IPlayerRepository
    {
        List<Player> CreatePlayerList(StartGameDto gameDto);
        List<Player> TurnPlayersOnce(List<Player> curPlayers, int startInd);
        string GetPlayer(List<Player> players, int id);
    }
}
