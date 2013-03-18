using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Model;
using DLLLoader;
using Engine;


namespace GUICore
{
  public partial class Form1 : Form
  {
    List<Character> CharList = new List<Character>();
    Game game;
    Rules rules = null;

    public Form1()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Method loads a set of characters based on the dll files selected.
    /// It also prints out which characters and what team they are on.
    /// </summary>
    private void loadCharacters_btn_Click(object sender, EventArgs e)
    {
      if (rules != null)
      {
        OpenFileDialog Dlg = new OpenFileDialog();
        Dlg.Multiselect = true;
        Dlg.Filter = "Character DLL|*.dll";
        Dlg.InitialDirectory = Directory.GetCurrentDirectory();
        DialogResult DlgResult = Dlg.ShowDialog();
        if (DlgResult == System.Windows.Forms.DialogResult.OK)
        {

          foreach (string Path in Dlg.FileNames)
          {
            string LoadString = "";
            bool loadSuccessful = true;
            LoadString += "Characters | Loading " + Path;
            Character currentCharacter = Loader.LoadCharacter(Path);
            if (currentCharacter.CharBase.Name == "Unknown Character")
            {
              LoadString += "\n  Error loading CharacterBase...";
              loadSuccessful = false;
            }
            else
              LoadString += "\n  Character found: " + currentCharacter.CharBase.Name;


            if (currentCharacter.CharAI == null)
            {
              LoadString += "\n  Error loading CharacterAI...";
              loadSuccessful = false;
            }
            else
              LoadString += "\n  AI found.";

            if (loadSuccessful)
            {
              CharList.Add(currentCharacter);
              LoadString += "\nSuccessfully loaded character for team " + currentCharacter.CharBase.Team + ".";
            }

            this.sendMessageToLog(LoadString);
          }
        }
      }
      else
      {
        this.sendMessageToLog("Error: You have to load a rule set before the characters can be loaded.");
      }
    }

    /// <summary>
    /// Sends a string to the richTextBox. Does the same as <see cref="cleverSendToMessageLog"/>, however, this one
    /// always defaults the color to black, and so only requires a string.
    /// </summary>
    /// <param name="msg">The string to be sent to the log</param>
    public void sendMessageToLog(string msg)
    {
      addSpacer();
      logBox.AppendText(msg, Color.Black);
      logBox.AppendText(Environment.NewLine);
      logBox.SelectionStart = logBox.Text.Length;
      logBox.ScrollToCaret();
    }

    /// <summary>
    /// Method sends any string to the richTextBox. The strings come as a key->pair set as a Dictionary,
    /// the Dictionary consists of a string and the color of that particular string.
    /// </summary>
    /// <param name="msg">The dictionary of strings and colors</param>
    public void cleverSendToMessageLog(LogMessages msg)
    {

      foreach (Tuple<string, Color> t in msg.Message)
      {
        logBox.AppendText(t.Item1, t.Item2);
      }

      logBox.AppendText(Environment.NewLine);
      logBox.Update();
      logBox.SelectionStart = logBox.Text.Length;
      logBox.ScrollToCaret();
      msg.Clear();
    }

    /// <summary>
    /// Adds a newline gap to any logged event.
    /// </summary>
    private void addSpacer()
    {
      logBox.AppendText(Environment.NewLine);
      logBox.AppendText(Environment.NewLine);
    }

    /// <summary>
    /// Starts a "game round". There has to be 2 teams, and there has to be minimum 2 characters to start a round. 
    /// </summary>
    private void startMatch_btn_Click(object sender, EventArgs e)
    {
      logBox.Clear();
      if (CharList.Count > 1)
      {
        int teamOne = CharList.First().CharBase.Team;
        if (CharList.Where(x => x.CharBase.Team != teamOne).ToList().Count > 0)
        {
          game = new Game(CharList, sendMessageToLog, cleverSendToMessageLog, rules);
          game.Run();
        }
        else
          sendMessageToLog("Error: All characters are on the same team!");
      }
      else
        sendMessageToLog("Error: Not enough characters loaded!");

    }


    private void loadRules_btn_Click(object sender, EventArgs e)
    {
      OpenFileDialog Dlg = new OpenFileDialog();
      Dlg.Filter = "Rule Set DLL|*.dll";
      Dlg.InitialDirectory = Directory.GetCurrentDirectory();
      DialogResult DlgResult = Dlg.ShowDialog();
      if (DlgResult == System.Windows.Forms.DialogResult.OK)
      {
        string loadString = "";
        loadString += "Rules | Loading " + Dlg.FileName;
        Rules tempRules = Loader.LoadRuleset(Dlg.FileName);
        if (tempRules != null)
        {
          rules = tempRules;
          loadString += "\n  Turn Points: " + rules.AllowedTurnPoints;
          loadString += "\n  Scale: " + rules.Scale;
          loadString += "\nSuccessfully loaded rules.";
        }
        else
          loadString += "\nError loading rules, rules not found.";

        this.sendMessageToLog(loadString);

      }
    }

  }
}
