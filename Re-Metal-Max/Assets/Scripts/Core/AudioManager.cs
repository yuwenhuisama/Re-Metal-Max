using UnityEngine;

using ReMetalMax.Util;
using ReMetalMax.Util.Attributes;

namespace ReMetalMax.Core
{
    public class AudioManager
    {
        public enum AudioEvent
        {
            Play,
            Stop,
            Pause,
        }

        public static readonly AudioManager Instance = new AudioManager();

        private AudioSource m_bgmPlayer;
        private AudioSource m_soundPlayer;

        private MessageCallBack m_playBGMCallBack;
        private MessageCallBack m_playSoundCallBack;

        public void Initialize(AudioSource bgmPlayer, AudioSource soundPlayer)
        {
            m_bgmPlayer = bgmPlayer;
            m_soundPlayer = soundPlayer;

            MessageDispatcher.CoreInstance.MessageRegistration(this);
        }

        [MessageRegisterInfo(Key = AudioEvent.Play)]
        public void PlayBGMCallBack(object msg)
        {
            var clip = Resources.Load<AudioClip>(msg as string);
            m_bgmPlayer.clip = clip;
            m_bgmPlayer.PlayOneShot(clip);
        }

        public void Release()
        {
            m_bgmPlayer = null;
            m_soundPlayer = null;

            MessageDispatcher.CoreInstance.MessageUnregistration(this);
        }
    }
}
