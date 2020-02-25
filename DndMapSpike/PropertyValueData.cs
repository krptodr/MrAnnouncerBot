﻿using System;
using System.Linq;
using System.Reflection;

namespace DndMapSpike
{
	public class PropertyValueData
	{
		public bool HasInconsistentValues { get; set; }
		public string Name { get; set; }
		public string DisplayText { get; set; }
		public PropertyType Type { get; set; }
		public bool? BoolValue { get; set; }
		public double? NumericValue { get; set; }
		public string StringValue { get; set; }
		public bool ComparedOnce { get; set; }
		public object FirstInstance { get; set; }

		public void Compare(object instance, PropertyInfo propertyInfo)
		{
			if (HasInconsistentValues)
				return;
			// TODO: compare the properties of this instance.
			string fullTypeName = propertyInfo.PropertyType.FullName;
			object value = propertyInfo.GetValue(instance);
			switch (fullTypeName)
			{
				case "System.String":
					HasInconsistentValues = StringValue != value as string;
					break;
				case "System.Int32":
					HasInconsistentValues = NumericValue != (int)value;
					break;
				case "System.Decimal":
				case "System.Double":
					HasInconsistentValues = NumericValue != (double)value;
					break;
				case "System.Boolean":
					HasInconsistentValues = BoolValue != (bool)value;
					break;
				default:
					{
						if (propertyInfo.PropertyType.BaseType.FullName == "System.Enum")
						{
							HasInconsistentValues = NumericValue != (int)value;
						}
						break;
					}
			}

			ComparedOnce = true;
		}

		public PropertyValueData(object instance, PropertyInfo propertyInfo, string displayText)
		{
			Name = propertyInfo.Name;
			DisplayText = displayText;
			object value = propertyInfo.GetValue(instance);
			string fullTypeName = propertyInfo.PropertyType.FullName;
			switch (fullTypeName)
			{
				case "System.String":
					Type = PropertyType.String;
					StringValue = value as string;
					break;
				case "System.Int32":
					Type = PropertyType.Integer;
					NumericValue = (int)value;
					break;
				case "System.Double":
					Type = PropertyType.Double;
					NumericValue = (double)value;
					break;
				case "System.Decimal":
					Type = PropertyType.Decimal;
					NumericValue = (double)value;
					break;
				case "System.Boolean":
					Type = PropertyType.Boolean;
					BoolValue = (bool)value;
					break;
				default:
					{
						if (propertyInfo.PropertyType.BaseType.FullName == "System.Enum")
						{
							Type = PropertyType.Enum;
							NumericValue = (int)value;
						}
						break;
					}
			}

			if (DisplayText == null && fullTypeName != "System.Boolean")
				DisplayText = $"{Name}: ";
			else
				DisplayText = Name;
		}
	}
}

