using System;
using UnityEditor;
using UnityEngine;

namespace Joi.UIEvents.Editor
{
	[CustomPropertyDrawer(typeof(Filter))]
	public class FilterDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginProperty(position, label, property);

			position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

			var indent = EditorGUI.indentLevel;
			EditorGUI.indentLevel = 0;

			var eventProp = property.serializedObject.FindProperty("_event");
			var uiEvent = EditorUtility.InstanceIDToObject(eventProp.objectReferenceInstanceIDValue) as UIEvent;
			if (uiEvent != null)
			{
				var halfWidth = position.width / 2;
				var filterRect = new Rect(position.x, position.y, halfWidth, position.height);
				var valueRect = new Rect(position.x + halfWidth, position.y, halfWidth, position.height);

				var eventTypeName = Enum.GetName(typeof(ParameterType), uiEvent.Type);
				EditorGUI.PropertyField(filterRect, property.FindPropertyRelative("_filter" + eventTypeName), GUIContent.none);

				EditorGUI.PropertyField(valueRect, property.FindPropertyRelative("_value" + eventTypeName), GUIContent.none);
			}

			EditorGUI.indentLevel = indent;

			EditorGUI.EndProperty();
		}
	}
}