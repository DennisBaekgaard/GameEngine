using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CharAttribute
    {
        #region Fields
        private EnumAttributeType type;
        private int current;
        private int max;
        #endregion

        #region Constructors
        public CharAttribute(EnumAttributeType type)
        {
            this.type = type;
            this.max = 0;
            this.current = this.max;
        }

        public CharAttribute(EnumAttributeType type, int value)
        {
            this.type = type;
            this.current = value;
            this.max = value;
        }
        #endregion

        #region Properties

        public int MaxVal
        {
            get { return max; }
            set { max = value; }
        }

        public EnumAttributeType Type
        {
            get { return type; }
        }

        public int Current
        {
            get { return current; }
            set { current = value; }
        }
        #endregion

    }

    public enum EnumAttributeType
    {
        STRENGTH,
        AGILITY,
        INTELLIGENCE,
        HEALTH,
        TURNPOINTS,
        ATTACKDAMAGE,
        ARMOR,
    }
}
