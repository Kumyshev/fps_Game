using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerCamera : MonoBehaviour
{
    public enum RotationAxis
    {
        mouseX = 1,
        mouseY = 2
    }

    public RotationAxis axes = RotationAxis.mouseX;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    public float sensHorizontal = 0.1f;
    public float sensVertical = 0.1f;

    public float rotationX = 0;

    [HideInInspector]
    public float mouseXinput;
    [HideInInspector]
    public float mouseYinput;

    void Update()
    {
        if (axes == RotationAxis.mouseX)
        {
            transform.Rotate(0, mouseXinput * sensHorizontal, 0);
        }
        else if (axes == RotationAxis.mouseY)
        {
            rotationX -= mouseYinput * sensVertical;
            rotationX = Mathf.Clamp(rotationX, minimumVert, maximumVert);
            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }

    }
}
