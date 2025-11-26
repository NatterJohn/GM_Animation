using Unity.Mathematics;
using UnityEngine;

public class HeadTurn : MonoBehaviour
{
    public Transform HeadObject, TargetObject;//The Head of the Character and the Ball
    public float LookSpeed;
    bool isLooking;
    Quaternion LastRotation; //Quaternion is a variable storing information about rotation
    float HeadResetTimer;
    public float MaxAngle, MinAngle;
    void Start()
    {
        
    }
    //LateUpdate is used as it is called after the animator (unlike Update which is called before)
    void LateUpdate()
    {
        //Calculating the angle between the forward Vector of the character's head and the Ball
        Vector3 Direction = (TargetObject.position - HeadObject.position).normalized;
        float angle = Vector3.SignedAngle(Direction, HeadObject.forward, HeadObject.up); //Signed Angle includes information about the direction of rotation
        //If the angle is within range, the character will look at the ball
        if (angle < MaxAngle && angle > MinAngle)
        {
            if (!isLooking)
            {
                isLooking = true;
                LastRotation = HeadObject.rotation;
            }
            //LookRotation creates a rotation that will make the character look at the ball
            Quaternion TargetRotation = Quaternion.LookRotation(TargetObject.position - HeadObject.position);
            //Slerp interpolates the quaternions to create a smooth animation of the character looking at the ball
            LastRotation = Quaternion.Slerp(LastRotation, TargetRotation, LookSpeed * Time.deltaTime);
            HeadObject.rotation = LastRotation;
            HeadResetTimer = 0.5f;
        }
        else if (isLooking)
        {
            LastRotation = Quaternion.Slerp(LastRotation, HeadObject.rotation, LookSpeed * Time.deltaTime);
            HeadObject.rotation = LastRotation;
            //HeadResetTimer is used to prevent the character's head from snapping back to normal once the ball is outside the range
            HeadResetTimer -= Time.deltaTime;
            if (HeadResetTimer <= 0)
            {
                HeadObject.rotation = HeadObject.rotation;
                isLooking = false;
            }
        }
       
    }
}
