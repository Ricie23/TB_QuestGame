using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TB_QuestGame.Models;
using System.Collections.ObjectModel;
namespace TB_QuestGame.DataLayer
{
   public class GameData
    {
        public static Player PlayerData()
        {
            return new Player()
            {
                Id = 1,
                Name = "Angus McKlintock",
                Age = 63,
                Race = Player.RaceType.Human,
                LocationId = 0,
                ExpierencePoints=0,
                Lives=2,
                Health=100
            };
            
        }

        public static List<string> InitialMessages()
        {
            return new List<string>()
            {
                "It's been too long without a new case, but too long till I can Retire. " +
                "I'm gettin too old for this line of work and I just need at least one more case to go out like a bang." +
                "apperently, I chose the wrong case."
            };
        }

        public static GameMapCoordinates InitialGameMapLocation()
        {
            return new GameMapCoordinates() { Row = 0, Column = 1 };
        }

        public static Map GameMap()
        {
            int rows = 3;
            int columns = 3;
            Map gameMap = new Map(rows, columns);
           
          
            { gameMap.MapLocations[0, 1] = new Location()
            {
                Id = 0,
                Name = "Detective Office Headquarters",
                Description = "A small dark apartment/ office right in the crappy downtown of new chicago. it is rare to hear silence throughout the night with so many police sirens going throughout the city.",
                Accessible = true,
                Exp = 10
            };
                gameMap.MapLocations[1, 1] = new Location()
                {
                    Id = 1,
                    Name = "Main Street, New Chicago",
                    Description = "The bustling city street and the heart of New Chicago. bustling hover cars, self-driving ubers, and many people walking around during the day. at night it's not so pretty.",
                    Accessible = true,
                    Exp = 10
                };
                gameMap.MapLocations[1, 0] = new Location()
                {
                    Id = 2,
                    Name = "Joey's Club",
                    Description = "A small hole in the wall nightclub and bar. Joey tries to keep the place nice, but let's just say it's not a club for the top-notch citizens of New Chicago.",
                    Accessible = true,
                    Exp = 10
                };
                gameMap.MapLocations[2, 0] = new Location()
                {
                    Id = 3,
                    Name = "Gambler's Den",
                    Description = "A hidden speak easy type room tucked away in Joey's Club. high rollers only.",
                    Accessible = false,

                    Exp = 20
                };
                gameMap.MapLocations[1, 2] = new Location()
                {
                    Id = 4,
                    Name = "Lori's Apartment",
                    Description = "nice place but nothin special. quite a few floorss up in a decent part of town.",
                    Accessible = true,
                    Exp = 10
                };
                return gameMap;
        };
  
         
          
        }
    }
}
