using UnityEditor;

namespace Joi.UIVariables.Editor
{
	[CustomEditor(typeof(UIVariableString))]
	public class UIVariableStringEditor : UIVariableEditor<UIVariableString, string>
	{
		protected override string UpdateValueField(string value)
		{
			return EditorGUILayout.TextField("Runtime Value", value);
		}
	}
}