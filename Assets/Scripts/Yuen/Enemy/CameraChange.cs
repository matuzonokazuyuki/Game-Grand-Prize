using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Yuen.Enemy
{
    public class CameraChange : MonoBehaviour
    {
        private bool isTurn = false;

        public bool Turned
        {
            get { return isTurn; } 
            set { isTurn = value; }
        }
    }
}
