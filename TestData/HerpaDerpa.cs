using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Abilities;

namespace Test
{
	public class Stats : CharacterBase
	{
		public Stats()
		{
			Name = "DocJohn";
			Health = new CharAttribute(EnumAttributeType.HEALTH, 100);
			TurnPoints = new CharAttribute(EnumAttributeType.TURNPOINTS, 20);
			Team = 2;
			Alive = true;
		}
	}
	
	public class Priest : AI
	{
		List<Character> listOfCharacters;
		List<character> Enemies;
		List<character> Allies;
		
		public Priest()
		{
		}
		
		public override Tuple<Character, Character, Ability> DoTurn(List<Character> currentCharacters)
		{
			listOfCharacters = currentCharacters;
			
			GetMe();
			GetAllegiance();
			CastShield();
			CastBandage();
			CastShadowBolt();
			CastPhysicalAttack();
		}
		
		private void GetMe();
		{
			if (listOfCharacters.Where(x => x.CharAI.Equals(this)).FirstOrDefault() != null)
			{
				Me = listOfCharacters.Where(x => x.CharAI.Equals(this)).FirstOrDefault();
			}
			
			else
			{
				throw new Exception("Something went very wrong. I dont exist :(");
			}
		}
		
		private void GetAllegiance();
		{			
			Enemies = currentCharacters.Where(x => x.CharBase.Team != Me.CharBase.Team).ToList();
			Allies = currentCharacters.Where(x => x.CharBase.Team == Me.CharBase.Team).ToList();
		}
		
		private void CastShield();
		{
			Allies.Sort(x => x.CharBase.Health / x.Charbase.MaxHealth);
			if(Allies[0].Health != Allies[0].MaxHealth)
			{
				Shield.Use(Me, Allies[0])
			}
		}
		
		private void CastBandage();
		{
			Allies.Sort(x => x.CharBase.Health / x.CharBase.MaxHealth);
			if(Allies[0].Health != Allies[0].MaxHealth)
			{
				Bandage.Use(Me, Allies[0])
			}
		}
		
		private void CastShadowBolt();
		{
			Enemies.Sort(x => x.CharBase.Health)
			while(Me.TurnPoints >= ShadowBolt.Cost)
			{
				ShadowBolt.Use(Me, Enemies[0])
			}
		}
		
		private void CastPhysicalAttack();
		{
			Enemies.Sort(x => x.CharBase.Health)
			while(Me.TurnPoints >= PhysicalAttack.Cost)
			{
				PhysicalAttack.Use(Me, Enemies[0])
			}
		}
	}
}