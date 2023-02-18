using Entities.DTO.Player;

namespace Business.Abstract
{
    public interface IPlayerService
    {
        string StartGame(StartGameDto gameDto); 
    }
}
