using System;
using UnityEngine;

namespace Joi.UIEvents
{
	[Serializable]
	public class Filter
	{
		public enum BooleanFilter
		{
			None,
			Equal
		}

		public enum FloatFilter
		{
			None,
			Less,
			LessOrEqual,
			Equal,
			GreaterOrEqual,
			Greater
		}

		public enum IntegerFilter
		{
			None,
			Less,
			LessOrEqual,
			Equal,
			GreaterOrEqual,
			Greater
		}

		public enum StringFilter
		{
			None,
			Equal
		}

		[SerializeField] private BooleanFilter _filterBoolean;
		[SerializeField] private FloatFilter _filterFloat;
		[SerializeField] private IntegerFilter _filterInteger;
		[SerializeField] private StringFilter _filterString;

		[SerializeField] private bool _valueBoolean;
		[SerializeField] private float _valueFloat;
		[SerializeField] private int _valueInteger;
		[SerializeField] private string _valueString;

		public static bool HasFilter(ParameterType type)
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

		public bool IsFiltered(bool value)
		{
			switch (_filterBoolean)
			{
				case BooleanFilter.None:
					return true;
				case BooleanFilter.Equal:
					return value == _valueBoolean;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public bool IsFiltered(float value)
		{
			switch (_filterFloat)
			{
				case FloatFilter.None:
					return true;
				case FloatFilter.Less:
					return value < _valueFloat;
				case FloatFilter.LessOrEqual:
					return value <= _valueFloat;
				case FloatFilter.Equal:
					return Mathf.Approximately(value, _valueFloat);
				case FloatFilter.GreaterOrEqual:
					return value >= _valueFloat;
				case FloatFilter.Greater:
					return value > _valueFloat;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public bool IsFiltered(int value)
		{
			switch (_filterInteger)
			{
				case IntegerFilter.None:
					return true;
				case IntegerFilter.Less:
					return value < _valueInteger;
				case IntegerFilter.LessOrEqual:
					return value <= _valueInteger;
				case IntegerFilter.Equal:
					return value == _valueInteger;
				case IntegerFilter.GreaterOrEqual:
					return value >= _valueInteger;
				case IntegerFilter.Greater:
					return value > _valueInteger;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public bool IsFiltered(string value)
		{
			switch (_filterString)
			{
				case StringFilter.None:
					return true;
				case StringFilter.Equal:
					return value == _valueString;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}