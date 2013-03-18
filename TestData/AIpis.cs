using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace TestData
{
    public class Stats : CharacterBase
    {
        public Stats()
        {
            Name = "Barb";
            Health = new CharAttribute(EnumAttributeType.HEALTH, 200);
            TurnPoints = new CharAttribute(EnumAttributeType.TURNPOINTS, 20);
            Team = 2;
            Abilities.Add(new Ability("Shoot", EnumAbilityStrength.LOW, EnumElement.PHYSICAL, EnumAbilityType.DAMAGE, EnumTargets.ONE, EnumTargetModifier.SELECTABLE, EnumDuration.INSTANT));
            Abilities.Add(new Ability("SplitShot", EnumAbilityStrength.LOW, EnumElement.PHYSICAL, EnumAbilityType.DAMAGE, EnumTargets.TWO, EnumTargetModifier.SELECTABLE, EnumDuration.INSTANT));
            Abilities.Add(new Ability("ExplosiveShot", EnumAbilityStrength.MEDIUM, EnumElement.FIRE, EnumAbilityType.DAMAGE, EnumTargets.TWO, EnumTargetModifier.SELECTABLE, EnumDuration.INSTANT));
            Abilities.Add(new Ability("MegaFuckinBootInYourAssShot", EnumAbilityStrength.HIGH, EnumElement.PHYSICAL, EnumAbilityType.DAMAGE, EnumTargets.ONE, EnumTargetModifier.SELECTABLE, EnumDuration.INSTANT));
            Abilities.Add(new Ability("TakeCover", EnumAbilityStrength.LOW, EnumElement.PHYSICAL, EnumAbilityType.BUFF, EnumTargets.ONE, EnumTargetModifier.SELECTABLE, EnumDuration.THREE_ROUND, EnumBuffType.RESIST));
        }
    }

    public class Ranger : AI
    {
        Character Self;
        List<Character> listOfCharacters;

        //Custom "globals"
        Character FocusTarget;
        Character SecondaryTarget = null;

        public Ranger()
        { }

        /// <summary>
        /// Gets the self identifier
        /// </summary>
        /// <param name="currentCharacters"></param>
        /// <returns></returns>
        public override void DoTurn(List<Character> currentCharacters)
        {
            listOfCharacters = currentCharacters;
            GetSelf();

            //1
            GetEnemies();

            //2
            DoMainAttacks();
        }

        private void GetSelf()
        {
            //Get me
            if (listOfCharacters.Where(x => x.CharAI.Equals(this)).FirstOrDefault() != null)
            {
                Self = listOfCharacters.Where(x => x.CharAI.Equals(this)).FirstOrDefault();
            }
            else
            {
                throw new Exception("Something went very wrong. I dont exist :(");
            }
        }

        //1
        private void GetEnemies()
        {
            listOfCharacters.Sort((Character char1, Character char2) => char1.CharBase.Health.Current.CompareTo(char2.CharBase.Health.Current));

            //Implementation of the loop structure in our own language
            if (FocusTarget == null)
            {
                FocusTarget = listOfCharacters.Where(x => x.CharBase.Team != Self.CharBase.Team).FirstOrDefault();
            }
            
            if(SecondaryTarget == null)
            {
                SecondaryTarget = listOfCharacters.Where(x => x.CharBase.Team != Self.CharBase.Team && x != FocusTarget).FirstOrDefault();
                
                if (SecondaryTarget == null)
                    SecondaryTarget = FocusTarget;
            }
        }

        //Simple
        /*private void DoMainAttacks()
        {
            if (FocusTarget.CharBase.Health.Current > 50 && Self.CharBase.TurnPoints.Current > 10)
                Self.CharBase.Abilities[3].Use(Self, new List<Character>() { FocusTarget });
            else
                Self.CharBase.Abilities[0].Use(Self, new List<Character>() { FocusTarget });
                
        }*/

        //2
        private void DoMainAttacks()
        {
            if (FocusTarget.CharBase.Health.Current > 500 && Self.CharBase.TurnPoints.Current > 10)
                Self.CharBase.Abilities[3].Use(Self, new List<Character>() { FocusTarget });

            for (int i = 0; true; i++)
            {
                if (!(FocusTarget.CharBase.Alive && SecondaryTarget.CharBase.Alive && Self.CharBase.TurnPoints.Current > 2))
                    break;

                Self.CharBase.Abilities[2].Use(Self, new List<Character>() { FocusTarget, SecondaryTarget });
            }

            if (FocusTarget.CharBase.Alive && SecondaryTarget.CharBase.Alive && Self.CharBase.TurnPoints.Current == 2)
                Self.CharBase.Abilities[1].Use(Self, new List<Character> { FocusTarget, SecondaryTarget });

            for (int i = 0; true; i++)
            {
                if (!(Self.CharBase.TurnPoints.Current > 0))
                    break;

                if (FocusTarget.CharBase.Alive)
                    Self.CharBase.Abilities[0].Use(Self, new List<Character>() { FocusTarget });
                else if (SecondaryTarget.CharBase.Alive)
                    Self.CharBase.Abilities[0].Use(Self, new List<Character>() { SecondaryTarget });
                else
                    Self.CharBase.Abilities[4].Use(Self, new List<Character>() { Self });
            }
        }
    }
}
