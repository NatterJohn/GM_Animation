using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Talking : MonoBehaviour
{
    private Animator yappy;
    void Start()
    {
        yappy = GetComponent<Animator>();
    }
    void Update()
    {
        yappy.SetBool("Talk", Input.GetKeyDown(KeyCode.Space));
    }
        
}

