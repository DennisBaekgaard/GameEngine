using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace TestData
{
   /* public class CharBase : CharacterBase
    {
        public CharBase()
        {
            Name = "Wizard of the North";
            Health = new CharAttribute(EnumAttributeType.HEALTH, 10);
            TurnPoints = new CharAttribute(EnumAttributeType.TURNPOINTS, 10);
            Team = 1;
            Alive = true;
        }
    }

    public class CharAI : AI
    {

        //TODO: AI'en kører sit script, og vælger hvad
        //TODO: Tilføj en buffer til at styre debuff/buff - (lav en dictionary<Ability=den buff/debuff der er, int = mængde af ture den virker>. 
        //TODO: En AI kører sit script, hvor den vælger hvad den vil bruge. F.eks. Poition.Use() - Use i potion.cs : Ability fortæller hvad lige præcis den ability gør. AI'en sender én request til 
        //enginen om hvad den gerne vil gøre, f.eks Potion.Use(), MeleeAttack.Use(), Heal.Use() - Man kan kun køre én ting pr. tur.

        public CharAI()
        {
        }



        public override Tuple<Character, Character, Ability> DoTurn(List<Character> currentCharacters)
        {
            Character me;
            

            
            if (currentCharacters.Where(x => x.CharAI.Equals(this)).FirstOrDefault() != null)
            {
                me = currentCharacters.Where(x => x.CharAI.Equals(this)).FirstOrDefault();
            }
            else
            {
                throw new Exception("Something went very wrong. I dont exist :(");
            }
            Ability ability = null;
            List<Character> possibleTargets;
            Character target = null;

            //Find targets
            possibleTargets = currentCharacters.Where(x => x.CharBase.Team == me.CharBase.Team && x.CharBase.Health.Current < x.CharBase.Health.MaxVal).ToList();

            if (possibleTargets.Count > 0)
            {
                possibleTargets = sortAccordingToHealth(possibleTargets);
                target = possibleTargets.First();//Todefault

                

            }
            else
            {
                possibleTargets = currentCharacters.Where(x => x.CharBase.Team != me.CharBase.Team).ToList();
                possibleTargets = sortAccordingToHealth(possibleTargets);

                if (possibleTargets.Count > 0)
                    target = possibleTargets.FirstOrDefault();
                else
                    throw new Exception("The engine should not be able to run without another team present.");

                

            }


            return new Tuple<Character, Character, Ability>(me, target, ability);
        }

        /// <summary>
        /// Sorts a list of characters according to the life they have. Sorts in ascending order.
        /// </summary>
        /// <param name="list">Lists of characters</param>
        /// <returns>sorted list of characters</returns>
        private List<Character> sortAccordingToHealth(List<Character> list)
        {
            list.Sort((Character char1, Character char2) => char1.CharBase.Health.Current.CompareTo(char2.CharBase.Health.Current));

            return list;
        }
    }*/
}
