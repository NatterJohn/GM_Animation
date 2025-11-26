using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    Animator yappy;
    Animator step;
    void Start()
    {
        //Gets the animator applied to the object this script is attached to
        yappy = gameObject.GetComponent<Animator>();
        step = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        //If the specified Key is pressed, the weight of the specified layer is set to 1. The Walking layer is Layer 1 and the Talking layer is Layer 2. (The Idle layer is 0)
        if (Input.GetKey(KeyCode.Space))
            step.SetLayerWeight(1, 1f);
        else
            step.SetLayerWeight(1, 0f);
        if (Input.GetKey(KeyCode.LeftControl))
            yappy.SetLayerWeight(2, 1f);
        else
            yappy.SetLayerWeight(2, 0f);
    }
}
