using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TB_QuestGame.Models;
using TB_QuestGame;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;

namespace TB_QuestGame.PresentationLayer
{
    public class GameSessionViewModel : ObservableObject
    {
        #region FIELDS

        private DateTime _gameStartTime;
        private Player _player;
        private Map _gameMap;
        private Location _currentLocation;
        private Location _northLocation, _eastLocation, _southLocation, _westLocation;
        private GameItem _currentGameItem;
        private string _currentLocationInformation;

        #endregion

        #region PROPERTIES 
        public GameItem CurrentGameItem
        {
            get { return _currentGameItem; }
            set { _currentGameItem = value; }
        }


        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }

        public string MessageDisplay
        {
            get { return _currentLocation.Message; }
        }

        public Map GameMap
        {
            get { return _gameMap; }
            set { _gameMap = value; }
        }

        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;
                OnPropertyChanged(nameof(CurrentLocation));
                _currentLocationInformation = _currentLocation.Description;
                OnPropertyChanged(nameof(CurrentLocationInformation));
            }
        }


        public Location NorthLocation
        {
            get { return _northLocation; }
            set
            {
                _northLocation = value;
                OnPropertyChanged(nameof(NorthLocation));
                OnPropertyChanged(nameof(HasNorthLocation));
            }
        }

        public Location EastLocation
        {
            get { return _eastLocation; }
            set
            {
                _eastLocation = value;
                OnPropertyChanged(nameof(EastLocation));
                OnPropertyChanged(nameof(HasEastLocation));
            }
        }

        public Location SouthLocation
        {
            get { return _southLocation; }
            set
            {
                _southLocation = value;
                OnPropertyChanged(nameof(SouthLocation));
                OnPropertyChanged(nameof(HasSouthLocation));
            }
        }

        public Location WestLocation
        {
            get { return _westLocation; }
            set
            {
                _westLocation = value;
                OnPropertyChanged(nameof(WestLocation));
                OnPropertyChanged(nameof(HasWestLocation));
            }
        }

        public string CurrentLocationInformation
        {
            get { return _currentLocationInformation; }
            set
            {
                _currentLocationInformation = value;
                OnPropertyChanged(nameof(CurrentLocationInformation));
            }
        }

        public bool HasNorthLocation
        {
            get
            {
                if (NorthLocation != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool HasEastLocation { get { return EastLocation != null; } }

        public bool HasSouthLocation { get { return SouthLocation != null; } }

        public bool HasWestLocation { get { return WestLocation != null; } }

        #endregion

        #region CONSTRUCTORS

        public GameSessionViewModel()
        {

        }

        public GameSessionViewModel(Player player, Map gameMap, GameMapCoordinates currentLocationCoordinates)
        {
            _player = player;
            _gameMap = gameMap;
            _gameMap.CurrentLocationCoordinates = currentLocationCoordinates;
            _currentLocation = _gameMap.CurrentLocation;

            InitializeView();
        }

        #endregion

        #region METHODS

        private void InitializeView()
        {
            _gameStartTime = DateTime.Now;
            UpdateAvailableTravelPoints();
            _player.UpdateInventoryCategories();
            _player.CalculateWealth();
            _currentLocationInformation = CurrentLocation.Description;

        }

        private TimeSpan GameTime()
        {
            return DateTime.Now - _gameStartTime;
        }

        private void UpdateAvailableTravelPoints()
        {
          
            NorthLocation = null;
            EastLocation = null;
            SouthLocation = null;
            WestLocation = null;

            if (_gameMap.NorthLocation(_player) != null)
            {
                NorthLocation = _gameMap.NorthLocation(_player);
            }

            if (_gameMap.EastLocation(_player) != null)
            {
                EastLocation = _gameMap.EastLocation(_player);
            }

            if (_gameMap.SouthLocation(_player) != null)
            {
                SouthLocation = _gameMap.SouthLocation(_player);
            }

            if (_gameMap.WestLocation(_player) != null)
            {
                WestLocation = _gameMap.WestLocation(_player);
            }
        }

        private void OnPlayerMove()
        {
           
            if (!_player.HasVisited(_currentLocation))
            {
                _player.LocationsVisited.Add(_currentLocation);

               
                _player.ExpierencePoints += _currentLocation.ModifiyExperiencePoints;

               
                if (_currentLocation.ModifyHealth != 0)
                {
                    _player.Health += _currentLocation.ModifyHealth;
                    if (_player.Health > 100)
                    {
                        _player.Health = 100;
                        _player.Lives++;
                    }
                }

                
                if (_currentLocation.ModifyLives != 0) _player.Lives += _currentLocation.ModifyLives;

                OnPropertyChanged(nameof(MessageDisplay));
            }
        }

        public void MoveNorth()
        {
            if (HasNorthLocation)
            {
                _gameMap.MoveNorth();
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                OnPlayerMove();
            }
        }

        public void MoveEast()
        {
            if (HasEastLocation)
            {
                _gameMap.MoveEast();
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                OnPlayerMove();
            }
        }

        public void MoveSouth()
        {
            if (HasSouthLocation)
            {
                _gameMap.MoveSouth();
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                OnPlayerMove();
            }
        }

        public void MoveWest()
        {
            if (HasWestLocation)
            {
                _gameMap.MoveWest();
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                OnPlayerMove();
            }
        }

        #endregion
        #region ACTION METHODS
        public void AddItemToInventory()
        {
            //
            // confirm a game item selected and is in current location
            // subtract from location and add to inventory
            //
            if (_currentGameItem != null && _currentLocation.GameItems.Contains(_currentGameItem))
            {
                //
                // cast selected game item 
                //
                GameItem selectedGameItem = _currentGameItem as GameItem;

                _currentLocation.RemoveGameItemFromLocation(selectedGameItem);
                _player.AddGameItemToInventory(selectedGameItem);

                OnPlayerPickUp(selectedGameItem);
            }
        }

        public void RemoveItemFromInventory()
        {
            //
            // confirm a game item selected and is in inventory
            // subtract from inventory and add to location
            //
            if (_currentGameItem != null)
            {
                //
                // cast selected game item 
                //
                GameItem selectedGameItem = _currentGameItem as GameItem;

                _currentLocation.AddGameItemToLocation(selectedGameItem);
                _player.RemoveGameItemFromInventory(selectedGameItem);

                OnPlayerPutDown(selectedGameItem);
            }
        }

        private void OnPlayerPickUp(GameItem gameItem)
        {
            _player.ExpierencePoints += gameItem.ExperiencePoints;
            _player.Wealth += gameItem.Value;
        }
   
        private void OnPlayerPutDown(GameItem gameItem)
        {
            _player.Wealth -= gameItem.Value;
        }
 

    public void OnUseGameItem()
    {
        switch (_currentGameItem)
        {
            case MediPack mediPack:
                ProcessMediPackUse(mediPack);
                break;
            case Clues clues:
                ProcessClueUse(clues);
                break;
            default:
                break;
        }
    }

        private void ProcessClueUse(Clues clues)
        {
            string message;

            switch (clues.UseAction)
            {
                case Clues.UseActionType.OPENLOCATION:
                    message = _gameMap.OpenLocationsByClue(clues.Id);
                    CurrentLocationInformation = clues.UseMessage;
                    break;
                case Clues.UseActionType.MOVEPLAYER:
                    
                    CurrentLocationInformation = clues.UseMessage;
                    break;
                default:
                    break;
            }
        }


        private void ProcessMediPackUse(MediPack mediPack)
        {
            _player.Health += mediPack.HealthChange;
            _player.Lives += mediPack.LivesChange;
            _player.RemoveGameItemFromInventory(_currentGameItem);
        }

        private void OnPlayerDies(string message)
        {
            string messagetext = message +
                "\n\nWould you like to play again?";

            string titleText = "Death";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(messagetext, titleText, button);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    ResetPlayer();
                    break;
                case MessageBoxResult.No:
                    QuiteApplication();
                    break;
            }
        }
        private void QuiteApplication()
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// player chooses to reset game
        /// </summary>
        private void ResetPlayer()
        {
            Environment.Exit(0);
        }
        #endregion


        #region EVENTS

        #endregion
    }
}
