using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sora_Result;

namespace Sora_Player
{
    public class GameClearArea : MonoBehaviour
    {
        private PlayerController player;

        public void Init(PlayerController _player)
        {
            player = _player;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                // TODO:クリア時のプレイヤーの処理
                ResultViewPresenter.GameClear();
            }
        }
    }
}