using UnityEditor;
using UnityEngine;

namespace Joi.UIVariables.Editor
{
	[CustomEditor(typeof(UIVariableVector3))]
	public class UIVariableVector3Editor : UIVariableEditor<UIVariableVector3, Vector3>
	{
		protected override Vector3 UpdateValueField(Vector3 value)
		{
			return EditorGUILayout.Vector3Field("Runtime Value", value);
		}
	}
}