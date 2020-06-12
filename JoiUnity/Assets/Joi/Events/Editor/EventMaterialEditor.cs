using UnityEditor;
using UnityEngine;

namespace Joi.Events.Editor
{
	[CustomEditor(typeof(EventMaterial))]
	public class EventMaterialEditor : EventEditor<EventMaterial, Material>
	{
		protected override Material UpdateValueField(Material value)
		{
			return EditorGUILayout.ObjectField(value, typeof(Material), false) as Material;
		}
	}
}