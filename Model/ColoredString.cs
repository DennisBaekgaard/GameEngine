using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Model
{
  public class ColoredString
  {
    public Color color { get; private set; }
    public string text { get; private set; }

    public ColoredString(Color color, string text)
    {
      this.color = color;
      this.text = text;
    }

    public static ColoredString CharacterName(Character Char)
    {
      Color charColor;
      switch (Char.CharBase.Team)
      {
        case 1:
          charColor = Color.Red;
          break;
        case 2:
          charColor = Color.Blue;
          break;
        default:
          charColor = Color.Black;
          break;
      }
      return new ColoredString(charColor, Char.CharBase.Name);
    }

    public static ColoredString Element(EnumElement element)
    {
      Color elementColor;

      switch (element)
      {
        case EnumElement.COLD:
          elementColor = Color.DarkBlue;
          break;
        case EnumElement.FIRE:
          elementColor = Color.Blue;
          break;
        case EnumElement.HOLY:
          elementColor = Color.LightGoldenrodYellow;
          break;
        case EnumElement.LIGHTNING:
          elementColor = Color.Yellow;
          break;
        case EnumElement.PHYSICAL:
          elementColor = Color.Gray;
          break;
        case EnumElement.POISON:
          elementColor = Color.Green;
          break;
        case EnumElement.UNHOLY:
          elementColor = Color.Purple;
          break;
        default:
          elementColor = Color.Black;
          break;
      }
      return new ColoredString(elementColor, element.ToString());
    }

    public static ColoredString Ability(Ability ability)
    {
      Color elementColor;

      switch (ability.element)
      {
        case EnumElement.COLD:
          elementColor = Color.DarkBlue;
          break;
        case EnumElement.FIRE:
          elementColor = Color.Blue;
          break;
        case EnumElement.HOLY:
          elementColor = Color.LightGoldenrodYellow;
          break;
        case EnumElement.LIGHTNING:
          elementColor = Color.Yellow;
          break;
        case EnumElement.PHYSICAL:
          elementColor = Color.Gray;
          break;
        case EnumElement.POISON:
          elementColor = Color.Green;
          break;
        case EnumElement.UNHOLY:
          elementColor = Color.Purple;
          break;
        default:
          elementColor = Color.Black;
          break;
      }
      return new ColoredString(elementColor, ability.Name);
    }

  }
}
