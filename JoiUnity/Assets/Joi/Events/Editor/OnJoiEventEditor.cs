using System;
using UnityEditor;

// TODO: convert to UIElements
namespace Joi.Events.Editor
{
	[CustomEditor(typeof(OnJoiEvent))]
	public class OnJoiEventEditor : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			var eventProp = serializedObject.FindProperty("_event");
			EditorGUILayout.PropertyField(eventProp);

			var joiEvent = EditorUtility.InstanceIDToObject(eventProp.objectReferenceInstanceIDValue) as JoiEvent;
			if (joiEvent != null)
			{
				var eventTypeName = Enum.GetName(typeof(ParameterType), joiEvent.Type);

				if (Filter.HasFilter(joiEvent.Type))
				{
					var filterProp = serializedObject.FindProperty("_filter");
					EditorGUILayout.PropertyField(filterProp);
				}

				if (Converter.HasConverter(joiEvent.Type))
				{
					var converterProp = serializedObject.FindProperty("_converter");
					EditorGUILayout.PropertyField(converterProp);

					var converterReturnType = GetConverterReturnType(converterProp, joiEvent.Type);
					EditorGUILayout.PropertyField(serializedObject.FindProperty("_onEvent" + converterReturnType));
				}
				else if (joiEvent.Type != ParameterType.None)
				{
					EditorGUILayout.PropertyField(serializedObject.FindProperty("_onEvent" + eventTypeName));
				}
				else
				{
					EditorGUILayout.PropertyField(serializedObject.FindProperty("_onEvent"));
				}
			}

			serializedObject.ApplyModifiedProperties();
		}

		private static ParameterType GetConverterReturnType(SerializedProperty converterProp, ParameterType type)
		{
			var typeProp = converterProp.FindPropertyRelative("_converter" + type);

			switch (type)
			{
				case ParameterType.Boolean:
					return Converter.GetReturnType((Converter.BooleanConverter) typeProp.intValue);
				case ParameterType.Float:
					return Converter.GetReturnType((Converter.FloatConverter) typeProp.intValue);
				case ParameterType.Integer:
					return Converter.GetReturnType((Converter.IntegerConverter) typeProp.intValue);
				case ParameterType.String:
					return Converter.GetReturnType((Converter.StringConverter) typeProp.intValue);
				default:
					throw new ArgumentOutOfRangeException(nameof(type), type, null);
			}
		}
	}
}