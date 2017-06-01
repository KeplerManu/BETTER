using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BETTER.DataAccessLayer.Classes;

namespace BETTER.BusinessLayer.Classes
{
    public class Battle
    {

        public string battler1 { get; set; }

        public string battler2 { get; set; }

        public bool battleWinner { get; set; }

        public void AddBattle()
        {
            BattleDAL obj = new BattleDAL();
            obj.AddBattle(battler1, battler2, battleWinner);
        }

    }
}