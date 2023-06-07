using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yuen.Player;

namespace Yuen.UI
{
    public class SkillUI : MonoBehaviour
    {
        PlayerSkill playerSkill;
        [SerializeField, Header("Player")] GameObject player;
        [SerializeField, Header("スキルケージの画像UI参照")] Image imageBlue, imageYellow, imageRed;

        Color redColor, yellowColor, blueColor;


        // Start is called before the first frame update
        void Start()
        {
            playerSkill = player.GetComponent<PlayerSkill>();

            redColor = imageRed.color;
            yellowColor = imageYellow.color;
            blueColor = imageBlue.color;
        }

        // Update is called once per frame
        void Update()
        {
            if (playerSkill != null)
            {
                ChangeSkillUI();
            }
            else
            {
                Debug.Log("SkillUIのplayerがnull");
            }
        }
        //スキルのUI変更
        void ChangeSkillUI()
        {
            switch (playerSkill.skillCount)
            {
                case 0:
                    redColor.a = 0;
                    yellowColor.a = 0;
                    blueColor.a = 0;
                    break;

                case 1:
                    redColor.a = 1;
                    yellowColor.a = 0;
                    blueColor.a = 0;
                    break;

                case 2:
                    redColor.a = 1;
                    yellowColor.a = 1;
                    blueColor.a = 0;
                    break;

                case 3:
                    redColor.a = 1;
                    yellowColor.a = 1;
                    blueColor.a = 1;
                    break;
                default:
                    Debug.LogError(playerSkill.skillCount + "が変");
                    break;

            }
            imageRed.color = redColor;
            imageYellow.color = yellowColor;
            imageBlue.color = blueColor;
        }
    }
}
