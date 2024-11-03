using UnityEngine;
using UnityEngine.Events;

namespace Joi.UnityEvents
{
    public class UnityEventTrigger : MonoBehaviour
    {
        public enum TriggerType
        {
            Manual,
            OnAwake,
            OnStart,
            OnEnable,
            OnDisable,
            OnDestroy
        }

        [SerializeField] private TriggerType _trigger;
        [SerializeField] private UnityEvent _onTrigger;
        
        private void Awake()
        {
            if (_trigger == TriggerType.OnAwake)
            {
                Trigger();
            }
        }
        
        private void Start()
        {
            if (_trigger == TriggerType.OnStart)
            {
                Trigger();
            }
        }

        private void OnEnable()
        {
            if (_trigger == TriggerType.OnEnable)
            {
                Trigger();
            }
        }

        private void OnDisable()
        {
            if (_trigger == TriggerType.OnDisable)
            {
                Trigger();
            }
        }

        private void OnDestroy()
        {
            if (_trigger == TriggerType.OnDestroy)
            {
                Trigger();
            }
        }

        public void Trigger()
        {
            _onTrigger?.Invoke();
        }
    }
}
