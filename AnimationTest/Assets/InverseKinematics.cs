using UnityEngine;

public class InverseKinematics : MonoBehaviour
{
    Animator animator;
    public bool ikActive = false;
    public Transform rightHand = null;
    public Transform lookAt = null;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnAnimatorIK()
    {
        if (animator)
        {
            if (ikActive)
            {
                if (lookAt != null)
                {
                    // Set the looking weight to the maximum value of 1 and change the position the character is looking to the position of the object
                    animator.SetLookAtWeight(1);
                    animator.SetLookAtPosition(lookAt.position);
                }
                
                if (rightHand != null)
                {
                    // Set the weights to their maximum value of 1
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                    // Set the IK Goals for the character so it knows where to look for the object
                    animator.SetIKPosition(AvatarIKGoal.RightHand, rightHand.position);
                    animator.SetIKRotation(AvatarIKGoal.RightHand, rightHand.rotation);
                }
            }
            else
            {
                // Set all weights to 0 so the character's animation does not change
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                animator.SetLookAtWeight(0);
            }
        }
    }
}
