using UnityEngine;

namespace Joi.Functions
{
	[CreateAssetMenu(menuName = "Joi/Functions")]
	public class Functions : ScriptableObject
	{
		public void Destroy_(Object obj)
		{
			Destroy(obj);
		}

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