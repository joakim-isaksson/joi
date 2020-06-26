using System;
using UnityEditor;

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
				if (Converter.HasConverter(joiEvent.ParameterType))
				{
					var eventTypeName = Enum.GetName(typeof(JoiParameterType), joiEvent.ParameterType);
					var converterProp = serializedObject.FindProperty("_convert" + eventTypeName);
					EditorGUILayout.PropertyField(converterProp);

					var converterType = Converter.GetReturnType((Converter.Type) converterProp.intValue);
					var onEventPropName = "_onEvent" + Enum.GetName(typeof(JoiParameterType), converterType);

					EditorGUILayout.PropertyField(serializedObject.FindProperty(onEventPropName));
				}
				else if (joiEvent.ParameterType != JoiParameterType.None)
				{
					var eventTypeName = Enum.GetName(typeof(JoiParameterType), joiEvent.ParameterType);
					EditorGUILayout.PropertyField(serializedObject.FindProperty("_onEvent" + eventTypeName));
				}
				else
				{
					EditorGUILayout.PropertyField(serializedObject.FindProperty("_onEvent"));
				}
			}

			serializedObject.ApplyModifiedProperties();
		}
	}
}