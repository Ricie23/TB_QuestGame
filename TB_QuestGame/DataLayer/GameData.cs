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
                ExpierencePoints = 10,
                Lives = 2,
                Health = 100

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


            {
                gameMap.MapLocations[0, 1] = new Location()
                {
                    Id = 0,
                    Name = "Detective Office Headquarters",
                    Description = "A small dark apartment/ office right in the crappy downtown of new chicago. it is rare to hear silence throughout the night with so many police sirens going throughout the city.",
                    Accessible = true,
                    ModifiyExperiencePoints = 10,
                    Message = "I'm gettin' too old for this kinda stuff. If I could just get one more case to pay for a one way ticket down to sunalito I can rest. " +
                    "But I guess I spoke to soon when this dame walked in. as they say careful what ya wish for.",
                    ImageFileName= "office.jpg"
                };

                gameMap.MapLocations[1, 1] = new Location()
                {
                    Id = 1,
                    Name = "Main Street, New Chicago",
                    Description = "The bustling city street and the heart of New Chicago. bustling hover cars, self-driving ubers, and many people walking around during the day. at night it's not so pretty.",
                    Accessible = true,
                    ModifiyExperiencePoints = 10,
                    Message="This city is gettin' too dang big. what happened to the good ol days when taxis actually had drivers and people were nice to each other? the address Lori's sister gave me is on the east side of town." +
                    "but maybe Joey might know somethin. seeins how he knows everybody.",
                    ImageFileName= "cyberpunk-street.png"

                };

                gameMap.MapLocations[1, 0] = new Location()
                {
                    Id = 2,
                    Name = "Joey's Club",
                    Description = "A small hole in the wall nightclub and bar. Joey tries to keep the place nice, but let's just say it's not a club for the top-notch citizens of New Chicago.",
                    Accessible = true,
                    ModifiyExperiencePoints = 10,
                    Message="haven't been in here in a while. Joey's lookin a little rough. this place ain't quite the same as it used to be",
                    ImageFileName= "bar.gif"

                };

                gameMap.MapLocations[2, 0] = new Location()
                {
                    Id = 3,
                    Name = "Gambler's Den",
                    Description = "A hidden speak easy type room tucked away in Joey's Club. high rollers only.",
                    Accessible = false,
                    RequiredExp = 40,
                    ModifiyExperiencePoints = 20,
                    ModifyHealth = -25,
                    Message="They Jumped me! I wasn't ready for that but boy I'm ready now.",
                    ImageFileName= "gambler.jpg"
         
                };

                gameMap.MapLocations[1, 2] = new Location()
                {
                    Id = 4,
                    Name = "Lori's Apartment",
                    Description = "nice place but nothin special. quite a few floorss up in a decent part of town.",
                    Accessible = true,
                    ModifiyExperiencePoints = 10,
                    Message="hmm not a whole lotta help in here. seems like a pretty nice gal. kinda strange that she has a matchbook from Joey's club though.",
                    ImageFileName= "apratment.jpg"
                };

                return gameMap;
            };



        }
    }
}
