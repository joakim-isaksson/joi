using UnityEditor;
using UnityEngine;

namespace Joi.References.Editor
{
	[CustomPropertyDrawer(typeof(ReferenceFloat))]
	[CustomPropertyDrawer(typeof(ReferenceBool))]
	[CustomPropertyDrawer(typeof(ReferenceInt))]
	[CustomPropertyDrawer(typeof(ReferenceString))]
	[CustomPropertyDrawer(typeof(ReferenceGameObject))]
	[CustomPropertyDrawer(typeof(ReferenceVector3))]
	public class ReferencePropertyDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginProperty(position, label, property);

			position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

			var indent = EditorGUI.indentLevel;
			EditorGUI.indentLevel = 0;

			var typeRect = new Rect(position.x, position.y, 20, position.height);
			var valueRect = new Rect(position.x + 20, position.y, position.width - 20, position.height);

			var useVariableProperty = property.FindPropertyRelative("UseVariable");

			var btnTexture = useVariableProperty.boolValue
				? EditorGUIUtility.IconContent("preAudioPlayOn").image
				: EditorGUIUtility.IconContent("preAudioPlayOff").image;

			var valueProperty = useVariableProperty.boolValue
				? property.FindPropertyRelative("Variable")
				: property.FindPropertyRelative("Constant");

			EditorGUI.PropertyField(valueRect, valueProperty, GUIContent.none);

			EditorGUI.BeginChangeCheck();
			if (GUI.Button(typeRect, btnTexture, GUIStyle.none))
			{
				useVariableProperty.boolValue = !useVariableProperty.boolValue;
			}

			if (EditorGUI.EndChangeCheck())
			{
				property.serializedObject.ApplyModifiedProperties();
			}

			EditorGUI.indentLevel = indent;

			EditorGUI.EndProperty();
		}
	}
}