﻿using System;
using System.Linq;

namespace DndCore
{
	public class Druid : BaseRow
	{
		public int Level { get; set; }
		public int ProficiencyBonus { get; set; }
		public string Features { get; set; }
		public string WildShapeCR { get; set; }
		public string WildShapeLimitations { get; set; }
		public int CantripsKnown { get; set; }
		public int Slot1Spells { get; set; }
		public int Slot2Spells { get; set; }
		public int Slot3Spells { get; set; }
		public int Slot4Spells { get; set; }
		public int Slot5Spells { get; set; }
		public int Slot6Spells { get; set; }
		public int Slot7Spells { get; set; }
		public int Slot8Spells { get; set; }
		public int Slot9Spells { get; set; }
		public Druid()
		{

		}
	}
}

