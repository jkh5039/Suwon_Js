using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    //Rotation Value
    float rotX;
    float rotY;
    //Rotation Speed
    public float rotSpeed = 200;
    void Start()
    {
        rotX = transform.localEulerAngles.x;
        rotY = transform.localEulerAngles.y;
    }


    void Update()
    {
        //Mouse Movements;
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");
        //마우스의 움직임에 따라 각도를 누적
        rotX += my * rotSpeed * Time.deltaTime;
        rotY += mx * rotSpeed * Time.deltaTime;
        //Rot각도를 -60 ~ 60 으로 제한
        rotX = Mathf.Clamp(rotX, -60, 60);
        //누적된 각도값을 카메라에 적용시킨다
        transform.localEulerAngles = new Vector3(-rotX, rotY, 0);

    }
}
