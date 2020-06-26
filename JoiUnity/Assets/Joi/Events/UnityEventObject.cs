using System;
using UnityEngine.Events;
using Object = UnityEngine.Object;

namespace Joi.Events
{
	[Serializable]
	public class UnityEventObject : UnityEvent<Object>
	{
	}
}