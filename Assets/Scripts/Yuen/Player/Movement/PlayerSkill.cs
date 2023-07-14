using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yuen.UI;
using Yuen_Addressable;

namespace Yuen.Player
{
    public class PlayerSkill : MonoBehaviour
    {
        public int skillCount;
        public bool canSkill;
        public bool isSkill;
        private int skillpoint;
        private int maxSkillPoint;
        private float skillTime;
        private float currentSkillTime;

        [SerializeField] private PlayerData data;
        private SkillGaugeSystem skillGaugeSystem;
        [SerializeField] private GameObject skillGaugeObj;

        private void Update()
        {
            CanSkill();

            if (isSkill)
            {
                UsingSkill();
            }
        }

        //スキル判定の初期化
        public void InitializeSkill()
        {
            maxSkillPoint = data.GetMaxSkillPoint();
            skillpoint = data.GetSkillPoint();
            skillTime = data.GetSkillTime();

            isSkill = false;
            skillCount = 0;
            currentSkillTime = skillTime;
            canSkill = false;
        }

        //スキルを使用する判定
        private void CanSkill()
        {
            if(skillCount >= maxSkillPoint)
            {
                canSkill = true;
                skillCount = maxSkillPoint;
            }
            else if(skillCount < maxSkillPoint)
            {
                canSkill = false;
            }
        }
        //スキルを使っているかどうか
        private void UsingSkill()
        {
            skillGaugeObj.SetActive(true);
            skillGaugeSystem = skillGaugeObj.GetComponent<SkillGaugeSystem>();
            skillGaugeSystem.ResetGauge(skillTime);
            skillGaugeSystem.UpdateGauge(currentSkillTime);

            currentSkillTime -= Time.deltaTime;
            if (currentSkillTime <= 0)
            {
                ResetSkill();
            }
        }
        //スキルのリセット
        private void ResetSkill()
        {
            skillGaugeSystem.gameObject.SetActive(false);
            isSkill = false;
            skillCount = 0;
            currentSkillTime = skillTime;
        }

        //SkillPointにあったたらポイントを増やす
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("SkillPoint") && !isSkill)
            {
                skillCount = skillCount + skillpoint;
            }
        }
    }
}
