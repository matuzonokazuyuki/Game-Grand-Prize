using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuen.Enemy
{
    public class CannonFire : MonoBehaviour
    {
        [SerializeField, Header("大砲が発射する弾")] GameObject cannonBallPrefab;
        [SerializeField, Header("発射する場所")] Transform spawnPoint;
        [SerializeField, Header("弾のスピード")] float power;
        [SerializeField, Header("次に発射するの間隔")] float nextAttackTime;
        [SerializeField, Header("弾の消えるタイミング")] float ballDestroyTime;
        [Header("プレイヤーが大砲を持っているかの判定")]public bool hasCannon = false;

        float attackTime;
        Rigidbody rb;

        private void Start()
        {
            if(cannonBallPrefab == null)
            {
                Debug.Log("大砲が発射する弾を付けてください");
            }
            if(spawnPoint == null)
            {
                Debug.Log("発射する場所を付けてください");
            }
        }

        //プレイヤーが大砲を持ったら
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                hasCannon = true;
            }
        }
        //プレイヤーが大砲を離すたら
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                hasCannon = false;
            }
        }
        private void Update()
        {
            if (hasCannon)
            {
                attackTime += Time.deltaTime;
                Fire();
            }
        }
        //大砲が弾を発射する
        void Fire()
        {
            if (attackTime >= nextAttackTime)
            {
                attackTime = 0;
                var cannonBall = Instantiate(cannonBallPrefab, spawnPoint.position, spawnPoint.rotation);
                rb = cannonBall.GetComponent<Rigidbody>();
                rb.velocity = spawnPoint.right * power;
                Destroy(cannonBall, ballDestroyTime);
            }
        }

    }
}
