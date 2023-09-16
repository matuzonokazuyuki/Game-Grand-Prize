using System.Collections;
using System.Collections.Generic;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace Yuen.UI.StageSelectUI
{
    public class RGBColor : MonoBehaviour
    {
        [SerializeField] GameObject img;
        [SerializeField] float H = 360;
        [SerializeField] float S = 100;
        [SerializeField] float V = 100;
        [SerializeField] float changeSpeed;

        Image image;

        private void Start()
        {
            image = img.GetComponent<Image>();
        }
        // Update is called once per frame
        void Update()
        {
            if (H <= 360)
            {
                H += changeSpeed;
            }
            else if(H > 360)
            {
                H = 0;
            }

            image.color = Color.HSVToRGB(H / 360, S / 100, V / 100);
        }
    }
}
