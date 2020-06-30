// using System.Collections;
// using UnityEngine;
//
// namespace Joi.Events
// {
// 	// TODO
// 	public class JoiEventTrigger : MonoBehaviour
// 	{
// 		public enum TriggerType
// 		{
// 			Manual,
// 			OnAwake,
// 			OnStart,
// 			OnEnable,
// 			OnDisable,
// 			OnDestroy
// 		}
//
// 		[SerializeField] private TriggerType _trigger;
// 		[SerializeField] private TValue _triggerValue;
// 		[SerializeField] private float _triggerDelay;
// 		[SerializeField] private TEvent _event;
//
// 		private void Reset()
// 		{
// 			_trigger = TriggerType.Manual;
// 			_triggerValue = default;
// 			_triggerDelay = 0f;
// 			_event = null;
// 		}
//
// 		private void Awake()
// 		{
// 			if (_trigger == TriggerType.OnAwake)
// 			{
// 				Trigger();
// 			}
// 		}
//
// 		private void Start()
// 		{
// 			if (_trigger == TriggerType.OnStart)
// 			{
// 				Trigger();
// 			}
// 		}
//
// 		private void OnEnable()
// 		{
// 			if (_trigger == TriggerType.OnEnable)
// 			{
// 				Trigger();
// 			}
// 		}
//
// 		private void OnDisable()
// 		{
// 			if (_trigger == TriggerType.OnDisable)
// 			{
// 				Trigger();
// 			}
// 		}
//
// 		private void OnDestroy()
// 		{
// 			if (_trigger == TriggerType.OnDestroy)
// 			{
// 				Trigger();
// 			}
// 		}
//
// 		public void Trigger()
// 		{
// 			Trigger(_triggerValue);
// 		}
//
// 		public void Trigger(TValue value)
// 		{
// 			if (_triggerDelay > 0f)
// 			{
// 				StartCoroutine(InvokeAfterDelay(value));
// 			}
// 			else
// 			{
// 				if (_event != null)
// 				{
// 					_event.Trigger(value);
// 				}
// 			}
// 		}
//
// 		private IEnumerator InvokeAfterDelay(TValue value)
// 		{
// 			yield return new WaitForSeconds(_triggerDelay);
//
// 			if (_event != null)
// 			{
// 				_event.Trigger(value);
// 			}
// 		}
// 	}
// }