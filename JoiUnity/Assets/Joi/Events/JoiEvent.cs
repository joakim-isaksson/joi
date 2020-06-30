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
		[TextArea] [SerializeField] private string _description;
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
			if (_parameterType != JoiParameterType.Boolean)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			OnTriggerBoolean?.Invoke(value);
		}

		public void Trigger(Color value)
		{
			if (_parameterType != JoiParameterType.Color)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			OnTriggerColor?.Invoke(value);
		}

		public void Trigger(float value)
		{
			if (_parameterType != JoiParameterType.Float)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			OnTriggerFloat?.Invoke(value);
		}

		public void Trigger(GameObject value)
		{
			if (_parameterType != JoiParameterType.GameObject)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			OnTriggerGameObject?.Invoke(value);
		}

		public void Trigger(int value)
		{
			if (_parameterType != JoiParameterType.Integer)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			OnTriggerInteger?.Invoke(value);
		}

		public void Trigger(Material value)
		{
			if (_parameterType != JoiParameterType.Material)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			OnTriggerMaterial?.Invoke(value);
		}

		public void Trigger(Object value)
		{
			if (_parameterType != JoiParameterType.Object)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			OnTriggerObject?.Invoke(value);
		}

		public void Trigger(Sprite value)
		{
			if (_parameterType != JoiParameterType.Sprite)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			OnTriggerSprite?.Invoke(value);
		}

		public void Trigger(string value)
		{
			if (_parameterType != JoiParameterType.String)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			OnTriggerString?.Invoke(value);
		}

		public void Trigger(Vector3 value)
		{
			if (_parameterType != JoiParameterType.Vector3)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			OnTriggerVector3?.Invoke(value);
		}
	}
}