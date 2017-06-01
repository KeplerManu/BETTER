using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using BETTER.DataAccessLayer.Classes;
using System.Data.SqlClient;
using System.Configuration;

namespace BETTER.BusinessLayer.Classes
{
    public class BattleManager
    {
        TitanManager tm = new TitanManager();
        EnemyTitanManager etm = new EnemyTitanManager();

        public int coinFlip()
        {
            int _min = 0;
            int _max = 1;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }

        public int ChallengerPoints(string TitanName, string battler1element, string battler2element)
        {
            int titanXP = tm.GetTitanExperience(TitanName);
            int elementalAdvantage = ElementalAdvantage(battler1element, battler2element);
            int challenger = Convert.ToInt32(1.25);
            if (coinFlip() == 1)
            {
                int random = Convert.ToInt32(1.25);
                int challengerPoints = Convert.ToInt32(Math.Round(Convert.ToDecimal(titanXP * elementalAdvantage * challenger * random), 0));
                return challengerPoints;
            }
            else
            {
                int random = 1;
                int challengerPoints = Convert.ToInt32(Math.Round(Convert.ToDecimal(titanXP * elementalAdvantage * challenger * random), 0));
                return challengerPoints;
            }
        }

        public int DefenderPoints(string TitanName, string battler1element, string battler2element)
        {
            int titanXP = etm.GetEnemyTitanExperience(TitanName);
            int elementalAdvantage = ElementalAdvantage(battler1element, battler2element);
            if (coinFlip() == 1)
            {
                int random = Convert.ToInt32(1.25);
                int defenderPoints = Convert.ToInt32(Math.Round(Convert.ToDecimal(titanXP * elementalAdvantage * random), 0));
                return defenderPoints;
            }
            else
            {
                int random = 1;
                int defenderPoints = Convert.ToInt32(Math.Round(Convert.ToDecimal(titanXP * elementalAdvantage * random), 0));
                return defenderPoints;
            }
        }

        public string BattleOutcome(string ChallengerName, string DefenderName, string ChallengerElement, string DefenderElement)
        {
            var challengerPoints = ChallengerPoints(ChallengerName, ChallengerElement, DefenderElement);
            var defenderPoints = DefenderPoints(DefenderName, DefenderElement, ChallengerElement);
            if (challengerPoints > defenderPoints)
            {
                return "win";
            }
            else if (challengerPoints < defenderPoints)
            {
                return "loss";
            }
            else
            {
                return "draw";
            }
        }


        public int ElementalAdvantage(string battler1element, string battler2element)
        {
            int advantage = Convert.ToInt32(1.15);
            int noAdvantage = Convert.ToInt32(1);
            if (ElementalAdvantageWater(battler1element, battler2element) == true)
            {
                return advantage;
            }
            else if (ElementalAdvantageFire(battler1element, battler2element) == true)
            {
                return advantage;
            }
            else if (ElementalAdvantageAir(battler1element, battler2element) == true)
            {
                return advantage;
            }
            else if (ElementalAdvantageEarth(battler1element, battler2element) == true)
            {
                return advantage;
            }
            return noAdvantage;
        }

        public bool ElementalAdvantageWater(string battler1element, string battler2element)
        {
            if (battler1element == "Water" && battler2element == "Fire")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ElementalAdvantageFire(string battler1element, string battler2element)
        {
            if (battler1element == "Fire" && battler2element == "Air")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ElementalAdvantageAir(string battler1element, string battler2element)
        {
            if (battler1element == "Air" && battler2element == "Earth")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ElementalAdvantageEarth(string battler1element, string battler2element)
        {
            if (battler1element == "Earth" && battler2element == "Water")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}