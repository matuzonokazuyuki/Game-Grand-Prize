using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yuen.Item;

namespace Yuen.Item
{
    public class SkillPointSystem : MonoBehaviour
    {
        [SerializeField] private GameObject[] skillPointObject;

        private void Awake()
        {
            InitializeSkillPoint();
        }

        /// <summary>
        /// リセット
        /// </summary>
        public void InitializeSkillPoint() 
        {
            if(skillPointObject == null) return;

            for (int i = 0; i < skillPointObject.Length; i++)
            {
                skillPointObject[i].gameObject.SetActive(true);
            }
        }
    }
}
