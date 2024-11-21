using UnityEditor;
using UnityEngine;

namespace Joi.UIVariables.Editor
{
	[CustomEditor(typeof(UIVariableSprite))]
	public class UIVariableSpriteEditor : UIVariableEditor<UIVariableSprite, Sprite>
	{
		protected override Sprite UpdateValueField(Sprite value)
		{
			return EditorGUILayout.ObjectField("Runtime Value", value, typeof(Sprite), false) as Sprite;
		}
	}
}