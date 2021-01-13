using System;
using UnityEngine;

namespace Animals.AnimatorController
{
    public class BaseAnimatorController : MonoBehaviour
    {
        public void SetAnimatorProperty(Action AnimatorPropertyHandler)
        {
            AnimatorPropertyHandler?.Invoke();
        }
    }
}