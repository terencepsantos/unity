using UnityEngine;
using System.Collections;

public class RotateObjectTest : MonoBehaviour
{
    public int speed = 1;
    public float friction = 1;
    public float lerpSpeed = 1;
    private float xDeg;
    private float yDeg;
    private Quaternion fromRotation;
    private Quaternion toRotation;

    void Update()
    {
       if (Input.GetMouseButton(0))
       {
           xDeg -= Input.GetAxis("Mouse X") * speed * friction;
           yDeg += Input.GetAxis("Mouse Y") * speed * friction;
           fromRotation = transform.rotation;
           toRotation = Quaternion.Euler(yDeg, xDeg, 0);
           transform.rotation = Quaternion.Lerp(fromRotation, toRotation, Time.deltaTime * lerpSpeed);
       }
    }
}