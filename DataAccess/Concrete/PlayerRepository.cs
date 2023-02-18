using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO.Player;

namespace DataAccess.Concrete
{
    public class PlayerRepository : IPlayerRepository
    {
        public List<Player> CreatePlayerList(StartGameDto gameDto)
        {
            // Verilen oyuncu yasısına göre, unique id'ye (numara) sahip oyuncular yaratılır.
            int pCount = gameDto.PlayerCount;
            List<Player> playerList = new List<Player>();
            for(int i = 0; i< pCount; i++)
            {
                playerList.Add(new Player
                {
                    Id = i + 1,
                    IsTurn = 0
                });
            }
            return playerList;
        }

        public List<Player> TurnPlayersOnce(List<Player> curPlayers, int startInd)
        {
            // Önceki turdan son oyuncu hamle yapmış (IsTurn) 0 durumunda kalmış olabilir, bunun yeni turda hataya sebep
            // olmaması için öncelikle yeni turda tüm hamleler sıfırlanır.
            
            curPlayers.ForEach(it => it.IsTurn = 0);
            List<Player> newItems = new List<Player>(); 

            // Oyuncular, kendinden bir sonrakini eleyecek şekilde döner ve elenmeyen her kişi yeni listeye atılır.
            for (int i = startInd; i < curPlayers.Count(); i += 2)
            {
                // Oyunun en önemli şartı burada sağlanır.
                // İlk şart, Eğer döngü bir sonraki indexde sonlanacaksa, yani döngünün son kişisindeysek, VE
                // Döngü sonundaki kişiden, bir sonraki konumda bir oyuncu daha VARSA - son oyuncu bu kişiyi elemiş yani hamle
                // yapmış olur.
                if (i + 2 > curPlayers.Count() - 1 && curPlayers.ElementAtOrDefault(i + 1) != null) curPlayers[i].IsTurn = 1;
                newItems.Add(curPlayers[i]);
            }
            return newItems;
        }
    }
}
