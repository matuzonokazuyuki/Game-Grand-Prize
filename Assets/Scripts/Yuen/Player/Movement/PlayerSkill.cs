using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yuen_Addressable;

namespace Yuen.Player
{
    public class PlayerSkill : MonoBehaviour
    {
        public int skillCount;
        public bool canSkill;
        public bool isSkill;
        int skillpoint;
        int maxSkillPoint;
        float skillTime;
        float currentSkillTime;

        PlayerData data;

        private async void Awake()
        {
            data = await AddressableLoder.AddressLoder<PlayerData>(AddressableAssetAddress.PLAYER_DATA);

            InitializeSkill();
        }

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
            if (data != null) 
            {
                maxSkillPoint = data.GetMaxSkillPoint();
                skillpoint = data.GetSkillPoint();
                skillTime = data.GetSkillTime();
            }

            ResetSkill();
            canSkill = false;

        }
        //スキルを使用する判定
        void CanSkill()
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
            currentSkillTime -= Time.deltaTime;
            if (currentSkillTime <= 0)
            {
                ResetSkill();
            }
        }
        //スキルのリセット
         void ResetSkill()
        {
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
