using UnityEditor;
using UnityEngine;

namespace Joi.Variables.Editor
{
	[CustomEditor(typeof(VariableSprite))]
	public class VariableSpriteEditor : VariableEditor<VariableSprite, Sprite>
	{
		protected override Sprite UpdateValueField(Sprite value)
		{
			return EditorGUILayout.ObjectField("Runtime Value", value, typeof(Sprite), false) as Sprite;
		}
	}
}