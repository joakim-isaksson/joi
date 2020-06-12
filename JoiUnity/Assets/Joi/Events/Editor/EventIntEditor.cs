using UnityEditor;

namespace Joi.Events.Editor
{
	[CustomEditor(typeof(EventInt))]
	public class EventIntEditor : EventEditor<EventInt, int>
	{
		protected override int UpdateValueField(int value)
		{
			return EditorGUILayout.IntField(value);
		}
	}
}