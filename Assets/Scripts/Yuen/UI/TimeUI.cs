using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Yuen.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TimeUI : MonoBehaviour
    {
        TextMeshProUGUI text;

        private void Awake()
        {
            text = GetComponent<TextMeshProUGUI>();
        }

        public void TextUpdate(int secondNum)
        {
            int minute = secondNum / 60;
            int second = secondNum % 60;

            int num1 = second % 10;
            int num2 = second / 10;

            int num3 = minute % 10;
            int num4 = minute / 10;

            string numString1 = "<sprite=" + num1 + ">";
            string numString2 = "<sprite=" + num2 + ">";
            string numString3 = "<sprite=" + num3 + ">";
            string numString4 = "<sprite=" + num4 + ">";

            text.text = numString4 + numString3 + "<sprite=10>" + numString2 + numString1;
        }
    }
}
