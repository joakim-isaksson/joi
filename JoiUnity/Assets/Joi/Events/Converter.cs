using System;
using UnityEngine;

namespace Joi.Events
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
			StringF,
			StringF1,
			StringN,
			StringN1,
			StringP,
			StringP1,
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

		public static bool HasConverter(JoiParameterType type)
		{
			switch (type)
			{
				case JoiParameterType.Boolean:
				case JoiParameterType.Float:
				case JoiParameterType.Integer:
				case JoiParameterType.String:
					return true;
			}

			return false;
		}

		public Action<bool> OnBoolean;
		public Action<float> OnFloat;
		public Action<int> OnInteger;
		public Action<string> OnString;

		[SerializeField] private BooleanConverter _converterBoolean;
		[SerializeField] private FloatConverter _converterFloat;
		[SerializeField] private IntegerConverter _converterInteger;
		[SerializeField] private StringConverter _converterString;

		public void Convert(bool value)
		{
			switch (_converterBoolean)
			{
				case BooleanConverter.None:
					OnBoolean?.Invoke(value);
					break;
				case BooleanConverter.Invert:
					OnBoolean?.Invoke(!value);
					break;
				case BooleanConverter.Float:
					OnFloat?.Invoke(value ? 1f : 0f);
					break;
				case BooleanConverter.Integer:
					OnInteger?.Invoke(value ? 1 : 0);
					break;
				case BooleanConverter.String:
					OnString?.Invoke(value.ToString());
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
					OnFloat?.Invoke(value);
					break;
				case FloatConverter.Negate:
					OnFloat?.Invoke(-value);
					break;
				case FloatConverter.Boolean:
					OnBoolean?.Invoke(Mathf.Approximately(value, 0f));
					break;
				case FloatConverter.FloorToInteger:
					OnInteger?.Invoke(Mathf.FloorToInt(value));
					break;
				case FloatConverter.CeilToInteger:
					OnInteger?.Invoke(Mathf.CeilToInt(value));
					break;
				case FloatConverter.RoundToInteger:
					OnInteger?.Invoke(Mathf.RoundToInt(value));
					break;
				case FloatConverter.String:
					OnString?.Invoke(value.ToString());
					break;
				case FloatConverter.StringF:
					OnString?.Invoke(value.ToString("F"));
					break;
				case FloatConverter.StringF1:
					OnString?.Invoke(value.ToString("F1"));
					break;
				case FloatConverter.StringN:
					OnString?.Invoke(value.ToString("N"));
					break;
				case FloatConverter.StringN1:
					OnString?.Invoke(value.ToString("N1"));
					break;
				case FloatConverter.StringP:
					OnString?.Invoke(value.ToString("P"));
					break;
				case FloatConverter.StringP1:
					OnString?.Invoke(value.ToString("P1"));
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
					OnInteger?.Invoke(value);
					break;
				case IntegerConverter.Negate:
					OnInteger?.Invoke(-value);
					break;
				case IntegerConverter.Boolean:
					OnBoolean?.Invoke(value == 0);
					break;
				case IntegerConverter.Float:
					OnFloat?.Invoke(value);
					break;
				case IntegerConverter.String:
					OnString?.Invoke(value.ToString());
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
					OnString?.Invoke(value);
					break;
				case StringConverter.Boolean:
					OnBoolean?.Invoke(bool.Parse(value));
					break;
				case StringConverter.Float:
					OnFloat?.Invoke(float.Parse(value));
					break;
				case StringConverter.Integer:
					OnInteger?.Invoke(int.Parse(value));
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public JoiParameterType GetBooleanReturnType()
		{
			return GetReturnType(_converterBoolean);
		}

		public JoiParameterType GetFloatReturnType()
		{
			return GetReturnType(_converterFloat);
		}

		public JoiParameterType GetIntegerReturnType()
		{
			return GetReturnType(_converterInteger);
		}

		public JoiParameterType GetStringReturnType()
		{
			return GetReturnType(_converterString);
		}

		public static JoiParameterType GetReturnType(BooleanConverter converter)
		{
			switch (converter)
			{
				case BooleanConverter.None:
					return JoiParameterType.Boolean;
				case BooleanConverter.Invert:
					return JoiParameterType.Boolean;
				case BooleanConverter.Float:
					return JoiParameterType.Float;
				case BooleanConverter.Integer:
					return JoiParameterType.Integer;
				case BooleanConverter.String:
					return JoiParameterType.String;
				default:
					throw new ArgumentOutOfRangeException(nameof(converter), converter, null);
			}
		}

		public static JoiParameterType GetReturnType(FloatConverter converter)
		{
			switch (converter)
			{
				case FloatConverter.None:
					return JoiParameterType.Float;
				case FloatConverter.Negate:
					return JoiParameterType.Float;
				case FloatConverter.Boolean:
					return JoiParameterType.Boolean;
				case FloatConverter.FloorToInteger:
					return JoiParameterType.Integer;
				case FloatConverter.CeilToInteger:
					return JoiParameterType.Integer;
				case FloatConverter.RoundToInteger:
					return JoiParameterType.Integer;
				case FloatConverter.String:
					return JoiParameterType.String;
				case FloatConverter.StringF:
					return JoiParameterType.String;
				case FloatConverter.StringF1:
					return JoiParameterType.String;
				case FloatConverter.StringN:
					return JoiParameterType.String;
				case FloatConverter.StringN1:
					return JoiParameterType.String;
				case FloatConverter.StringP:
					return JoiParameterType.String;
				case FloatConverter.StringP1:
					return JoiParameterType.String;
				default:
					throw new ArgumentOutOfRangeException(nameof(converter), converter, null);
			}
		}

		public static JoiParameterType GetReturnType(IntegerConverter converter)
		{
			switch (converter)
			{
				case IntegerConverter.None:
					return JoiParameterType.Integer;
				case IntegerConverter.Negate:
					return JoiParameterType.Integer;
				case IntegerConverter.Boolean:
					return JoiParameterType.Boolean;
				case IntegerConverter.Float:
					return JoiParameterType.Float;
				case IntegerConverter.String:
					return JoiParameterType.String;
				default:
					throw new ArgumentOutOfRangeException(nameof(converter), converter, null);
			}
		}

		public static JoiParameterType GetReturnType(StringConverter converter)
		{
			switch (converter)
			{
				case StringConverter.None:
					return JoiParameterType.String;
				case StringConverter.Boolean:
					return JoiParameterType.Boolean;
				case StringConverter.Float:
					return JoiParameterType.Float;
				case StringConverter.Integer:
					return JoiParameterType.Integer;
				default:
					throw new ArgumentOutOfRangeException(nameof(converter), converter, null);
			}
		}
	}
}