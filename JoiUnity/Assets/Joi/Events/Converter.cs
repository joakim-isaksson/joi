using System;
using UnityEngine;

namespace Joi.Events
{
	public static class Converter
	{
		public enum Type
		{
			BooleanNone,
			BooleanInvert,
			BooleanToFloat,
			BooleanToInteger,
			BooleanToString,
			FloatNone,
			FloatNegate,
			FloatToBoolean,
			FloatFloorToInteger,
			FloatCeilToInteger,
			FloatRoundToInteger,
			FloatToString,
			FloatToStringF,
			FloatToStringF1,
			FloatToStringN,
			FloatToStringN1,
			FloatToStringP,
			FloatToStringP1,
			IntegerNone,
			IntegerNegate,
			IntegerToBoolean,
			IntegerToFloat,
			IntegerToString,
			StringNone,
			StringToBoolean,
			StringToFloat,
			StringToInteger,
		}

		public enum BooleanType
		{
			None = Type.BooleanNone,
			Invert = Type.BooleanInvert,
			Float = Type.BooleanToFloat,
			Integer = Type.BooleanToInteger,
			String = Type.BooleanToString
		}

		public enum FloatType
		{
			None = Type.FloatNone,
			Negate = Type.FloatNegate,
			Boolean = Type.FloatToBoolean,
			FloorToInteger = Type.FloatFloorToInteger,
			CeilToInteger = Type.FloatCeilToInteger,
			RoundToInteger = Type.FloatRoundToInteger,
			String = Type.FloatToString,
			StringF = Type.FloatToStringF,
			StringF1 = Type.FloatToStringF1,
			StringN = Type.FloatToStringN,
			StringN1 = Type.FloatToStringN1,
			StringP = Type.FloatToStringP,
			StringP1 = Type.FloatToStringP1,
		}

		public enum IntegerType
		{
			None = Type.IntegerNone,
			Negate = Type.IntegerNegate,
			Boolean = Type.IntegerToBoolean,
			Float = Type.IntegerToFloat,
			String = Type.IntegerToString
		}

		public enum StringType
		{
			None = Type.StringNone,
			Boolean = Type.StringToBoolean,
			Float = Type.StringToFloat,
			Integer = Type.StringToInteger
		}

		public static bool HasConverter(JoiParameterType type)
		{
			switch (type)
			{
				case JoiParameterType.None:
					return false;
				case JoiParameterType.Boolean:
					return true;
				case JoiParameterType.Color:
					return false;
				case JoiParameterType.Float:
					return true;
				case JoiParameterType.GameObject:
					return false;
				case JoiParameterType.Integer:
					return true;
				case JoiParameterType.Material:
					return false;
				case JoiParameterType.Object:
					return false;
				case JoiParameterType.Sprite:
					return false;
				case JoiParameterType.String:
					return true;
				case JoiParameterType.Vector3:
					return false;
				default:
					throw new ArgumentOutOfRangeException(nameof(type), type, null);
			}
		}

		public static JoiParameterType GetReturnType(Type type)
		{
			switch (type)
			{
				case Type.BooleanNone:
					return JoiParameterType.Boolean;
				case Type.BooleanInvert:
					return JoiParameterType.Boolean;
				case Type.BooleanToFloat:
					return JoiParameterType.Float;
				case Type.BooleanToInteger:
					return JoiParameterType.Integer;
				case Type.BooleanToString:
					return JoiParameterType.String;
				case Type.FloatNone:
					return JoiParameterType.Float;
				case Type.FloatNegate:
					return JoiParameterType.Float;
				case Type.FloatToBoolean:
					return JoiParameterType.Boolean;
				case Type.FloatFloorToInteger:
					return JoiParameterType.Integer;
				case Type.FloatCeilToInteger:
					return JoiParameterType.Integer;
				case Type.FloatRoundToInteger:
					return JoiParameterType.Integer;
				case Type.FloatToString:
					return JoiParameterType.String;
				case Type.FloatToStringF:
					return JoiParameterType.String;
				case Type.FloatToStringF1:
					return JoiParameterType.String;
				case Type.FloatToStringN:
					return JoiParameterType.String;
				case Type.FloatToStringN1:
					return JoiParameterType.String;
				case Type.FloatToStringP:
					return JoiParameterType.String;
				case Type.FloatToStringP1:
					return JoiParameterType.String;
				case Type.IntegerNone:
					return JoiParameterType.Integer;
				case Type.IntegerNegate:
					return JoiParameterType.Integer;
				case Type.IntegerToBoolean:
					return JoiParameterType.Boolean;
				case Type.IntegerToFloat:
					return JoiParameterType.Float;
				case Type.IntegerToString:
					return JoiParameterType.String;
				case Type.StringNone:
					return JoiParameterType.String;
				case Type.StringToBoolean:
					return JoiParameterType.Boolean;
				case Type.StringToFloat:
					return JoiParameterType.Float;
				case Type.StringToInteger:
					return JoiParameterType.Integer;
				default:
					throw new ArgumentOutOfRangeException(nameof(type), type, null);
			}
		}

		public static bool Invert(bool value)
		{
			return !value;
		}

		public static float ToFloat(bool value)
		{
			return value ? 1.0f : 0f;
		}

		public static int ToInteger(bool value)
		{
			return value ? 1 : 0;
		}

		public static string ToString(bool value)
		{
			return value.ToString();
		}

		public static float Negate(float value)
		{
			return -value;
		}

		public static bool ToBoolean(float value)
		{
			return Mathf.Approximately(value, 0f);
		}

		public static int FloorToInteger(float value)
		{
			return Mathf.FloorToInt(value);
		}

		public static int CeilToInteger(float value)
		{
			return Mathf.CeilToInt(value);
		}

		public static int RoundToInteger(float value)
		{
			return Mathf.RoundToInt(value);
		}

		public static string ToString(float value)
		{
			return value.ToString();
		}

		public static string ToStringF(float value)
		{
			return value.ToString("F");
		}

		public static string ToStringF1(float value)
		{
			return value.ToString("F1");
		}

		public static string ToStringN(float value)
		{
			return value.ToString("N");
		}

		public static string ToStringN1(float value)
		{
			return value.ToString("N1");
		}

		public static string ToStringP(float value)
		{
			return value.ToString("P");
		}

		public static string ToStringP1(float value)
		{
			return value.ToString("P1");
		}

		public static int Negate(int value)
		{
			return -value;
		}

		public static bool ToBoolean(int value)
		{
			return value != 0;
		}

		public static float ToFloat(int value)
		{
			return value;
		}

		public static string ToString(int value)
		{
			return value.ToString();
		}

		public static bool ToBoolean(string value)
		{
			return bool.Parse(value);
		}

		public static float ToFloat(string value)
		{
			return float.Parse(value);
		}

		public static int ToInteger(string value)
		{
			return int.Parse(value);
		}
	}
}