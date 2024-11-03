using System;
using UnityEngine;

namespace Joi.UIEvents
{
	[Serializable]
	public class Converter
	{
		public enum BooleanConverter
		{
			None,
			Invert,
			Float,
			Integer,
			String
		}

		public enum FloatConverter
		{
			None,
			Negate,
			Boolean,
			FloorToInteger,
			CeilToInteger,
			RoundToInteger,
			String,
			StringFixedPoint,
			StringFixedPoint0,
			StringFixedPoint1,
			StringFixedPoint2,
			StringNumber,
			StringNumber0,
			StringNumber1,
			StringNumber2,
			StringPercentage,
			StringPercentage0,
			StringPercentage1,
			StringPercentage2
		}

		public enum IntegerConverter
		{
			None,
			Negate,
			Boolean,
			Float,
			String
		}

		public enum StringConverter
		{
			None,
			Boolean,
			Float,
			Integer
		}

		[SerializeField] private BooleanConverter _converterBoolean;
		[SerializeField] private FloatConverter _converterFloat;
		[SerializeField] private IntegerConverter _converterInteger;
		[SerializeField] private StringConverter _converterString;

		public Action<bool> OnResultBoolean;
		public Action<float> OnResultFloat;
		public Action<int> OnResultInteger;
		public Action<string> OnResultString;

		public static bool HasConverter(ParameterType type)
		{
			switch (type)
			{
				case ParameterType.Boolean:
				case ParameterType.Float:
				case ParameterType.Integer:
				case ParameterType.String:
					return true;
			}

			return false;
		}

		public void Convert(bool value)
		{
			switch (_converterBoolean)
			{
				case BooleanConverter.None:
					OnResultBoolean?.Invoke(value);
					break;
				case BooleanConverter.Invert:
					OnResultBoolean?.Invoke(!value);
					break;
				case BooleanConverter.Float:
					OnResultFloat?.Invoke(value ? 1f : 0f);
					break;
				case BooleanConverter.Integer:
					OnResultInteger?.Invoke(value ? 1 : 0);
					break;
				case BooleanConverter.String:
					OnResultString?.Invoke(value.ToString());
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public void Convert(float value)
		{
			switch (_converterFloat)
			{
				case FloatConverter.None:
					OnResultFloat?.Invoke(value);
					break;
				case FloatConverter.Negate:
					OnResultFloat?.Invoke(-value);
					break;
				case FloatConverter.Boolean:
					OnResultBoolean?.Invoke(Mathf.Approximately(value, 0f));
					break;
				case FloatConverter.FloorToInteger:
					OnResultInteger?.Invoke(Mathf.FloorToInt(value));
					break;
				case FloatConverter.CeilToInteger:
					OnResultInteger?.Invoke(Mathf.CeilToInt(value));
					break;
				case FloatConverter.RoundToInteger:
					OnResultInteger?.Invoke(Mathf.RoundToInt(value));
					break;
				case FloatConverter.String:
					OnResultString?.Invoke(value.ToString());
					break;
				case FloatConverter.StringFixedPoint:
					OnResultString?.Invoke(value.ToString("F"));
					break;
				case FloatConverter.StringFixedPoint0:
					OnResultString?.Invoke(value.ToString("F0"));
					break;
				case FloatConverter.StringFixedPoint1:
					OnResultString?.Invoke(value.ToString("F1"));
					break;
				case FloatConverter.StringFixedPoint2:
					OnResultString?.Invoke(value.ToString("F2"));
					break;
				case FloatConverter.StringNumber:
					OnResultString?.Invoke(value.ToString("N"));
					break;
				case FloatConverter.StringNumber0:
					OnResultString?.Invoke(value.ToString("N0"));
					break;
				case FloatConverter.StringNumber1:
					OnResultString?.Invoke(value.ToString("N1"));
					break;
				case FloatConverter.StringNumber2:
					OnResultString?.Invoke(value.ToString("N2"));
					break;
				case FloatConverter.StringPercentage:
					OnResultString?.Invoke(value.ToString("P"));
					break;
				case FloatConverter.StringPercentage0:
					OnResultString?.Invoke(value.ToString("P0"));
					break;
				case FloatConverter.StringPercentage1:
					OnResultString?.Invoke(value.ToString("P1"));
					break;
				case FloatConverter.StringPercentage2:
					OnResultString?.Invoke(value.ToString("P2"));
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public void Convert(int value)
		{
			switch (_converterInteger)
			{
				case IntegerConverter.None:
					OnResultInteger?.Invoke(value);
					break;
				case IntegerConverter.Negate:
					OnResultInteger?.Invoke(-value);
					break;
				case IntegerConverter.Boolean:
					OnResultBoolean?.Invoke(value == 0);
					break;
				case IntegerConverter.Float:
					OnResultFloat?.Invoke(value);
					break;
				case IntegerConverter.String:
					OnResultString?.Invoke(value.ToString());
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public void Convert(string value)
		{
			switch (_converterString)
			{
				case StringConverter.None:
					OnResultString?.Invoke(value);
					break;
				case StringConverter.Boolean:
					OnResultBoolean?.Invoke(bool.Parse(value));
					break;
				case StringConverter.Float:
					OnResultFloat?.Invoke(float.Parse(value));
					break;
				case StringConverter.Integer:
					OnResultInteger?.Invoke(int.Parse(value));
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public static ParameterType GetReturnType(BooleanConverter converter)
		{
			switch (converter)
			{
				case BooleanConverter.None:
				case BooleanConverter.Invert:
					return ParameterType.Boolean;
				case BooleanConverter.Float:
					return ParameterType.Float;
				case BooleanConverter.Integer:
					return ParameterType.Integer;
				case BooleanConverter.String:
					return ParameterType.String;
				default:
					throw new ArgumentOutOfRangeException(nameof(converter), converter, null);
			}
		}

		public static ParameterType GetReturnType(FloatConverter converter)
		{
			switch (converter)
			{
				case FloatConverter.None:
				case FloatConverter.Negate:
					return ParameterType.Float;
				case FloatConverter.Boolean:
					return ParameterType.Boolean;
				case FloatConverter.FloorToInteger:
				case FloatConverter.CeilToInteger:
				case FloatConverter.RoundToInteger:
					return ParameterType.Integer;
				case FloatConverter.String:
				case FloatConverter.StringFixedPoint:
				case FloatConverter.StringFixedPoint0:
				case FloatConverter.StringFixedPoint1:
				case FloatConverter.StringFixedPoint2:
				case FloatConverter.StringNumber:
				case FloatConverter.StringNumber0:
				case FloatConverter.StringNumber1:
				case FloatConverter.StringNumber2:
				case FloatConverter.StringPercentage:
				case FloatConverter.StringPercentage0:
				case FloatConverter.StringPercentage1:
				case FloatConverter.StringPercentage2:
					return ParameterType.String;
				default:
					throw new ArgumentOutOfRangeException(nameof(converter), converter, null);
			}
		}

		public static ParameterType GetReturnType(IntegerConverter converter)
		{
			switch (converter)
			{
				case IntegerConverter.None:
				case IntegerConverter.Negate:
					return ParameterType.Integer;
				case IntegerConverter.Boolean:
					return ParameterType.Boolean;
				case IntegerConverter.Float:
					return ParameterType.Float;
				case IntegerConverter.String:
					return ParameterType.String;
				default:
					throw new ArgumentOutOfRangeException(nameof(converter), converter, null);
			}
		}

		public static ParameterType GetReturnType(StringConverter converter)
		{
			switch (converter)
			{
				case StringConverter.None:
					return ParameterType.String;
				case StringConverter.Boolean:
					return ParameterType.Boolean;
				case StringConverter.Float:
					return ParameterType.Float;
				case StringConverter.Integer:
					return ParameterType.Integer;
				default:
					throw new ArgumentOutOfRangeException(nameof(converter), converter, null);
			}
		}
	}
}