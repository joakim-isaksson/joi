using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Joi.Events
{
	[CreateAssetMenu(menuName = "Joi/Event")]
	public class JoiEvent : ScriptableObject
	{
		[SerializeField] private JoiParameterType _parameterType;

#if UNITY_EDITOR
		[SerializeField] private string _description;
#endif

		public JoiParameterType ParameterType => _parameterType;

		public Action OnTrigger;
		public Action<bool> OnTriggerBoolean;
		public Action<Color> OnTriggerColor;
		public Action<float> OnTriggerFloat;
		public Action<GameObject> OnTriggerGameObject;
		public Action<int> OnTriggerInteger;
		public Action<Material> OnTriggerMaterial;
		public Action<Object> OnTriggerObject;
		public Action<Sprite> OnTriggerSprite;
		public Action<string> OnTriggerString;
		public Action<Vector3> OnTriggerVector3;

		public void Trigger()
		{
			OnTrigger?.Invoke();
		}

		public void Trigger(bool value)
		{
			OnTriggerBoolean?.Invoke(value);
		}

		public void Trigger(Color value)
		{
			OnTriggerColor?.Invoke(value);
		}

		public void Trigger(float value)
		{
			OnTriggerFloat?.Invoke(value);
		}

		public void Trigger(GameObject value)
		{
			OnTriggerGameObject?.Invoke(value);
		}

		public void Trigger(int value)
		{
			OnTriggerInteger?.Invoke(value);
		}

		public void Trigger(Material value)
		{
			OnTriggerMaterial?.Invoke(value);
		}

		public void Trigger(Object value)
		{
			OnTriggerObject?.Invoke(value);
		}

		public void Trigger(Sprite value)
		{
			OnTriggerSprite?.Invoke(value);
		}

		public void Trigger(string value)
		{
			OnTriggerString?.Invoke(value);
		}

		public void Trigger(Vector3 value)
		{
			OnTriggerVector3?.Invoke(value);
		}
	}
}