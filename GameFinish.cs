using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinish : MonoBehaviour
{

    public static bool gameFinish = false;
    public GameObject finishPlane;
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject == finishPlane)
        {
            Debug.Log("finish");
            //gameFinish = true;
        }
    }
}