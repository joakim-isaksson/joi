using UnityEditor;

namespace Joi.UIEvents.Editor
{
	[CustomEditor(typeof(UIEventTrigger))]
	public class UIEventTriggerEditor : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.PropertyField(serializedObject.FindProperty("_trigger"));

			var eventProp = serializedObject.FindProperty("_event");

			var uiEvent = EditorUtility.InstanceIDToObject(eventProp.objectReferenceInstanceIDValue) as UIEvent;
			if (uiEvent != null && uiEvent.Type != ParameterType.None)
			{
				EditorGUILayout.PropertyField(serializedObject.FindProperty("_parameter" + uiEvent.Type));
			}

			EditorGUILayout.PropertyField(serializedObject.FindProperty("_delay"));

			EditorGUILayout.PropertyField(eventProp);

			serializedObject.ApplyModifiedProperties();
		}
	}
}