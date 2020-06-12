using UnityEditor;
using UnityEngine;

namespace Joi.Variables.Editor
{
	[CustomEditor(typeof(VariableVector3))]
	public class VariableVector3Editor : VariableEditor<VariableVector3, Vector3>
	{
		protected override Vector3 UpdateValueField(Vector3 value)
		{
			return EditorGUILayout.Vector3Field("Runtime Value", value);
		}
	}
}