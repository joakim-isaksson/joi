using UnityEditor;
using UnityEngine;

namespace Joi.Events.Editor
{
	[CustomEditor(typeof(Event))]
	public class EventEditor : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			EditorGUILayout.Space();

			EditorGUILayout.BeginHorizontal();

			GUI.enabled = Application.isPlaying;

			if (GUILayout.Button("Trigger", GUILayout.ExpandWidth(true)))
			{
				((Event) target).Trigger();
			}

			EditorGUILayout.EndHorizontal();
		}
	}

	public abstract class EventEditor<TEvent, TValue> : UnityEditor.Editor
		where TEvent : Event<TValue>
	{
		private TValue _value;

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			EditorGUILayout.Space();

			EditorGUILayout.BeginHorizontal();

			GUI.enabled = Application.isPlaying;

			if (GUILayout.Button("Trigger", GUILayout.Width(100)))
			{
				((TEvent) target).Trigger(_value);
			}

			_value = UpdateValueField(_value);

			EditorGUILayout.EndHorizontal();
		}

		protected abstract TValue UpdateValueField(TValue value);
	}
}