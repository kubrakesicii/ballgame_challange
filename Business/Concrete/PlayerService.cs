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

            // Önce bir tur dönülerek yeni oyuncu listesi alınır. Bu tur default 0. index, yani ilk oyuncudan başlar.
            var curPlayers = _uow.Players.TurnPlayersOnce(players, 0);


            // Oyunda 1 kişi kalana kadar tur dönmeye devam edilir.
            while (curPlayers.Count() != 1)
            {
                // İlk turdan sonra, son oyuncunun hamle yapma durumuna göre tur başlatılır.
                // Hamle yapmak : Kendinden sonrakini elemek anlamındadır.
                // Son oyuncu Hamle yaptıysa, yeni turda topu direk ilk oyuncuya atar.
                // Hamle yapmadıysa, ilk hamlesi kendinden sonraki ilk (yeni oyuncu listesinin başındaki) oyuncuyu elemek olur.
                // Böylece index 1 kayarak devam eder.
                int ind;
                if (curPlayers.LastOrDefault().IsTurn == 0) ind = 1;
                else ind = 0;
                curPlayers = _uow.Players.TurnPlayersOnce(curPlayers, ind);
            }

            return $"Player number {curPlayers.FirstOrDefault().Id} won the game!";
        }
    }
}
