using System;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Joi.UIEvents.Editor
{
	[CustomEditor(typeof(UIEvent))]
	public class UIEventEditor : UnityEditor.Editor
	{
		private bool _valueBoolean;
		private Color _valueColor;
		private float _valueFloat;
		private GameObject _valueGameObject;
		private int _valueInteger;
		private Material _valueMaterial;
		private Object _valueObject;
		private Sprite _valueSprite;
		private string _valueString;
		private Vector3 _valueVector3;

		public override void OnInspectorGUI()
		{
			var wasEnabled = GUI.enabled;

			GUI.enabled = !Application.isPlaying;

			EditorGUILayout.PropertyField(serializedObject.FindProperty("_type"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("_description"));

			GUI.enabled = Application.isPlaying;

			EditorGUILayout.BeginHorizontal();
			TriggerField();
			EditorGUILayout.EndHorizontal();

			GUI.enabled = wasEnabled;

			serializedObject.ApplyModifiedProperties();
		}

		private void TriggerField()
		{
			var uiEvent = (UIEvent)target;
			switch (uiEvent.Type)
			{
				case ParameterType.None:
					if (GUILayout.Button("Trigger", GUILayout.Width(100)))
					{
						uiEvent.Trigger();
					}

					break;
				case ParameterType.Boolean:
					if (GUILayout.Button("Trigger", GUILayout.Width(100)))
					{
						uiEvent.Trigger(_valueBoolean);
					}

					_valueBoolean = EditorGUILayout.Toggle(_valueBoolean);
					break;
				case ParameterType.Color:
					if (GUILayout.Button("Trigger", GUILayout.Width(100)))
					{
						uiEvent.Trigger(_valueColor);
					}

					_valueColor = EditorGUILayout.ColorField(_valueColor);
					break;
				case ParameterType.Float:
					if (GUILayout.Button("Trigger", GUILayout.Width(100)))
					{
						uiEvent.Trigger(_valueFloat);
					}

					_valueFloat = EditorGUILayout.FloatField(_valueFloat);
					break;
				case ParameterType.GameObject:
					if (GUILayout.Button("Trigger", GUILayout.Width(100)))
					{
						uiEvent.Trigger(_valueGameObject);
					}

					_valueGameObject = EditorGUILayout.ObjectField(_valueGameObject, typeof(GameObject), false) as GameObject;
					break;
				case ParameterType.Integer:
					if (GUILayout.Button("Trigger", GUILayout.Width(100)))
					{
						uiEvent.Trigger(_valueInteger);
					}

					_valueInteger = EditorGUILayout.IntField(_valueInteger);
					break;
				case ParameterType.Material:
					if (GUILayout.Button("Trigger", GUILayout.Width(100)))
					{
						uiEvent.Trigger(_valueMaterial);
					}

					_valueMaterial = EditorGUILayout.ObjectField(_valueMaterial, typeof(Material), false) as Material;
					break;
				case ParameterType.Object:
					if (GUILayout.Button("Trigger", GUILayout.Width(100)))
					{
						uiEvent.Trigger(_valueObject);
					}

					_valueObject = EditorGUILayout.ObjectField(_valueObject, typeof(Object), false);
					break;
				case ParameterType.Sprite:
					if (GUILayout.Button("Trigger", GUILayout.Width(100)))
					{
						uiEvent.Trigger(_valueSprite);
					}

					_valueSprite = EditorGUILayout.ObjectField(_valueSprite, typeof(Sprite), false) as Sprite;
					break;
				case ParameterType.String:
					if (GUILayout.Button("Trigger", GUILayout.Width(100)))
					{
						uiEvent.Trigger(_valueString);
					}

					_valueString = EditorGUILayout.TextField(_valueString);
					break;
				case ParameterType.Vector3:
					if (GUILayout.Button("Trigger", GUILayout.Width(100)))
					{
						uiEvent.Trigger(_valueVector3);
					}

					_valueVector3 = EditorGUILayout.Vector3Field("", _valueVector3);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}