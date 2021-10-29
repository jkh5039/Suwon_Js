using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JHW_WheelModeling : MonoBehaviour
{
    public WheelCollider[] wheels = new WheelCollider[4];

    GameObject[] wheelMesh = new GameObject[4];

    // Start is called before the first frame update
    void Start()
    {
        wheelMesh = GameObject.FindGameObjectsWithTag("WheelMesh");

        //for (int i = 0; i < wheelMesh.Length; i++)
        //{	// 휠콜라이더의 위치를 바퀴메쉬의 위치로 각각 이동시킨다.
        //    wheels[i].transform.position = wheelMesh[i].transform.position;
        //}
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MeshAnim();
    }

    void MeshAnim()
    {
        Vector3 wheelPosition ;
        Quaternion wheelRotation = Quaternion.identity;

        for (int i = 0; i < 4; i++)
        {
            wheels[i].GetWorldPose(out wheelPosition, out wheelRotation);
            //wheelMesh[i].transform.position = wheelPosition;
            wheelMesh[i].transform.rotation = wheelRotation;
        }

    }
}
