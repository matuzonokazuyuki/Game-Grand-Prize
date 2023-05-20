using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuen.Item
{
    public class SkillPoint : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}