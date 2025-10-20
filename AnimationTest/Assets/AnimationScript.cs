using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    private Animator yappy;
    private Animator step;
    void Start()
    {
        yappy = GetComponent<Animator>();
        step = GetComponent<Animator>();
    }
    void Update()
    {
        yappy.SetBool("Talk", Input.GetKeyDown(KeyCode.Space));
        step.SetBool("Walk", Input.GetKey(KeyCode.LeftControl));
    }
}
