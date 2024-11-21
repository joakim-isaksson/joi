using UnityEditor;
using UnityEngine;

namespace Joi.UIVariables.Editor
{
	[CustomEditor(typeof(UIVariableColor))]
	public class UIUIVariableColorEditor : UIVariableEditor<UIVariableColor, Color>
	{
		protected override Color UpdateValueField(Color value)
		{
			return EditorGUILayout.ColorField("Runtime Value", value);
		}
	}
}