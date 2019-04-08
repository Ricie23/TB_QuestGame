using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame.Models
{
    public class Currency : GameItem
    {
        public enum CurrencyType
        {
            Credits,
            Cash

        }

        public CurrencyType Type { get; set; }

        public Currency(int id, string name, int value, CurrencyType type, string description, int experiencePoints)
            : base(id, name, value, description, experiencePoints)
        {
            Type = type;
        }

        public override string InformationString()
        {
            return $"{Name}: {Description}\nValue: {Value}";
        }
    }
}
