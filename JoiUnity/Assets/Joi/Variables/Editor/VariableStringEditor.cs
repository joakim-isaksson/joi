using UnityEditor;

namespace Joi.Variables.Editor
{
	[CustomEditor(typeof(VariableString))]
	public class VariableStringEditor : VariableEditor<VariableString, string>
	{
		protected override string UpdateValueField(string value)
		{
			return EditorGUILayout.TextField("Runtime Value", value);
		}
	}
}