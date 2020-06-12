using UnityEditor;
using UnityEngine;

namespace Joi.Events.Editor
{
	[CustomEditor(typeof(EventSprite))]
	public class EventSpriteEditor : EventEditor<EventSprite, Sprite>
	{
		protected override Sprite UpdateValueField(Sprite value)
		{
			return EditorGUILayout.ObjectField(value, typeof(Sprite), false) as Sprite;
		}
	}
}