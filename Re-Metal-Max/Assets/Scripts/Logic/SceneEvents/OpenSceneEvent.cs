using ReMetalMax.Core;
using ReMetalMax.Core.Event;
using ReMetalMax.Core.Event.NativeEvents;
using ReMetalMax.Util;
using ReMetalMax.Util.Attributes;
using UnityEngine;

namespace ReMetalMax.Logic.SceneEvents
{   
    public class OpenSceneEvent :  BaseEvent
    {
        public const string StopOpenScene = "StopOpenScene";

        private GameObject m_openSceneSprite;

        private PlayAnimationEvent m_playAnimationEvent;
        private MessageCallBack m_stopCallBack;

        public OpenSceneEvent(GameObject openSceneSprite)
        {
            m_openSceneSprite = openSceneSprite;

            MessageDispatcher.Instance.MessageRegistration(this);
        }

        [MessageRegisterInfo(Key = StopOpenScene)]
        private void StopCallBack(object msg)
        {
            m_playAnimationEvent?.StopRepush(msg as EventContext);
        }

        public override void Excute(EventContext context)
        {
            const string spriteName =  "open_scene_sprite";

            context.Push(new BGMEvent("Musics/BGMs/1.Metal max", AudioManager.AudioEvent.Play));

            context.Push(new InstantiateSpriteEvent(m_openSceneSprite, spriteName)
            {
                Position = Vector3.zero,
                Rotation = Quaternion.identity,
            });

            m_playAnimationEvent = new PlayAnimationEvent(
                (cxt) => cxt[spriteName].GetComponent<Animation>(),
                "Logo", PlayMode.StopAll)
            {
                OnEnd = (cxt) =>
                {
                    Debug.Log("OnEnd");
                    cxt.Push(new DestroySpriteEvent(spriteName));
                    this.IsDone = true;
                    MessageDispatcher.Instance.MessageUnregistration(this);
                },
            };

            context.Push(m_playAnimationEvent);
        }
    }
}