using UnityEditor;
using UnityEngine;

namespace Joi.Variables.Editor
{
	[CustomEditor(typeof(VariableMaterial))]
	public class VariableMaterialEditor : VariableEditor<VariableMaterial, Material>
	{
		protected override Material UpdateValueField(Material value)
		{
			return EditorGUILayout.ObjectField("Runtime Value", value, typeof(Material), false) as Material;
		}
	}
}