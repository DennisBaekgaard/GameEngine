using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class AI
    {
     
      public AI()
      {
      }

      public abstract void DoTurn(List<Character> currentCharacters);
    }
}
