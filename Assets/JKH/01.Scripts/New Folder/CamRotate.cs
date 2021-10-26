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
        //���콺�� �����ӿ� ���� ������ ����
        rotX += my * rotSpeed * Time.deltaTime;
        rotY += mx * rotSpeed * Time.deltaTime;
        //Rot������ -60 ~ 60 ���� ����
        rotX = Mathf.Clamp(rotX, -60, 60);
        //������ �������� ī�޶� �����Ų��
        transform.localEulerAngles = new Vector3(-rotX, rotY, 0);

    }
}
