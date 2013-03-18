using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class Character
  {
    public AI CharAI;
    public CharacterBase CharBase;
    public Character(CharacterBase CharBase = null, AI CharAI = null)
    {
      if (CharBase != null)
        this.CharBase = CharBase;
      else
      {
        this.CharBase = new CharacterBase();
        this.CharBase.Name = "Unknown Character";
      }
      if (CharAI != null) this.CharAI = CharAI;
      //TODO [CharAI]: look into possible safety issues
    }

  }
}
