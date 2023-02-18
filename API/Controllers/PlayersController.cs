using Business.Abstract;
using Entities.DTO.Player;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpPost("Play")]
        public ActionResult Play([FromBody] StartGameDto gameDto)
        {
            var res = _playerService.StartGame(gameDto);
            return Ok(res);
        }

    }
}
