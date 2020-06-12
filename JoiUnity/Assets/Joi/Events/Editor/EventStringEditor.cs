using UnityEditor;

namespace Joi.Events.Editor
{
	[CustomEditor(typeof(EventString))]
	public class EventStringEditor : EventEditor<EventString, string>
	{
		protected override string UpdateValueField(string value)
		{
			return EditorGUILayout.TextField(value);
		}
	}
}