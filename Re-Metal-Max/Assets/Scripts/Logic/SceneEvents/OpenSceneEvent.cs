using ReMetalMax.Core;
using ReMetalMax.Core.Event;
using ReMetalMax.Core.Event.NativeEvents;
using ReMetalMax.Util;
using ReMetalMax.Util.Attributes;
using UnityEngine;

namespace ReMetalMax.Logic.SceneEvents
{
    public class OpenSceneEvent : BaseEvent
    {
        public const string StopOpenScene = "StopOpenScene";

        private GameObject m_openSceneSprite;
        private GameObject m_openSceneTitleSprite;
        private GameObject m_openSceneTitleBgSprite;
        private GameObject m_openSceneContentSprite;

        private PlayAnimationEvent m_playAnimationEvent;
        private MessageCallBack m_stopCallBack;

        public OpenSceneEvent(GameObject openSceneSprite, GameObject openSceneTitleSprite, GameObject openSceneTitleBgSprite, GameObject openSceneContentSprite)
        {
            m_openSceneSprite = openSceneSprite;
            m_openSceneTitleSprite = openSceneTitleSprite;
            m_openSceneTitleBgSprite = openSceneTitleBgSprite;
            m_openSceneContentSprite = openSceneContentSprite;

            MessageDispatcher.Instance.MessageRegistration(this);
        }

        [MessageRegisterInfo(Key = StopOpenScene)]
        private void StopCallBack(object msg)
        {
            m_playAnimationEvent?.StopRepush(msg as EventContext);
        }

        public override void Excute(EventContext context)
        {
            const string spriteName = "open_scene_sprite";
            const string spriteTitleName = "open_scene_title_sprite";
            const string spriteTitleBgName = "open_scene_title_bg_sprite";
            const string spriteContentName = "open_scene_content_name";

            context.Push(new BGMEvent("Musics/BGMs/1.Metal max", AudioManager.AudioEvent.Play));

            context.Push(new InstantiateUISpriteEvent(m_openSceneSprite, spriteName)
            {
                Position = Vector3.zero,
                Rotation = Quaternion.identity,
            });

            m_playAnimationEvent = new PlayAnimationEvent((cxt) => cxt[spriteName].GetComponent<Animation>(), "Logo", PlayMode.StopSameLayer)
            {
                OnForceStoped = (ctx) =>
                {
                }
            }
            .Then((ctx) =>
                {
                    context.Push(new InstantiateUISpriteEvent(m_openSceneTitleSprite, spriteTitleName));

                    m_playAnimationEvent = new PlayAnimationEvent(
                        (cxt2) => cxt2[spriteTitleName].GetComponent<Animation>(),
                        "Logo_Title", PlayMode.StopSameLayer)
                    {
                        OnForceStoped = (ctx) => { }
                    };

                    context.Push(new DestroySpriteEvent(spriteName));

                    return m_playAnimationEvent;
                }
            )
            .Then((ctx) =>
                {
                    context.Push(new InstantiateUISpriteEvent(m_openSceneTitleBgSprite, spriteTitleBgName));

                    m_playAnimationEvent = new PlayAnimationEvent(
                        (cxt2) => cxt2[spriteTitleBgName].GetComponent<Animation>(),
                        "Logo_Bg", PlayMode.StopSameLayer)
                    {
                        OnForceStoped = (ctx) => { }
                    };

                    return m_playAnimationEvent;
                }
            )
            .Then((ctx) =>
                {
                    context.Push(new InstantiateUISpriteEvent(m_openSceneContentSprite, spriteContentName));

                    m_playAnimationEvent = new PlayAnimationEvent(
                        (cxt2) => cxt2[spriteContentName].GetComponent<Animation>(),
                        "Logo_Content", PlayMode.StopSameLayer)
                    {
                        OnForceStoped = (ctx) => { }
                    };

                    return m_playAnimationEvent;
                }
            );

            context.Push(m_playAnimationEvent);
        }
    }
}