using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuen.Music
{
    public class PlayTitleVoice : MonoBehaviour
    {
        [SerializeField] VoiceManager voice;
        private void Start()
        {
            voice.StopVoice();
            voice.PlayTitleVoice();
        }
    }
}
