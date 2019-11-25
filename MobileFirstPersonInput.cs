using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MobileFirstPersonInput : MonoBehaviour
{



    public FixedJoystick joystick;
    public FixedButton button;
    public FixedTouchField touchfield;
    public CharacterControllerMove control;
    public CharacterControllerCamera controlCameraPlayer;
    public CharacterControllerCamera controlCamera;

    //public Camera cam;
    //protected float cameraAngle;
    //protected float cameraAngelSpeed=0.2f;

    public static bool gameFinish = false;
    public GameObject finishPlane;


    void OnTriggerEnter(Collider col)
    {
        //Debug.Log(col.collider.name);
        if (col.gameObject == finishPlane)
        {
            Timer.timerformenu = true;
            gameFinish = true;
        }
        
    }
    void Start()
    {
        
    }

    void Update()
    {
        control.m_Jump = button.Pressed;
        control.Hinput = joystick.inputVector.x;
        control.Vinput = joystick.inputVector.y;
        controlCameraPlayer.mouseXinput = touchfield.TouchDist.x;
        controlCamera.mouseYinput = touchfield.TouchDist.y;


        //cameraAngle += touchfield.TouchDist.x * cameraAngelSpeed;
        //cam.transform.position = transform.position + Quaternion.AngleAxis(cameraAngle, Vector3.up) * new Vector3(0, 3, 4);
        //cam.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 2f - cam.transform.position, Vector3.up);
        
    }
}
