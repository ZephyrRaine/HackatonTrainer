using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour
{

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;

    public float minimumX = -360F;
    public float maximumX = 360F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    float rotationY = 0F;

    float GetMaxVertical()
    {
        var m = Input.GetAxis("Mouse Y");
        var g = Input.GetAxis("Vertical");
        return Mathf.Abs(m) > Mathf.Abs(g) ? m : g;
    }

    float GetMaxHorizontal()
    {
        var m = Input.GetAxis("Mouse X");
        var g = Input.GetAxis("Horizontal");
        return Mathf.Abs(m) > Mathf.Abs(g) ? m : g;

    }

    void Update()
    {
        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.localEulerAngles.y + GetMaxHorizontal() * sensitivityX;

            rotationY += GetMaxVertical() * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, GetMaxHorizontal() * sensitivityX, 0);
        }
        else
        {
            rotationY += GetMaxVertical() * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }
    }
}