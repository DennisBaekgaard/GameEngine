using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public enum EnumElement
  {
    PHYSICAL,
    FIRE,
    COLD,
    LIGHTNING,
    POISON,
    HOLY,
    UNHOLY
  }

  public enum EnumAbilityType
  {
    DAMAGE,
    HEAL,
    BUFF
  }

  public enum EnumBuffType
  { 
    RESIST,
    DAMAGE
  }

  public enum EnumAbilityStrength
  { 
    LOW = 1,
    MEDIUM = 2,
    HIGH = 3
  }

  public enum EnumTargets
  { 
    ONE,
    TWO,
    THREE
  }

  public enum EnumTargetModifier
  { 
    SELECTABLE,
    RANDOM
  }

  public enum EnumDuration
  { 
    INSTANT,
    TWO_ROUNDS,
    THREE_ROUND
  }
}
