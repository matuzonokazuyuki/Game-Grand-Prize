using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yuen.Item;

namespace Yuen.Item
{
    public class SkillPointSystem : MonoBehaviour
    {
        [SerializeField] GameObject[] skillPointObject;

        private void Start()
        {
            InitializeSkillPoint();
        }
        public void InitializeSkillPoint() 
        {
            for (int i = 0; i < skillPointObject.Length; i++)
            {
                skillPointObject[i].gameObject.SetActive(true);
            }
        }
    }
}
