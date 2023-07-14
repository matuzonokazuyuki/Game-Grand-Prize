using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuen.Music
{
    public class VoiceManager : MonoBehaviour
    {
        [SerializeField] private AudioClip titleVoice;
        [SerializeField] private AudioClip startVoice;
        [SerializeField] private AudioClip balloonVoice;
        [SerializeField] private AudioClip hitVoiceA;
        [SerializeField] private AudioClip hitVoiceB;
        [SerializeField] private AudioClip skillVoiceA;
        [SerializeField] private AudioClip skillVoiceB;
        [SerializeField] private AudioClip gameClearVoice;
        [SerializeField] private AudioClip gameOverVoice;

        private AudioSource audioSource;


        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        //タイトル画面のボイス
        public void PlayTitleVoice()
        {
            audioSource.clip = titleVoice; 
            audioSource.Play();
        }

        //ゲームスタートのボイス
        public void PlayStartVoice()
        {
            audioSource.clip = startVoice;
            audioSource.Play();
        }

        //風船を吹く時のボイス
        public void PlayBalloonVoice()
        {
            audioSource.clip = balloonVoice;
            audioSource.Play();
        }

        //攻撃が喰らった時にボイス
        public void PlayHitVoice()
        {
            int randomHitNum = Random.Range(0, 2);
            Debug.Log(randomHitNum);
            if (randomHitNum == 0)
            {
                audioSource.clip = hitVoiceA;

            }
            else if (randomHitNum == 1)
            {
                audioSource.clip = hitVoiceB;

            }
            else
            {
                Debug.LogError("Hit Voiceのランダムの数字がエラー");
            }
            audioSource.Play();
        }

        //スキル使う時のボイス
        public void PlaySkillVoice()
        {
            int randomSkillNum = Random.Range(0, 2);
            if (randomSkillNum == 0)
            {
                audioSource.clip = skillVoiceA;

            }
            else if (randomSkillNum == 1)
            {
                audioSource.clip = skillVoiceB;

            }
            else
            {
                Debug.LogError("Skill Voiceのランダムの数字がエラー");
            }
            audioSource.Play();
        }

        //ゲームクリアした時のボイス
        public void PlayGameClearVoice()
        {
            audioSource.clip = gameClearVoice;
            audioSource.Play();
        }

        //ゲームオーバー時のボイス
        public void PlayGameOverVoice()
        {
            audioSource.clip = gameOverVoice;
            audioSource.Play();
            Debug.Log("played");
        }

        //ボイス流れるのを停止
        public void StopVoice()
        {
            audioSource.Stop();
        }
    }
}
