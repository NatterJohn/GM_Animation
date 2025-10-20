using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Walking : MonoBehaviour
{
    private Animator step;
    void Start()
    {
        step = GetComponent<Animator>();
    }
    void Update()
    {
        step.SetBool("Walk", Input.GetKey(KeyCode.LeftControl));
    }

}
