using System;
using UnityEngine.Events;
using Object = UnityEngine.Object;

namespace Joi.UnityEvents
{
	[Serializable]
	public class UnityEventObject : UnityEvent<Object>
	{
	}
}