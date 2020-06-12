using UnityEditor;
using UnityEngine;

namespace Joi.Variables.Editor
{
	[CustomEditor(typeof(VariableColor))]
	public class VariableColorEditor : VariableEditor<VariableColor, Color>
	{
		protected override Color UpdateValueField(Color value)
		{
			return EditorGUILayout.ColorField("Runtime Value", value);
		}
	}
}