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
        private int _wealth;

   
        private List<Location> _locationsVisited;
        private ObservableCollection<GameItem> _inventory;
        private ObservableCollection<GameItem> _mediPack;
        private ObservableCollection<GameItem> _currency;
        private ObservableCollection<GameItem> _weapons;
        private ObservableCollection<GameItem> _clues;

        #endregion

        #region PROPERTIES
     public int Wealth
        {
            get { return _wealth; }
            set { _wealth = value; }
        }

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

        public ObservableCollection<GameItem> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

        public ObservableCollection<GameItem> Weapons
        {
            get { return _weapons; }
            set { _weapons = value; }
        }

        public ObservableCollection<GameItem> MediPack
        {
            get { return _mediPack; }
            set { _mediPack = value; }
        }

        public ObservableCollection<GameItem> Currency
        {
            get { return _currency; }
            set { _currency = value; }
        }

        public ObservableCollection<GameItem> Clue
        {
            get { return _clues; }
            set { _clues = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Player()
        {
            _locationsVisited = new List<Location>();
            _weapons = new ObservableCollection<GameItem>();
            _mediPack = new ObservableCollection<GameItem>();
            _clues = new ObservableCollection<GameItem>();
            _currency = new ObservableCollection<GameItem>();
        }

        #endregion

        #region METHODS

        public bool HasVisited(Location location)
        {
            return _locationsVisited.Contains(location);
        }

        public void CalculateWealth()
        {
            Wealth = _inventory.Sum(i => i.Value);
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

        public void UpdateInventoryCategories()
        {
            MediPack.Clear();
            Weapons.Clear();
            Currency.Clear();
            Clue.Clear();

            foreach (var gameItem in _inventory)
            {
                if (gameItem is MediPack) MediPack.Add(gameItem);
                if (gameItem is Weapon) Weapons.Add(gameItem);
                if (gameItem is Currency) Currency.Add(gameItem);
                if (gameItem is Clues) Clue.Add(gameItem);
            }
        }
      
        
        public void AddGameItemToInventory(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _inventory.Add(selectedGameItem);
            }
        }

       
        public void RemoveGameItemFromInventory(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _inventory.Remove(selectedGameItem);
            }
        }


        #endregion

    }
}
