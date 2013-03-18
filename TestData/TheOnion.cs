using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace TestData
{
  /*public class CharBase : CharacterBase
  {


    public CharBase()
    {
      Name = "Far of the OnionField";
      Health = new CharAttribute(EnumAttributeType.HEALTH, 5);
      TurnPoints = new CharAttribute(EnumAttributeType.TURNPOINTS, 10);
      AttackDamage = new CharAttribute(EnumAttributeType.ATTACKDAMAGE, 1);
      Team = 2;
      Alive = true;
    }

  }

  public class CharAI : AI
  {

    public CharAI()
    {
    }

    public override Tuple<Character, Character, AIAction> DoTurn(List<Character> currentCharacters)
    {
      Character me = currentCharacters.Where(x => x.CharAI.Equals(this)).First();

      Character target = me;

      foreach (Character a in currentCharacters)
        if (a.CharBase.Team != me.CharBase.Team)
          if (a.CharBase.Alive)
            target = a;



      return new Tuple<Character, Character, AIAction>(me, target, new AIAction());
    }
  }*/
}
