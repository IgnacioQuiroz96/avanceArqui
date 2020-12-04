using gameApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gameApi.Controllers
{
    [Route("GameStuff")]
    [ApiController]
    public class GameStuff : ControllerBase  // /api/GameStuff 
    {
        [HttpGet]
        public IActionResult start()
        {
            return Ok("Funciones implementadas: getall , getbyname -{nombre} , getbystudio-{studio} , getbygenre-{genre} "); //why im coding this in english? this is for weones
        }






        [HttpGet("getall")]
        public IEnumerable<Game> getAll() // returns all games on the database. 

        {
            using (var context = new gameApiContext())
            {
                return context.Games.ToList();
            }
        }

        [HttpGet("getbyname-{name}")]
        public IEnumerable<Game> getByName(string name) //returns game info by looking for it by his name. 
        {
            using (var context = new gameApiContext())
            {
                return context.Games.Where(Game => Game.GameName == name).ToList();
            }

        }

        [HttpGet("getbystudio-{studio}")]
        public IEnumerable<Game> getByStudio(string studio) //returns all games, filtering by a particular game studio
        {
            using (var context = new gameApiContext())
            {
                return context.Games.Where(Game => Game.Studio == studio).ToList();
            }
        }
        [HttpGet("getbygenre-{genre}")]
        public IEnumerable<Game> getByGenre(string genre) //returns all games on a specific genre
        {
            using (var context = new gameApiContext())
            {
                return context.Games.Where(Game => Game.Genre == genre).ToList();
            }
        }

        [HttpGet("getbyplatform-{platform}")]
        public IEnumerable<Game> getByplatform(string platform) //returns all games on a specific genre
        {
            using (var context = new gameApiContext())
            {
                return context.Games.Where(Game => Game.GamePlatform == platform).ToList();
            }
        }




        [HttpPost("newgame")] // lern to test this one propertly

        public IEnumerable<Game> newgame([FromBody] Game auxGame) //receives a a formated json object, then adds it to the database
        {
            using (var context = new gameApiContext())
            {
                context.Add(auxGame);
                context.SaveChanges();
                return context.Games.Where(Game => Game.GameName == auxGame.GameName).ToList(); //returns the new game in json format (in theory)
            }

        }
        [HttpDelete ("delete-{name}")]
        public IActionResult deleteGame (string name)
        {

        }






        //pre made object in json format for testing the post thingie 
        //{
        //   "gameName": "Battlefield 1",
        //   "gameId": 40,
        //   "genre": "shooter",
        //   "gamePlatform": "Pc",
        //   "studio": "Electronic arts"
        //},
        
        // delete from dbo.game where name_name = "Battlefield 1";       /// use if the test actually works ///



    }
}
