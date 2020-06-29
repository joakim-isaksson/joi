using System;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

// TODO: convert to UIElements
namespace Joi.Events.Editor
{
	[CustomEditor(typeof(JoiEvent))]
	public class JoiEventEditor : UnityEditor.Editor
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

			EditorGUILayout.PropertyField(serializedObject.FindProperty("_parameterType"));
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
			var joiEvent = (JoiEvent) target;
			switch (joiEvent.ParameterType)
			{
				case JoiParameterType.None:
					if (GUILayout.Button("Trigger", GUILayout.Width(100)))
					{
						joiEvent.Trigger();
					}

					break;
				case JoiParameterType.Boolean:
					if (GUILayout.Button("Trigger", GUILayout.Width(100)))
					{
						joiEvent.Trigger(_valueBoolean);
					}

					_valueBoolean = EditorGUILayout.Toggle(_valueBoolean);
					break;
				case JoiParameterType.Color:
					if (GUILayout.Button("Trigger", GUILayout.Width(100)))
					{
						joiEvent.Trigger(_valueColor);
					}

					_valueColor = EditorGUILayout.ColorField(_valueColor);
					break;
				case JoiParameterType.Float:
					if (GUILayout.Button("Trigger", GUILayout.Width(100)))
					{
						joiEvent.Trigger(_valueFloat);
					}

					_valueFloat = EditorGUILayout.FloatField(_valueFloat);
					break;
				case JoiParameterType.GameObject:
					if (GUILayout.Button("Trigger", GUILayout.Width(100)))
					{
						joiEvent.Trigger(_valueGameObject);
					}

					_valueGameObject =
						EditorGUILayout.ObjectField(_valueGameObject, typeof(GameObject), false) as GameObject;
					break;
				case JoiParameterType.Integer:
					if (GUILayout.Button("Trigger", GUILayout.Width(100)))
					{
						joiEvent.Trigger(_valueInteger);
					}

					_valueInteger = EditorGUILayout.IntField(_valueInteger);
					break;
				case JoiParameterType.Material:
					if (GUILayout.Button("Trigger", GUILayout.Width(100)))
					{
						joiEvent.Trigger(_valueMaterial);
					}

					_valueMaterial = EditorGUILayout.ObjectField(_valueMaterial, typeof(Material), false) as Material;
					break;
				case JoiParameterType.Object:
					if (GUILayout.Button("Trigger", GUILayout.Width(100)))
					{
						joiEvent.Trigger(_valueObject);
					}

					_valueObject = EditorGUILayout.ObjectField(_valueObject, typeof(Object), false);
					break;
				case JoiParameterType.Sprite:
					if (GUILayout.Button("Trigger", GUILayout.Width(100)))
					{
						joiEvent.Trigger(_valueSprite);
					}

					_valueSprite = EditorGUILayout.ObjectField(_valueSprite, typeof(Sprite), false) as Sprite;
					break;
				case JoiParameterType.String:
					if (GUILayout.Button("Trigger", GUILayout.Width(100)))
					{
						joiEvent.Trigger(_valueString);
					}

					_valueString = EditorGUILayout.TextField(_valueString);
					break;
				case JoiParameterType.Vector3:
					if (GUILayout.Button("Trigger", GUILayout.Width(100)))
					{
						joiEvent.Trigger(_valueVector3);
					}

					_valueVector3 = EditorGUILayout.Vector3Field("", _valueVector3);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}