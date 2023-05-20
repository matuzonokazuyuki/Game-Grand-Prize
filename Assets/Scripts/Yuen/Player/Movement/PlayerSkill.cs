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
        int skillpoint;
        int maxSkillPoint;

        PlayerData data;
        PlayerMove playerMove;

        private async void Awake()
        {
            playerMove = GetComponent<PlayerMove>();
            data = await AddressableLoder.AddressLoder<PlayerData>(AddressableAssetAddress.PLAYER_DATA);

            InitializeSkill();
        }

        private void Update()
        {
            CanSkill();
        }
        //スキル判定の初期化
        public void InitializeSkill()
        {
            if (data != null) 
            {
                maxSkillPoint = data.GetMaxSkillPoint();
                skillpoint = data.GetSkillPoint();
            }

            skillCount = 0;
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
        //SkillPointにあったたらポイントを増やす
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("SkillPoint") && !playerMove.isSkill)
            {
                skillCount = skillCount + skillpoint;
            }
        }

    }
}
