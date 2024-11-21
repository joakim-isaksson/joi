using UnityEditor;

namespace Joi.UIVariables.Editor
{
	[CustomEditor(typeof(UIVariableInt))]
	public class UIVariableIntEditor : UIVariableEditor<UIVariableInt, int>
	{
		protected override int UpdateValueField(int value)
		{
			return EditorGUILayout.IntField("Runtime Value", value);
		}
	}
}