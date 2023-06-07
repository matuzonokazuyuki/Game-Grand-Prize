using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Yuen.UI
{
    public class BalloonUI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI textLeft;
        [SerializeField] TextMeshProUGUI textRight;

        string numStringLeft;
        string numStringRight;

        //balloonUIの表示方法
        public void UpdateBalloonLimit(int balloonLimit)
        {

            int limit01 = balloonLimit / 10;
            int limit02 = balloonLimit % 10;

            numStringLeft = "<sprite=" + limit01 + ">";
            numStringRight = "<sprite=" + limit02 + ">";

            textLeft.text = numStringLeft;
            textRight.text = numStringRight;
        }

    }
    
}
