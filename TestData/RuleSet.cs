using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace TestData
{
    class RuleSet : Rules
    {
        public RuleSet()
        {
            Scale = 2;
            AllowedTurnPoints = 100;
        }
    }
}
