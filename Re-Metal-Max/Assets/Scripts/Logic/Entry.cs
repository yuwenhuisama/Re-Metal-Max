using UnityEngine;
using ReMetalMax.Logic.SceneEvents;
using ReMetalMax.Util;

namespace ReMetalMax.Logic
{
    using NativeEventManager = ReMetalMax.Core.Event.EventManager;

    public class Entry : MonoBehaviour
    {
        public GameObject OpenSceneSprite;
        public GameObject OpenSceneTitleSprite;
        public GameObject OpenSceneTitleBgSprite;
        public GameObject OpenSceneContentSprite;

        private void Start()
        {
            NativeEventManager.Instance.Context.Push(
                new OpenSceneEvent(this.OpenSceneSprite, this.OpenSceneTitleSprite, this.OpenSceneTitleBgSprite, this.OpenSceneContentSprite));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                MessageDispatcher.Instance.Send(OpenSceneEvent.StopOpenScene, NativeEventManager.Instance.Context);
            }
        }
    }
}