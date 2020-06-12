using UnityEngine;

namespace Joi.Actions
{
	[CreateAssetMenu(menuName = "Joi/Actions/Toggle")]
	public class ActionToggle : ScriptableObject
	{
		public void Toggle(GameObject obj)
		{
			obj.SetActive(obj.activeSelf);
		}

		public void Toggle(Behaviour behaviour)
		{
			behaviour.enabled = !behaviour.enabled;
		}

		public void Toggle(Renderer renderer)
		{
			renderer.enabled = !renderer.enabled;
		}
	}
}