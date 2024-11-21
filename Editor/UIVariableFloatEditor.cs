using UnityEditor;

namespace Joi.UIVariables.Editor
{
	[CustomEditor(typeof(UIVariableFloat))]
	public class UIVariableFloatEditor : UIVariableEditor<UIVariableFloat, float>
	{
		protected override float UpdateValueField(float value)
		{
			return EditorGUILayout.FloatField("Runtime Value", value);
		}
	}
}