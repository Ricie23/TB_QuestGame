﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TB_QuestGame.Models
{
    public class Location : ObservableObject
    {
        #region FIELDS

        private int _id;
        private string _name;
        private string _description;
        private bool _accessible;
        private int _exp;
        private int _requiredExp;
        private int _modifiyExperiencePoints;
        private int _modifyHealth;
        private int _modifyLives;
        private string _message;
        private string _imageFileName;
        private int _requiredClueId;
        private ObservableCollection<GameItemQuantity> _gameItems;




        #endregion
        #region PROPERTIES

        public ObservableCollection<GameItemQuantity> GameItems
        {
            get { return _gameItems; }
            set { _gameItems = value; }
        }

        public int RequiredClueId
        {
            get { return _requiredClueId; }
            set { _requiredClueId = value; }
        }

        public string ImageFileName
        {
            get { return _imageFileName; }
            set { _imageFileName = value; }
        }

        public string ImageFilePath
        {
            get { return @"../Images/" + _imageFileName; }
        }

        public int ModifiyExperiencePoints
        {
            get { return _modifiyExperiencePoints; }
            set { _modifiyExperiencePoints = value; }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public int ModifyHealth
        {
            get { return _modifyHealth; }
            set
            {
                _modifyHealth = value;

            }
        }

        public int ModifyLives
        {
            get { return _modifyLives; }
            set { _modifyLives = value; }
        }

        public bool Accessible
        {
            get { return _accessible; }
            set { _accessible = value; }
        }


        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public int RequiredExp
        {
            get { return _requiredExp; }
            set { _requiredExp = value; }
        }


        public int Exp
        {
            get { return _exp; }
            set
            {
                _exp = value;
                OnPropertyChanged(nameof(Exp));
            }
        }


        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        #endregion

        #region CONSTRUCTORS
        public Location()
        {
            _gameItems = new ObservableCollection<GameItemQuantity>();
        }
        #endregion

        #region METHODS

        public bool IsAccessibleByExperiencePoints(int playerExperiencePoints)
        {
            return playerExperiencePoints >= _requiredExp ? true : false;
        }

        #endregion
    }

}
