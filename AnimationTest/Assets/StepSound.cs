using UnityEngine;

public class StepSound : MonoBehaviour
{
    AudioSource aud;
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    
    public void Footstep()
    {
        aud.Play();
    }
}
