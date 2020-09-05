using UnityEngine;

namespace ReMetalMax.Core.MonoBehaviourBridge
{
    using NativeEventManager = ReMetalMax.Core.Event.EventManager;
    public class EventManager : MonoBehaviour
    {
        private void Start()
        {

        }

        private void Update()
        {
            NativeEventManager.Instance.Update();
        }

        private void OnDestroy()
        {

        }
    }
}