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
            step.SetBool("Walk", true);
        else
            step.SetBool("Walk", false);
        if (Input.GetKey(KeyCode.LeftControl))
            yappy.SetBool("Talk", true);
        else
            yappy.SetBool("Talk", false);


    }
}
