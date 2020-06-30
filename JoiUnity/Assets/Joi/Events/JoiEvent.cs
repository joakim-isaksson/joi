using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Joi.Events
{
	[CreateAssetMenu(menuName = "Joi/Event")]
	public class JoiEvent : ScriptableObject
	{
		public enum ParameterType
		{
			None,
			Boolean,
			Color,
			Float,
			GameObject,
			Integer,
			Material,
			Object,
			Sprite,
			String,
			Vector3
		}

		[SerializeField] private ParameterType _parameter;
		public ParameterType Parameter => _parameter;

#if UNITY_EDITOR
		[TextArea] [SerializeField] private string _description;
#endif

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
			if (_parameter != ParameterType.Boolean)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			OnTriggerBoolean?.Invoke(value);
		}

		public void Trigger(Color value)
		{
			if (_parameter != ParameterType.Color)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			OnTriggerColor?.Invoke(value);
		}

		public void Trigger(float value)
		{
			if (_parameter != ParameterType.Float)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			OnTriggerFloat?.Invoke(value);
		}

		public void Trigger(GameObject value)
		{
			if (_parameter != ParameterType.GameObject)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			OnTriggerGameObject?.Invoke(value);
		}

		public void Trigger(int value)
		{
			if (_parameter != ParameterType.Integer)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			OnTriggerInteger?.Invoke(value);
		}

		public void Trigger(Material value)
		{
			if (_parameter != ParameterType.Material)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			OnTriggerMaterial?.Invoke(value);
		}

		public void Trigger(Object value)
		{
			if (_parameter != ParameterType.Object)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			OnTriggerObject?.Invoke(value);
		}

		public void Trigger(Sprite value)
		{
			if (_parameter != ParameterType.Sprite)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			OnTriggerSprite?.Invoke(value);
		}

		public void Trigger(string value)
		{
			if (_parameter != ParameterType.String)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			OnTriggerString?.Invoke(value);
		}

		public void Trigger(Vector3 value)
		{
			if (_parameter != ParameterType.Vector3)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			OnTriggerVector3?.Invoke(value);
		}
	}
}