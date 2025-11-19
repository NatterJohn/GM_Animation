using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    Animator yappy;
    Animator step;
    void Start()
    {
        yappy = gameObject.GetComponent<Animator>();
        step = gameObject.GetComponent<Animator>();
        step.SetBool("Walk", false);
        yappy.SetBool("Talk", false);
    }
    void Update()
    {
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
