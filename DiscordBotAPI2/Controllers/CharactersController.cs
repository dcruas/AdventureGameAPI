using DiscordBotAPI2.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiscordBotAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        
        // GET api/<ValuesController>/5
        [HttpGet("GetCharacterInfo")]
        public ActionResult<object> GetCharacterInfo(string discordId)
        {
            CharacterDB characterDB = new CharacterDB();
            var character = characterDB.GetCharacterInfo(discordId);

            return JsonConvert.SerializeObject(character);
            
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            
        }

        // PUT api/<ValuesController>/5
        [HttpPost("InsertCharacter")]
        public ActionResult<object> InsertCharacter(string discordId , string userName )
        {
            CharacterDB characterDB = new CharacterDB();
            var character = characterDB.InsertCharacter(discordId, userName);
            return JsonConvert.SerializeObject(character);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
