using Sora_Extemsion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuen.Player
{
    public class PlayerSkill : MonoBehaviour
    {
        public int skillCount;
        public bool canSkill;
        int skillpoint;
        int maxSkillPoint;

        PlayerData data;

        private async void Start()
        {
            data = await AddressLoader.AddressLoder<PlayerData>(AddressableAssetAddress.PLAYER_DATA);
            maxSkillPoint = data.GetMaxSkillPoint();
            skillpoint = data.GetSkillPoint();
            InitializeSkill();
        }

        private void Update()
        {
            CanSkill();
        }
        //スキル判定の初期化
        public void InitializeSkill()
        {
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
            else if(skillCount <= 0)
            {
                skillCount = 0;
            }
        }
        //SkillPointにあったたらポイントを増やす
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("SkillPoint"))
            {
                skillCount = skillCount + skillpoint;
            }
        }

    }
}
