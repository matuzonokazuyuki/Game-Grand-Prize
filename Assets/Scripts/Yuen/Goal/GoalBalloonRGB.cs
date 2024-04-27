using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Yuen.Goal
{
    public class GoalBalloonRGB : MonoBehaviour
    {
        [SerializeField] private float changeSpeed;
        private float H = 360;
        private float S = 360;
        private float V = 360;

        Renderer balloonRenderer;

        // Start is called before the first frame update
        void Start()
        {
            balloonRenderer = gameObject.GetComponent<Renderer>();
        }

        // Update is called once per frame
        void Update()
        {
            //ゴールの風船をRGBで光らせる
            if (H <= 360)
            {
                H += changeSpeed;
            }
            else if(H > 360)
            {
                H = 0;
            }

            balloonRenderer.material.color = Color.HSVToRGB(H / 360, S / 100, V / 100);
        }
    }
}
