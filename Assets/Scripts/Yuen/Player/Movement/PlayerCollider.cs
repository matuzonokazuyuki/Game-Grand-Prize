using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuen.Player
{
    public class PlayerCollider : MonoBehaviour
    {
        [SerializeField] GameObject player;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Untagged"))
            {

            }
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
