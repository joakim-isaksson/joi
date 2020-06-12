using UnityEditor;

namespace Joi.Events.Editor
{
	[CustomEditor(typeof(EventFloat))]
	public class EventFloatEditor : EventEditor<EventFloat, float>
	{
		protected override float UpdateValueField(float value)
		{
			return EditorGUILayout.FloatField(value);
		}
	}
}