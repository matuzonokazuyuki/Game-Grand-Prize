using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sora_Constans;
using UniRx;
using System;

namespace Sora_Player
{
    public class GimmickTrigger : MonoBehaviour
    {
        [SerializeField, Header("プレイヤーか風船か")] private PlayerType type;
        private CharacterMovement character;

        private void Start()
        {
            Debug.Log(gameObject.name + "//" + type);
            character = GameObject.FindGameObjectWithTag(TagName.Player).GetComponent<CharacterMovement>();
        }

        private void OnTriggerEnter(Collider other)
        {
            switch (type)
            {
                case PlayerType.Player:
                    PlayerProcess(other.gameObject);
                    break;
                case PlayerType.Ballopn:
                    BalloonProcess(other.gameObject);
                    break;
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            switch (type)
            {
                case PlayerType.Player:
                    PlayerProcess(other.gameObject);
                    break;
                case PlayerType.Ballopn:
                    BalloonProcess(other.gameObject);
                    break;
            }
        }

        private void PlayerProcess(GameObject target)
        {
            if (target.CompareTag(TagName.Needle))
            {
                Debug.Log("player");
                character.Dead();
            }
            else if (target.CompareTag(TagName.Airflow))
            {
                // TODO: 気流の処理
            }
        }

        private void BalloonProcess(GameObject target)
        {
            if (target.CompareTag(TagName.Needle))
            {
                Debug.Log("Balloon");
                character.BalloonAllDestroy();
            }
            else if (target.CompareTag(TagName.Wall))
            {
                character.BalloonDestroy();
            }
        }
    }
}