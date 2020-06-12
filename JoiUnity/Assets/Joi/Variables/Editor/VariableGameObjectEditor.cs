using UnityEditor;
using UnityEngine;

namespace Joi.Variables.Editor
{
	[CustomEditor(typeof(VariableGameObject))]
	public class VariableGameObjectEditor : VariableEditor<VariableGameObject, GameObject>
	{
		protected override GameObject UpdateValueField(GameObject value)
		{
			return EditorGUILayout.ObjectField("Runtime Value", value, typeof(GameObject), false) as GameObject;
		}
	}
}