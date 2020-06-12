using UnityEditor;

namespace Joi.Variables.Editor
{
	[CustomEditor(typeof(VariableInt))]
	public class VariableIntEditor : VariableEditor<VariableInt, int>
	{
		protected override int UpdateValueField(int value)
		{
			return EditorGUILayout.IntField("Runtime Value", value);
		}
	}
}