using System;
using UnityEditor;
using UnityEngine;

namespace Joi.UIEvents.Editor
{
	[CustomPropertyDrawer(typeof(Converter))]
	public class ConverterDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginProperty(position, label, property);

			position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

			var indent = EditorGUI.indentLevel;
			EditorGUI.indentLevel = 0;

			var filterRect = new Rect(position.x, position.y, position.width, position.height);

			var eventProp = property.serializedObject.FindProperty("_event");
			var uiEvent = EditorUtility.InstanceIDToObject(eventProp.objectReferenceInstanceIDValue) as UIEvent;
			if (uiEvent != null)
			{
				var eventTypeName = Enum.GetName(typeof(ParameterType), uiEvent.Type);
				EditorGUI.PropertyField(filterRect, property.FindPropertyRelative("_converter" + eventTypeName), GUIContent.none);
			}

			EditorGUI.indentLevel = indent;

			EditorGUI.EndProperty();
		}
	}
}