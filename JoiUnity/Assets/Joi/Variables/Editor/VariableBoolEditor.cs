using UnityEditor;

namespace Joi.Variables.Editor
{
	[CustomEditor(typeof(VariableBool))]
	public class VariableBoolEditor : VariableEditor<VariableBool, bool>
	{
		protected override bool UpdateValueField(bool value)
		{
			return EditorGUILayout.Toggle("Runtime Value", value);
		}
	}
}