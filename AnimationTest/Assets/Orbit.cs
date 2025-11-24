using UnityEngine;

public class Orbit : MonoBehaviour 
{
    public float rotationSpeed;
    public GameObject pivotObject;
    void Start()
    {

    }
    void Update()
    {
        transform.RotateAround(pivotObject.transform.position, new Vector3(0, 1, 0), rotationSpeed * Time.deltaTime);
    }
}
