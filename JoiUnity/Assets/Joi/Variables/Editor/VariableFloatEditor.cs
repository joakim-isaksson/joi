using UnityEditor;

namespace Joi.Variables.Editor
{
	[CustomEditor(typeof(VariableFloat))]
	public class VariableFloatEditor : VariableEditor<VariableFloat, float>
	{
		protected override float UpdateValueField(float value)
		{
			return EditorGUILayout.FloatField("Runtime Value", value);
		}
	}
}