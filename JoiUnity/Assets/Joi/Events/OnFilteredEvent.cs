using System;
using UnityEngine;
using UnityEngine.Events;

namespace Joi.Events
{
	public abstract class OnFilteredEvent<TEvent, TUnityEvent, TValue> : MonoBehaviour
		where TEvent : Event<TValue>
		where TUnityEvent : UnityEvent<TValue>
		where TValue : IComparable<TValue>
	{
		private enum Comparator
		{
			Less,
			LessOrEqual,
			Equal,
			GreaterOrEqual,
			Greater
		}

		[SerializeField] private TEvent _input;
		[SerializeField] private Comparator _comparator;
		[SerializeField] private TValue _compareTo;
		[SerializeField] private TUnityEvent _output;

		private void Reset()
		{
			_input = null;
			_comparator = Comparator.Equal;
			_compareTo = default;
			_output = null;
		}

		private void OnEnable()
		{
			if (_input == null)
			{
				Debug.LogWarning("Missing reference to Input", this);
				return;
			}

			_input.OnTrigger += FilterEvent;
		}

		private void OnDisable()
		{
			if (_input == null)
			{
				Debug.LogWarning("Missing reference to Input", this);
				return;
			}

			_input.OnTrigger -= FilterEvent;
		}

		private void FilterEvent(TValue value)
		{
			var result = value.CompareTo(_compareTo);

			switch (_comparator)
			{
				case Comparator.Less:
					if (result < 0)
					{
						_output?.Invoke(value);
					}

					break;
				case Comparator.LessOrEqual:
					if (result <= 0)
					{
						_output?.Invoke(value);
					}

					break;
				case Comparator.Equal:
					if (result == 0)
					{
						_output?.Invoke(value);
					}

					break;
				case Comparator.GreaterOrEqual:
					if (result >= 0)
					{
						_output?.Invoke(value);
					}

					break;
				case Comparator.Greater:
					if (result > 0)
					{
						_output?.Invoke(value);
					}

					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}