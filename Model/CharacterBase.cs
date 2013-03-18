using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{  
    public class CharacterBase
    {
        public List<Ability> Abilities = new List<Ability>();
        public List<Ability> Buffs = new List<Ability>();
        private bool alive = true;
        public bool Alive { get { return alive; } set { alive = value; } }
        public int Team { get; set; }
        public string Name { get; set; }
        public CharAttribute Health { get; set; }
        public CharAttribute TurnPoints { get; set; }

        public CharacterBase() { }

    }


}
