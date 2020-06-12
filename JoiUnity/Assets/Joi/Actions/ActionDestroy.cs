using UnityEngine;

namespace Joi.Actions
{
	[CreateAssetMenu(menuName = "Joi/Actions/Destroy")]
	public class ActionDestroy : ScriptableObject
	{
		public void DoDestroy(Object obj)
		{
			Destroy(obj);
		}
	}
}