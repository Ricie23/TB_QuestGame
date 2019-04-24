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
                Health = 100,
                SkillLevel = 5,
                Inventory = new ObservableCollection<GameItem>()
                {
                    GameItemById(2001),
                    GameItemById(4001)
                }

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


        private static GameItem GameItemById(int id)
        {
            return StandardGameItems().FirstOrDefault(i => i.Id == id);
        }

        private static NPC NpcById(int id)
        {
            return Npcs().FirstOrDefault(i => i.Id == id);
        }

        public static GameMapCoordinates InitialGameMapLocation()
        {
            return new GameMapCoordinates() { Row = 0, Column = 1 };
        }

        public static Map GameMap()
        {
            int rows = 3;
            int columns = 4;
            Map gameMap = new Map(rows, columns);

            gameMap.StandardGameItems = StandardGameItems();


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
                    ImageFileName = "office.jpg",
                    GameItems = new ObservableCollection<GameItem>
                    {
                        GameItemById(3001),
                        GameItemById(3002)
                    },
                Npcs = new ObservableCollection<NPC>()
                {
                    NpcById(5010)
                   
                }
                };

                gameMap.MapLocations[1, 1] = new Location()
                {
                    Id = 1,
                    Name = "Main Street, New Chicago",
                    Description = "The bustling city street and the heart of New Chicago. bustling hover cars, self-driving ubers, and many people walking around during the day. at night it's not so pretty.",
                    Accessible = true,
                    ModifiyExperiencePoints = 10,
                    Message = "This city is gettin' too dang big. what happened to the good ol days when taxis actually had drivers and people were nice to each other? the address Lori's sister gave me is on the east side of town." +
                    "but maybe Joey might know somethin. seeins how he knows everybody.",
                    ImageFileName = "cyberpunk-street.png",
                    GameItems = new ObservableCollection<GameItem>
                    {
                        GameItemById(2002)
                    },

                };

                gameMap.MapLocations[1, 0] = new Location()
                {
                    Id = 2,
                    Name = "Joey's Club",
                    Description = "A small hole in the wall nightclub and bar. Joey tries to keep the place nice, but let's just say it's not a club for the top-notch citizens of New Chicago.",
                    Accessible = true,
                    ModifiyExperiencePoints = 10,
                    Message = "haven't been in here in a while. Joey's lookin a little rough. this place ain't quite the same as it used to be",
                    ImageFileName = "bar.gif",
                    GameItems= new ObservableCollection<GameItem>
                    {
                        GameItemById(3003)
                    },
                      Npcs = new ObservableCollection<NPC>()
                {
                    NpcById(5020),
                }

                };

                gameMap.MapLocations[2, 0] = new Location()
                {
                    Id = 3,
                    Name = "Gambler's Den",
                    Description = "A hidden speak easy type room tucked away in Joey's Club. high rollers only.",
                    Accessible = false,
                    RequiredExp = 120,
                    ModifiyExperiencePoints = 20,
                    ModifyHealth = -20,
                    Message = "They Jumped me! I wasn't ready for that but boy I'm ready now.",
                    ImageFileName = "gambler.jpg",
                    RequiredClueId=1001,
                
                         Npcs = new ObservableCollection<NPC>()
                {
                    NpcById(5001),
                    NpcById(5003)
                }


                };

                gameMap.MapLocations[1, 2] = new Location()
                {
                    Id = 4,
                    Name = "Lori's Apartment",
                    Description = "nice place but nothin special. quite a few floorss up in a decent part of town.",
                    Accessible = true,
                    ModifiyExperiencePoints = 10,
                    Message = "hmm not a whole lotta help in here. seems like a pretty nice gal. kinda strange that she has a matchbook from Joey's club though.",
                    ImageFileName = "apratment.jpg",
                       GameItems = new ObservableCollection<GameItem>
                {
                   GameItemById(1001)
                }
                };
                gameMap.MapLocations[2, 1] = new Location()
                {
                    Id = 5,
                    Name = "TeleShift Factory",
                    Description = "TeleShift factory makes the TeleShift transportation systems. a new device to instantly move you from one place to another.",
                    Accessible = false,
                    ModifiyExperiencePoints = 10,
                    Message = "a very large industrial area. there isn't a whole lot of people around. there seems to be a locked door with a card reader",
                    ImageFileName = "factory.gif",
                    RequiredClueId=1002,
                    RequiredExp=120,
                       GameItems = new ObservableCollection<GameItem>
                {
                    GameItemById(3001)
                },
                         Npcs = new ObservableCollection<NPC>()
                {
                    NpcById(5002),
                    NpcById(5005)
                }

                };
                gameMap.MapLocations[2, 3] = new Location()
                {
                    Id = 6,
                    Name = "Galorian Mines",
                    Description = "the planet Galoria is not an ideal vacation place. it is rich with plantinium which is used for just about everything.",
                    Accessible = false,
                    ModifiyExperiencePoints = 60,
                    Message = "the TeleShift device I found seemed to have malfunctioned and took me here and immediatly met by the Galorian supervisor to work in the mines. Look there are the missing people!",
                    ImageFileName = "mines.jpg",
                    RequiredClueId=1003,
                      Npcs = new ObservableCollection<NPC>()
                {
                    NpcById(5004),
                    NpcById(5030)
                }
                };


                return gameMap;
            };


        }

        public static List<GameItem> StandardGameItems()
        {

            return new List<GameItem>()
                {
                    new Weapon(2001, "Colt .8 snubnose blaster", 600, 1,12,6, "a laser blaster created to look like a classic snubnose revolver.",0),
                    new Weapon (2002, "phaseball bat", 15, 1,6,0,"the bat used for a traditional all-american sport.",0),
                    new Weapon(2003, "fists", 0,0,4,0, "good ol' fashion put em up dukes",0),
                    new MediPack(3001, "Vape sticks",10, 10,0,"a pack of disposable vape sticks. comes in a pack of 10.",0),
                    new MediPack(3002, "glass of scotch",4, 25,0,"a nice smooth glass of scotch.",0),
                    new MediPack(3003, "bottle of scotch", 60,75,1,"a nice bottle of scotch is always a nice bonus.",0),
                    new Currency(4001, "credits",10,Currency.CurrencyType.Credits,"U.S. credits, paper bills are obscolete. pennies are all over the place still.",0),
                    new Clues(1001,"matchbook",0,"a souvenier matchbook replica from Joey's bar. there is a word written on the back. \"glorgan\"",5,
                    "this has the word \"Glorgan\" written on the back of it. could be a password of some sort. maybe someone at Joey's Club might know something about that word. one thing's for sure, this girl hung out with a bad crowd. " +
                    "\n\n{Gambler's Den Unlocked}",Clues.UseActionType.OPENLOCATION),
                    new Clues(1002, "Employee ID card",0,"an employee ID card from the Teleshift Industries factory",10,
                    "One of these thugs works at the TeleShift Factory. it might just be a coincidence, but in my line of work, " +
                    "there ar no coincednces. \n\n{TeleShift Factory Unlocked}",Clues.UseActionType.OPENLOCATION),
                    new Clues(1003, "TeleShift Device",3000,"a super new device used to teleport. many people are skeptical.",40,
                    "the TeleShift device I found seemed to have malfunctioned and took me here and immediatly met by the xantorian supervisor to work in the mines. Look there are the missing people!",Clues.UseActionType.MOVEPLAYER)



                };
        }
        public static List<NPC> Npcs()
        {
            return new List<NPC>()
            {
                new Foe()
                {
                    Id = 5001,
                    Name = "Gambler Thug",
                    Race = Character.RaceType.Human,
                    Health = 25,
                    Description = "A no-good rough and tough thug.",
                    Messages = new List<string>()
                    {
                        "you stepped into the wrong turf grandpa.",
                        "You ain't leavin without a fight.",
                        "come on old man. put them dukes up."
                    },
                   SkillLevel = 1,
                   CurrentWeapon = GameItemById(2003) as Weapon
                },
                                new Foe()
                {
                    Id = 5002,
                    Name = "TeleShift Henchman",
                    Health = 25,
                    Race = Character.RaceType.Human,
                    Description = "A no-good rough and tough thug.",
                    Messages = new List<string>()
                    {
                       
                        "You ain't leavin without a fight.",
                        "come on old man. put them dukes up."
                    },
                   SkillLevel = 1,
                   CurrentWeapon = GameItemById(2003) as Weapon,
                   Loot=GameItemById(3002)
                },
                new Foe()
                {
                    Id=5003,
                    Name = "Bobby Toloppi",
                    Health=50,
                    Race = Character.RaceType.Galorian,
                    Description = "this guy means business. seems to be the leader of the pack.",
                    Messages = new List<string>()
                    {
                        "I ain't tellin you nothin.",
                        "the investagation stops here bub.",

                    },
                    SkillLevel=3,
                    CurrentWeapon= GameItemById(2002) as Weapon,
                    Loot= GameItemById(1002),
                    

                },
                new Foe()
                {
                    Id=5004,
                    Name="the Boss",
                    Health=75,
                  
             
                    Race = Character.RaceType.Galorian,
                    Description="He's the brains behind this whole operation.",
                    Messages = new List<string>()
                    {
                        "bring it.",
                        "you can't stop me! I'm too Powerful!",
                        "Quit talking and starting fighting! I'm not gonna give you an evil monologue!"
                       
                    },
                    SkillLevel=4,
                    CurrentWeapon = GameItemById(2002) as Weapon
                },
                new Foe()
                {
                    Id=5005,
                    Name="Stephen Malarchy",
                    Health=60,
                    Race= Character.RaceType.Android,
                    Description="He seems like he knows a little too much",
                    Messages = new List<string>()
                    {
                        "Just walk away now, and we won't kill ya",
                        "drop the investigation old man. It's not gonna end well."
                    },
                    SkillLevel=3,
                    CurrentWeapon = GameItemById(2003) as Weapon,
                    Loot=GameItemById(1003)
                    
                },
                new Friend()
                {
                    Id = 5010,
                    Name = "Veronicka Florentine",
                    Race = Character.RaceType.Human,
                    Description = "A small sized young women who seems upset and unsure",
                    Messages = new List<string>()
                    {
                        "My sister Lori went missing yesterday. the police won't do anything. she just bought a new TeleShift device to transport to work and never showed up.",
                        "I'll pay you hansomely.",
                        "Her apartment is on the east side of town."
                    }
                },

                new Friend()
                {
                    Id = 5020,
                    Name = "Joey",
                    Race = Character.RaceType.Android,
                    Description = "a great bartender and a greater informer. he's been my go to guy for as long as I can remember",
                    Messages = new List<string>()
                    {
                        "hey bud. try not to start no toruble tonight alright?",
                        "what you wanna drink or somethin?",
                        "yea I think I remember that girl. she used to come in here and just order milk. I think she lives over on the east side of town."
                    }
                },

                new Friend()
                {
                   Id=5030,
                   Name="Lori Florentine",
                   Race = Character.RaceType.Human,
                   Description = "a beuatiful women who seems like she doesn't belong in this place.",
                   Messages = new List<string>()
                   {
                       "I can't belive you found me mister!",
                       "Please help mister!"
                      
                   }
                }
            };
        }
        }





    }

