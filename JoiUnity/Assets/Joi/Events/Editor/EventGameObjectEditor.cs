using UnityEditor;
using UnityEngine;

namespace Joi.Events.Editor
{
	[CustomEditor(typeof(EventGameObject))]
	public class EventGameObjectEditor : EventEditor<EventGameObject, GameObject>
	{
		protected override GameObject UpdateValueField(GameObject value)
		{
			return EditorGUILayout.ObjectField(value, typeof(GameObject), false) as GameObject;
		}
	}
}