using UnityEngine;
using ReMetalMax.Logic.SceneEvents;
using ReMetalMax.Util;

namespace ReMetalMax.Logic
{
    using NativeEventManager = ReMetalMax.Core.Event.EventManager;

    public class Entry : MonoBehaviour
    {
        public GameObject OpenSceneSprite;

        private void Start()
        {
            NativeEventManager.Instance.Context.Push(new OpenSceneEvent(this.OpenSceneSprite));
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                MessageDispatcher.Instance.Send(OpenSceneEvent.StopOpenScene, NativeEventManager.Instance.Context);
            }
        }
    }
}