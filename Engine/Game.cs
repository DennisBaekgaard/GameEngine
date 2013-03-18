#define DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Model;

namespace Engine
{
    public delegate void outputFunction(string Output);
    public delegate void cleverOutput(LogMessages outPut);

    public class Game
    {
        private Queue<Character> characterQueue;
        private List<Character> fullList;
        private outputFunction Output;
        private cleverOutput cleverOutput;
        private Rules rules;
        private LogMessages msg = new LogMessages();

        public Game(List<Character> fullList, outputFunction outputFunction, cleverOutput cleverOutputFunction, Rules rules)
        {
            this.fullList = fullList;
            this.characterQueue = initiateQueue();
            this.Output = outputFunction;
            this.cleverOutput = cleverOutputFunction;
            this.rules = rules;
        }

        /// <summary>
        /// Runs the main loop of the game. 
        /// It will run until one team is dead.
        /// </summary>
        public void Run()
        {
            Tuple<bool, string> characterCheck = IsCharacterOk(rules, fullList);
            Tuple<bool, string> abilityCheck = IsAbilityOk(rules, fullList);
            if (characterCheck.Item1 && abilityCheck.Item1)
            {
                Queue<Character> characterQueueTwo = new Queue<Character>();
                List<Character> teamOne, teamTwo;
                teamOne = characterQueue.Where(x => x.CharBase.Team == characterQueue.First().CharBase.Team).ToList();
                teamTwo = characterQueue.Where(x => x.CharBase.Team != teamOne.First().CharBase.Team).ToList();

                foreach (Character Char in fullList)
                    foreach (Ability Abil in Char.CharBase.Abilities)
                        Abil.OnAbilityFired += OnAbilityFired;

                bool team1turn = true;
                int turn = 1;
#if DEBUG
                while (turn < 20)
#else
            while (true)
#endif
                {
                    if (team1turn)
                    {
                        RunRound(characterQueue, characterQueueTwo, turn);
                        team1turn = false;
                    }
                    else
                    {
                        RunRound(characterQueueTwo, characterQueue, turn);
                        team1turn = true;
                    }
                    turn++;

                    #region see if there's a winner
                    if (isTeamDead(teamOne))
                    {
                        Output("Team " + teamTwo.First().CharBase.Team.ToString() + " has won the fight!");
                        break;
                    }
                    else if (isTeamDead(teamTwo))
                    {
                        Output("Team " + teamOne.First().CharBase.Team.ToString() + " has won the fight!");
                        break;
                    }
                    #endregion

                }
            }
            else
            {
                msg.Add(characterCheck.Item2, Color.Red);
                msg.Add(abilityCheck.Item2, Color.Red);
                cleverOutput(msg);
            }

        }

        private Tuple<bool, string> IsCharacterOk(Rules rules, List<Character> characterList)
        {
            foreach (Character c in characterList)
            {
                Tuple<bool, string> cCheck = rules.IsCharacterIllegal(c);
                if (cCheck.Item1)
                    return new Tuple<bool, string>(false, cCheck.Item2);

            }

            return new Tuple<bool, string>(true, "All is ok.");
        }

        private Tuple<bool, string> IsAbilityOk(Rules rules, List<Character> characterList)
        {
            foreach (Character c in characterList)
            {
                Tuple<bool, Ability> aCheck = rules.IsAbilityIlligal(c);
                if (aCheck.Item1)
                    return new Tuple<bool, string>(false, "The character " + c.CharBase.Name + "'s ability " + aCheck.Item2.Name + " is illegal. The cost allowed by the game is " + (rules.Scale * rules.BaseCost).ToString() + " but the ability cost was " + (aCheck.Item2.Cost * rules.Scale).ToString() + ".");
            }

            return new Tuple<bool, string>(true, "All Ok");
        }

        private void RunRound(Queue<Character> currentQueue, Queue<Character> nextQueue, int turn)
        {
            Output("Round: " + turn);

            while (currentQueue.Count > 0)
            {
                Character currentCharacter = currentQueue.FirstOrDefault();
                if (currentCharacter.CharBase.Alive)
                    currentCharacter.CharAI.DoTurn(fullList);
                else
                {
                    msg.Add(currentCharacter.CharBase.Name, Color.Red);
                    msg.Add(" remains dead..", Color.Black);
                    cleverOutput(msg);
                }

                nextQueue.Enqueue(currentQueue.Dequeue());
            }
        }

        private void OnAbilityFired(object sender, AbilityEventArgs args)
        {
            msg.Add(args.Source.CharBase.Name, Color.Red);
            msg.Add(args.Source.CharBase.Health.Current.ToString(), Color.Blue);
            msg.Add(" uses ", Color.Black);
            msg.Add(args.Ability.Name, Color.BlueViolet);
            msg.Add(" on ", Color.Black);

            int dmg = args.Ability.Damage * rules.Scale;

            foreach (Ability ability in args.Source.CharBase.Buffs)
                if (ability.buffType == EnumBuffType.DAMAGE)
                    dmg = ability.BuffModify(dmg, args.Ability.element);
            foreach (Character character in args.Targets)
            {
                int finalDmg = dmg;
                foreach (Ability ability in character.CharBase.Buffs)
                    if (ability.buffType == EnumBuffType.RESIST)
                        finalDmg = ability.BuffModify(finalDmg, args.Ability.element);

                character.CharBase.Health.Current -= finalDmg;
                character.CharBase.TurnPoints.Current -= args.Ability.Cost;
                if (character.CharBase.Health.Current <= 0)
                {
                    character.CharBase.Health.Current = 0;
                    character.CharBase.Alive = false;
                }

                msg.Add(Environment.NewLine, Color.Black);
                msg.Add(character.CharBase.Name, Color.Red);
                msg.Add(character.CharBase.Health.Current.ToString(), Color.Blue);
                msg.Add(" for ", Color.Black);
                msg.Add(finalDmg.ToString() + " ", Color.DarkBlue);
                msg.Add(args.Ability.element.ToString() + " damage.", Color.Black);
            }

            cleverOutput(msg);
        }


        /// <summary>
        /// Checks if all characters on a team are dead.
        /// </summary>
        /// <param name="teamList">The list containing the team</param>
        /// <returns>true/false</returns>
        public bool isTeamDead(List<Character> teamList)
        {

            foreach (Character c in teamList)
            {
                if (c.CharBase.Alive)
                    return false;
            }

            return true;

        }



        /// <summary>
        /// Takes the full list of characters in the game, and creates a queue where the turn is alternated between two teams.
        /// </summary>
        /// <param name="fullList">The full list of characters in this class</param>
        public Queue<Character> initiateQueue()
        {

            Queue<Character> tmpQueue = new Queue<Character>();
            List<Character> teamOne = fullList.Where(x => x.CharBase.Team == fullList.First().CharBase.Team).ToList();
            List<Character> teamTwo = fullList.Where(x => x.CharBase.Team != teamOne.First().CharBase.Team).ToList();

            for (int i = 0; i < fullList.Count; i++)
            {

                if (i < teamOne.Count)
                {
                    teamOne[i].CharBase.Alive = true;
                    tmpQueue.Enqueue(teamOne[i]);
                }

                if (i < teamTwo.Count)
                {
                    teamTwo[i].CharBase.Alive = true;
                    tmpQueue.Enqueue(teamTwo[i]);
                }

            }

            return tmpQueue;
        }

    }
}
