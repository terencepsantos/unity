using UnityEngine;
using System.Collections;

public class RotateObjectTest : MonoBehaviour
{
    private float baseAngle = 0.0f;


    void OnMouseDown()
    {
       Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
       pos = Input.mousePosition - pos;

       baseAngle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
       baseAngle -= Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg;
    }


    void OnMouseDrag()
    {
       Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
       pos = Input.mousePosition - pos;

       float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg - baseAngle;
       transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}