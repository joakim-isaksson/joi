using UnityEditor;

namespace Joi.Events.Editor
{
	[CustomEditor(typeof(EventBool))]
	public class EventBoolEditor : EventEditor<EventBool, bool>
	{
		protected override bool UpdateValueField(bool value)
		{
			return EditorGUILayout.Toggle(value);
		}
	}
}