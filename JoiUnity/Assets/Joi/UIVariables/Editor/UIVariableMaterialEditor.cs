using UnityEditor;
using UnityEngine;

namespace Joi.UIVariables.Editor
{
	[CustomEditor(typeof(UIVariableMaterial))]
	public class UIVariableMaterialEditor : UIVariableEditor<UIVariableMaterial, Material>
	{
		protected override Material UpdateValueField(Material value)
		{
			return EditorGUILayout.ObjectField("Runtime Value", value, typeof(Material), false) as Material;
		}
	}
}