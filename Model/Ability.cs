using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Ability
    {
        public string Name;
        public int Cost { get; private set; }
        public int Damage { get; private set; }

        private EnumAbilityStrength abilityStrength;
        public EnumElement element { get; private set; }
        private EnumAbilityType abilityType;
        private EnumTargets targets;
        private EnumTargetModifier targetModifier;
        private EnumDuration duration;
        public EnumBuffType buffType { get; private set; }

        public int RoundsLeft { get; private set; }

        public delegate void AbilityEventHandler(object sender, AbilityEventArgs args);
        public event AbilityEventHandler OnAbilityFired;

        public Ability(string Name, EnumAbilityStrength abilityStrength, EnumElement element, EnumAbilityType abilityType, EnumTargets targets, EnumTargetModifier targetModifier, EnumDuration duration)
        {
            this.Name = Name;
            this.abilityStrength = abilityStrength;
            this.element = element;
            this.abilityType = abilityType;
            this.targets = targets;
            this.targetModifier = targetModifier;
            this.duration = duration;
            this.RoundsLeft = (int)duration;

            Cost = (int)abilityStrength + 1 +
                   (abilityType == EnumAbilityType.HEAL ? 2 : 1) +
                   (int)targets + 1 +
                   (targetModifier == EnumTargetModifier.RANDOM ? 1 : 2) +
                   (int)duration;

            Damage = 10 * (int)abilityStrength;
        }

        public Ability(string Name, EnumAbilityStrength abilityStrength, EnumElement element, EnumAbilityType abilityType, EnumTargets targets, EnumTargetModifier targetModifier, EnumDuration duration, EnumBuffType buffType)
        {
            this.Name = Name;
            this.abilityStrength = abilityStrength;
            this.element = element;
            this.abilityType = abilityType;
            this.targets = targets;
            this.targetModifier = targetModifier;
            this.duration = duration;
            this.RoundsLeft = (int)duration;
            this.buffType = buffType;

            Cost = (int)abilityStrength + 1 +
           (abilityType == EnumAbilityType.HEAL ? 2 : 1) +
           (int)targets + 1 +
           (targetModifier == EnumTargetModifier.RANDOM ? 1 : 2) +
           (int)duration;

            Damage = 10 * (int)abilityStrength;
        }

        /// <summary>
        /// Uses an ability.
        /// </summary>
        /// <param name="Source">The Character who uses the ability.</param>
        /// <param name="Target">The Character that is the target of the ability.</param>
        public void Use(Character Source, List<Character> Targets)
        {
            OnAbilityFired(this, new AbilityEventArgs(Source, Targets, this));
        }

        protected int Iterate()
        {
            RoundsLeft--;

            return Damage / (int)duration;
        }

        public int BuffModify(int damage, EnumElement element)
        {
            if (element == this.element)
                if (this.buffType == EnumBuffType.DAMAGE)
                    return (int)(damage * (double)abilityStrength);
                else
                    return (int)(damage / (double)abilityStrength);
            else
                return damage;
        }


    }

    public class AbilityEventArgs : EventArgs
    {
        public Character Source { get; private set; }
        public List<Character> Targets { get; private set; }
        public Ability Ability { get; private set; }

        public AbilityEventArgs(Character source, List<Character> targets, Ability ability)
        {
            this.Source = source;
            this.Targets = targets;
            this.Ability = ability;
        }
    }
}
