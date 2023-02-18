using Business.Abstract;
using DataAccess.UnitOfWork;
using Entities.DTO.Player;

namespace Business.Concrete
{
    public class PlayerService : IPlayerService
    {
        private readonly IUnitOfWork _uow;

        public PlayerService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public string StartGame(StartGameDto gameDto)
        {
            var players = _uow.Players.CreatePlayerList(gameDto);

            var curPlayers = _uow.Players.TurnPlayersOnce(players, 0);

            while (curPlayers.Count() != 1)
            {
                int ind;
                if (curPlayers.LastOrDefault().IsTurn == 0) ind = 1;
                else ind = 0;
                curPlayers = _uow.Players.TurnPlayersOnce(curPlayers, ind);
            }

            return $"Player number {curPlayers.FirstOrDefault().Id} won the game!";
        }
    }
}
