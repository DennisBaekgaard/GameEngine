using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using Model;

namespace DLLLoader
{
    public class Loader
    {


        /// <summary>
        /// Constructor
        /// </summary>
        public Loader()
        {
        }

        public static Rules LoadRuleset(string Path)
        {
          //put instance of dll's class into list
          var dll = Assembly.LoadFile(Path);

          //locate CharacterBase and AI
          var rulesType = dll.GetTypes().Where(t => t.BaseType == typeof(Rules)).ToArray();

          //get AI
          ConstructorInfo RulesConstructor = null;
          if (rulesType.Length > 0)
            RulesConstructor = rulesType[0].GetConstructor(new Type[] { });
          Rules currentRules = null;
          if (RulesConstructor != null) currentRules = RulesConstructor.Invoke(null) as Rules;

          //join and return
          return currentRules;
        }

        /// <summary>
        /// Loads Characters from @"..\Characters" folder.
        /// </summary>
        /// <returns>Returns list of Characters with AI's, empty list if folder doesn't exist.</returns>
        public static Character LoadCharacter(string Path)
        {
            //put instance of dll's class into list
            var dll = Assembly.LoadFile(Path);

            //locate CharacterBase and AI
            var characterTypes = dll.GetTypes().Where(t => t.BaseType == typeof(CharacterBase)).ToArray();
            var AITypes = dll.GetTypes().Where(t => t.BaseType == typeof(AI)).ToArray();

            //get CharacterBase
            ConstructorInfo charConstructor = null;
            if (characterTypes.Length > 0)
                charConstructor = characterTypes[0].GetConstructor(new Type[] { });
            CharacterBase currentCharacterBase = null;
            if (charConstructor != null) currentCharacterBase = charConstructor.Invoke(null) as CharacterBase;

            //get AI
            ConstructorInfo AIConstructor = null;
            if (AITypes.Length > 0)
                AIConstructor = AITypes[0].GetConstructor(new Type[] { });
            AI currentAI = null;
            if (AIConstructor != null) currentAI = AIConstructor.Invoke(null) as AI;

            //join and return
            return new Character(currentCharacterBase, currentAI);
        }
    }
}

