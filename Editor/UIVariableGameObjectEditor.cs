using UnityEditor;
using UnityEngine;

namespace Joi.UIVariables.Editor
{
	[CustomEditor(typeof(UIVariableGameObject))]
	public class UIVariableGameObjectEditor : UIVariableEditor<UIVariableGameObject, GameObject>
	{
		protected override GameObject UpdateValueField(GameObject value)
		{
			return EditorGUILayout.ObjectField("Runtime Value", value, typeof(GameObject), false) as GameObject;
		}
	}
}