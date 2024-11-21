using UnityEditor;
using UnityEngine;

namespace Joi.UIReferences.Editor
{
	[CustomPropertyDrawer(typeof(UIReferenceFloat))]
	[CustomPropertyDrawer(typeof(UIReferenceBool))]
	[CustomPropertyDrawer(typeof(UIReferenceInt))]
	[CustomPropertyDrawer(typeof(UIReferenceString))]
	[CustomPropertyDrawer(typeof(UIReferenceGameObject))]
	[CustomPropertyDrawer(typeof(UIReferenceVector3))]
	public class UIReferencePropertyDrawer : PropertyDrawer
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