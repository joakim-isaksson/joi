using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Joi.UIEvents
{
	[CreateAssetMenu(menuName = "Joi/UI Event")]
	public class UIEvent : ScriptableObject
	{
		[SerializeField] private ParameterType _type;

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
		
		public ParameterType Type => _type;

		public void Trigger()
		{
			OnTrigger?.Invoke();
		}

		public void Trigger(bool value)
		{
			if (_type != ParameterType.Boolean)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			OnTriggerBoolean?.Invoke(value);
		}

		public void Trigger(Color value)
		{
			if (_type != ParameterType.Color)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			OnTriggerColor?.Invoke(value);
		}

		public void Trigger(float value)
		{
			if (_type != ParameterType.Float)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			OnTriggerFloat?.Invoke(value);
		}

		public void Trigger(GameObject value)
		{
			if (_type != ParameterType.GameObject)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			OnTriggerGameObject?.Invoke(value);
		}

		public void Trigger(int value)
		{
			if (_type != ParameterType.Integer)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			OnTriggerInteger?.Invoke(value);
		}

		public void Trigger(Material value)
		{
			if (_type != ParameterType.Material)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			OnTriggerMaterial?.Invoke(value);
		}

		public void Trigger(Object value)
		{
			if (_type != ParameterType.Object)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			OnTriggerObject?.Invoke(value);
		}

		public void Trigger(Sprite value)
		{
			if (_type != ParameterType.Sprite)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			OnTriggerSprite?.Invoke(value);
		}

		public void Trigger(string value)
		{
			if (_type != ParameterType.String)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			OnTriggerString?.Invoke(value);
		}

		public void Trigger(Vector3 value)
		{
			if (_type != ParameterType.Vector3)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			OnTriggerVector3?.Invoke(value);
		}
	}
}