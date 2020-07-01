using UnityEditor;

namespace Joi.Events.Editor
{
	[CustomEditor(typeof(JoiEventTrigger))]
	public class JoiEventTriggerEditor : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.PropertyField(serializedObject.FindProperty("_trigger"));

			var eventProp = serializedObject.FindProperty("_event");

			var joiEvent = EditorUtility.InstanceIDToObject(eventProp.objectReferenceInstanceIDValue) as JoiEvent;
			if (joiEvent != null && joiEvent.Type != ParameterType.None)
			{
				EditorGUILayout.PropertyField(serializedObject.FindProperty("_parameter" + joiEvent.Type));
			}

			EditorGUILayout.PropertyField(serializedObject.FindProperty("_delay"));

			EditorGUILayout.PropertyField(eventProp);

			serializedObject.ApplyModifiedProperties();
		}
	}
}