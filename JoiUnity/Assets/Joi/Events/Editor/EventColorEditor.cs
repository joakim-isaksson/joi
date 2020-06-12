using UnityEditor;
using UnityEngine;

namespace Joi.Events.Editor
{
	[CustomEditor(typeof(EventColor))]
	public class EventColorEditor : EventEditor<EventColor, Color>
	{
		protected override Color UpdateValueField(Color value)
		{
			return EditorGUILayout.ColorField(value);
		}
	}
}