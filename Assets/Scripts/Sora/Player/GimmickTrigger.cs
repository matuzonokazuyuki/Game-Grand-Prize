using UnityEngine;
using Sora_Constans;

namespace Sora_Player
{
    public class GimmickTrigger : MonoBehaviour
    {
        [SerializeField, Header("プレイヤーか風船か")] private PlayerType type;
        private CharacterMovement character;

        private void Start()
        {
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
                character.BalloonAllDestroy();
            }
            else if (target.CompareTag(TagName.Wall))
            {
                character.BalloonDestroy();
            }
        }
    }
}