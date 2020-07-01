using UnityEngine;
using UnityEngine.Events;

namespace Joi.Actions
{
	public class OnStart : MonoBehaviour
	{
		[SerializeField] private UnityEvent _onStart;

		private void Start()
		{
			_onStart?.Invoke();
		}
	}
}