using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class JHW_ObjRotate : MonoBehaviourPun
{
    Vector3 rot;

    public bool canH;
    public bool canV;

    //회전 속력
    public float rotSpeed = 200;

    //PhontonView
    public 

    // Start is called before the first frame update
    void Start()
    {
        rot = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        //마우스의 움직임을 받자
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        if(canV) rot.x += -my * rotSpeed * Time.deltaTime;
        if(canH) rot.y += mx * rotSpeed * Time.deltaTime;

        rot.x = Mathf.Clamp(rot.x, -60, 60);

        transform.localEulerAngles = rot;
    }
}
