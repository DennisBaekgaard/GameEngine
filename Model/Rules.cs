using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Rules
    {
        private int allowedTurnPoints;
        private int scale;
        private const int baseCost = 10;

        public int AllowedTurnPoints
        {
            get { return allowedTurnPoints; }
            set { allowedTurnPoints = value; }
        }

        public int Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        public int BaseCost
        {
            get { return baseCost; }
        }


        public Tuple<bool, string> IsCharacterIllegal(Character c)
        {
            if (c.CharBase.TurnPoints.MaxVal > allowedTurnPoints)
                return new Tuple<bool, string>(true, "The character " + c.CharBase.Name + " was illegal. The maximum allowed amount of turn points is " + allowedTurnPoints.ToString() + " the character had " + c.CharBase.TurnPoints.ToString() + ".");
            else if (c.CharBase.Health.MaxVal > 100 * scale)
                return new Tuple<bool, string>(true, "The character " + c.CharBase.Name + " was illegal. The maximum allowed amount of health points is " + (100*scale).ToString() + " the character had " + c.CharBase.Health.MaxVal.ToString() + ".");

            return new Tuple<bool, string>(false, "");
        }

        public Tuple<bool, Ability> IsAbilityIlligal(Character c)
        {

            foreach (Ability a in c.CharBase.Abilities)
            {
                if (a.Cost > baseCost * scale)
                    return new Tuple<bool, Ability>(true, a);
            }

            return new Tuple<bool,Ability>(false, null);
        }
    }
}
