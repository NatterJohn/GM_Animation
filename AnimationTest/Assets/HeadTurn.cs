using Unity.Mathematics;
using UnityEngine;

public class HeadTurn : MonoBehaviour
{
    public Transform HeadObject, TargetObject, HeadForward;
    public float LookSpeed;
    bool isLooking;
    Quaternion LastRotation;
    float HeadResetTimer;
    public float MaxAngle, MinAngle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 Direction = (TargetObject.position - HeadObject.position).normalized;
        float angle = Vector3.SignedAngle(Direction, HeadForward.forward, HeadForward.up);
        if (angle < MaxAngle && angle > MinAngle)
        {
            if (!isLooking)
            {
                isLooking = true;
                LastRotation = HeadObject.rotation;
            }
            Quaternion TargetRotation = Quaternion.LookRotation(TargetObject.position - HeadObject.position);
            LastRotation = Quaternion.Slerp(LastRotation, TargetRotation, LookSpeed * Time.deltaTime);
            HeadObject.rotation = LastRotation;
            HeadResetTimer = 0.5f;
        }
        else if (isLooking)
        {
            LastRotation = Quaternion.Slerp(LastRotation, HeadForward.rotation, LookSpeed * Time.deltaTime);
            HeadObject.rotation = LastRotation;
            HeadResetTimer -= Time.deltaTime;
            if (HeadResetTimer <= 0)
            {
                HeadObject.rotation = HeadForward.rotation;
                isLooking = false;
            }
        }
       
    }
}
