using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame.Models
{
    public class Player:Character
    {
        #region ENUMS
       
        #endregion

        #region FIELDS
        
        private int _health;
        private int _lives;
        private int _xp;
        private List<Location> _locationsVisited;
        #endregion

        #region PROPERTIES

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
        public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }
        public int ExpierencePoints
        {
            get { return _xp; }
            set { _xp = value;
                OnPropertyChanged(nameof(ExpierencePoints));
            }

        }
        public List<Location> LocationsVisited
        {
            get { return _locationsVisited; }
            set { _locationsVisited = value; }
        }
        #endregion

        #region CONSTRUCTORS
        public Player()
        {
            _locationsVisited = new List<Location>();
        }
        #endregion

        #region METHODS

        public bool HasVisited(Location location)
        {
            return _locationsVisited.Contains(location);
        }


        public override string DefaultGreeting()
        {
            string article = "a";

            List<string> vowels = new List<string>() { "A", "E", "I", "O", "U" };

            if (vowels.Contains(_race.ToString().Substring(0, 1)))
            {
                article = "an";
            }

            return $"My Name's Detective {_name} and I'm {article} {Race}.";
        }
        #endregion

    }
}
