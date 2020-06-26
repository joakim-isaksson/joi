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
			var converterProp = serializedObject.FindProperty("_converter");

			EditorGUILayout.PropertyField(eventProp);
			EditorGUILayout.PropertyField(converterProp);

			var joiEvent = EditorUtility.InstanceIDToObject(eventProp.objectReferenceInstanceIDValue) as JoiEvent;
			if (joiEvent != null)
			{
				var converterType = (JoiParameterType) converterProp.intValue;
				var propertyName = converterType != JoiParameterType.None
					? "_onEvent" + Enum.GetName(typeof(JoiParameterType), converterType)
					: joiEvent.ParameterType != JoiParameterType.None
						? "_onEvent" + Enum.GetName(typeof(JoiParameterType), joiEvent.ParameterType)
						: "_onEvent";

				EditorGUILayout.PropertyField(serializedObject.FindProperty(propertyName));
			}

			serializedObject.ApplyModifiedProperties();
		}
	}
}