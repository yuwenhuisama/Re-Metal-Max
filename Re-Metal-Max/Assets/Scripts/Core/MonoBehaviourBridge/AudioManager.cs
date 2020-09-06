using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ReMetalMax.Core.MonoBehaviourBridge
{
    using NativeAudioManager = ReMetalMax.Core.AudioManager;

    public class AudioManager : MonoBehaviour
    {
        public GameObject BgmAudioSrouce;
        public GameObject SoundAudioSource;

        // Start is called before the first frame update
        void Start()
        {
            NativeAudioManager.Instance.Initialize(
                this.BgmAudioSrouce.GetComponent<AudioSource>(),
                this.SoundAudioSource.GetComponent<AudioSource>());
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
