using Microsoft.AspNetCore.Mvc;
using RandomCityWeatherAPI.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramBot;

namespace RandomCityWeatherAPI.Controllers
{
    [ApiController]
    [Route("api/message/")]
    public class MessageController:ControllerBase
    {
        private readonly ICommandManager _manager;

        public MessageController(ICommandManager manager)
        {
            this._manager = manager;
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody]Update update)
        {
            var message = update.Message;
            await _manager.ProcessMessage(message);
            return Ok();
        }
        
    }
}
