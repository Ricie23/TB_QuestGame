using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TB_QuestGame.Models
{
    public class Player : Character
    {
        #region ENUMS

        #endregion

        #region FIELDS

        private int _health;
        private int _lives;
        private int _xp;
        private List<Location> _locationsVisited;
        private ObservableCollection<GameItemQuantity> _inventory;
        private ObservableCollection<GameItemQuantity> _mediPack;
        private ObservableCollection<GameItemQuantity> _currency;
        private ObservableCollection<GameItemQuantity> _weapons;
        private ObservableCollection<GameItemQuantity> _clues;

        #endregion

        #region PROPERTIES

        public int Health
        {
            get { return _health; }
            set
            {
                _health = value;
                OnPropertyChanged(nameof(Health));
            }

        }

        public int Lives
        {
            get { return _lives; }
            set
            {
                _lives = value;
                OnPropertyChanged(nameof(Lives));
            }
        }

        public int ExpierencePoints
        {
            get { return _xp; }
            set
            {
                _xp = value;
                OnPropertyChanged(nameof(ExpierencePoints));
            }

        }

        public List<Location> LocationsVisited
        {
            get { return _locationsVisited; }
            set { _locationsVisited = value; }
        }

        public ObservableCollection<GameItemQuantity> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

        public ObservableCollection<GameItemQuantity> Weapons
        {
            get { return _weapons; }
            set { _weapons = value; }
        }

        public ObservableCollection<GameItemQuantity> MediPack
        {
            get { return _mediPack; }
            set { _mediPack = value; }
        }

        public ObservableCollection<GameItemQuantity> Currency
        {
            get { return _currency; }
            set { _currency = value; }
        }

        public ObservableCollection<GameItemQuantity> Clue
        {
            get { return _clues; }
            set { _clues = value; }
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
