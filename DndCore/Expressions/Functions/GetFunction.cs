﻿using System;
using System.Reflection;
using System.Collections.Generic;
using CodingSeb.ExpressionEvaluator;

namespace DndCore
{
	/// <summary>
	/// Gets the specified property of the player.
	/// </summary>
	public class GetFunction : DndFunction
	{
		public override string Name => "Get";

		public override object Evaluate(List<string> args, ExpressionEvaluator evaluator, Character player, Target target, CastedSpell spell, DiceStoppedRollingData dice = null)
		{
			ExpectingArguments(args, 1);

			string propertyName = args[0];

			FieldInfo field = typeof(Character).GetField(propertyName);
			if (field != null)
				return field.GetValue(player);

			PropertyInfo property = typeof(Character).GetProperty(propertyName);
			if (property != null)
				return property.GetValue(player);

			if (KnownQualifiers.IsSpellQualifier(propertyName))
			{
				if (evaluator.Variables.ContainsKey(Expressions.STR_CastedSpell))
				{
					object castedSpell = evaluator.Variables[Expressions.STR_CastedSpell];
					Type instanceType = typeof(CastedSpell);
					propertyName = propertyName.EverythingAfter(KnownQualifiers.Spell);
					property = instanceType.GetProperty(propertyName);
					return property.GetValue(castedSpell);
				}
			}

			if (player != null)
				return player.GetState(propertyName);

			return null;
		}
	}
}
