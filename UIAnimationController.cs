using UnityEngine;

namespace Animals.AnimatorController.UI
{
    public class UIAnimationController : BaseAnimatorController
    {
        public Animator animator;

        public void SetProperty(bool preferencesOpen)
        {
            SetAnimatorProperty(() => animator.SetBool("PreferencesOpened", preferencesOpen));
            Debug.Log(preferencesOpen);
        }
    }
}