using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Yuen.UI
{
    public class BalloonUI : MonoBehaviour
    {
        [SerializeField] GameObject RightUI;
        [SerializeField] GameObject LeftUI;
        TextMeshProUGUI textRight;
        TextMeshProUGUI textLeft;

        void Awake()
        {
            textRight = RightUI.GetComponent<TextMeshProUGUI>();
            textLeft = LeftUI.GetComponent<TextMeshProUGUI>();
        }
        //balloonUIの表示方法
        public void UpdateBalloonLimit(int balloonLimit)
        {

            int limit01 = balloonLimit / 10;
            int limit02 = balloonLimit % 10;

            string numString1 = "<sprite=" + limit01 + ">";
            string numString2 = "<sprite=" + limit02 + ">";

            textLeft.text = numString1;
            textRight.text = numString2;
        }

    }
    
}
