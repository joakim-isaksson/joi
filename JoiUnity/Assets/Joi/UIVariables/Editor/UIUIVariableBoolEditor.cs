using UnityEditor;

namespace Joi.UIVariables.Editor
{
	[CustomEditor(typeof(UIVariableBool))]
	public class UIUIVariableBoolEditor : UIVariableEditor<UIVariableBool, bool>
	{
		protected override bool UpdateValueField(bool value)
		{
			return EditorGUILayout.Toggle("Runtime Value", value);
		}
	}
}