﻿using System;
using System.Collections.Generic;
using CodingSeb.ExpressionEvaluator;

namespace DndCore
{
	public class AddDieRollEffectsFunction : DndFunction
	{
		public override string Name => "AddDieRollEffects";

		public override object Evaluate(List<string> args, ExpressionEvaluator evaluator, Character player, Target target, CastedSpell spell, DiceStoppedRollingData dice = null)
		{
			ExpectingArguments(args, 1);

			string dieRollEffects = evaluator.Evaluate<string>(args[0]);

			player.AddDieRollEffects(dieRollEffects);

			return null;
		}
	}
}
