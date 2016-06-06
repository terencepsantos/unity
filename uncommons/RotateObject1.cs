using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour
{
    public Transform YourObject;
    public float MovingRate = 1;
    private Vector3 lastMousePosition;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Input.GetMouseButtonDown(0))
            {
                //reset
                lastMousePosition = Input.mousePosition;
            }
            else if (Input.mousePosition.y != lastMousePosition.y || Input.mousePosition.x != lastMousePosition.x)
            {
                YourObject.Rotate(Vector3.right * (Input.mousePosition.y - lastMousePosition.y) * MovingRate);
                YourObject.Rotate(Vector3.back * (Input.mousePosition.x - lastMousePosition.x) * MovingRate);
            }

            lastMousePosition = Input.mousePosition;
        }
    }
}