using UnityEngine;

namespace Joi.Variables.Editor
{
	public abstract class VariableEditor<TVariable, TValue> : UnityEditor.Editor
		where TVariable : Object, IVariable<TValue>
	{
		public override void OnInspectorGUI()
		{
			GUI.enabled = !Application.isPlaying;

			base.OnInspectorGUI();

			GUI.enabled = Application.isPlaying;

			var variable = target as TVariable;

			var value = variable != null ? variable.Value : default;
			value = UpdateValueField(value);

			if (variable != null)
			{
				variable.Value = value;
			}
		}

		protected abstract TValue UpdateValueField(TValue value);
	}
}