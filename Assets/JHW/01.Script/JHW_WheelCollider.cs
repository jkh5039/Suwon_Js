using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JHW_WheelCollider : MonoBehaviour
{
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel         //�� ���� ����ȭ �ϱ�
    public float maxSteeringAngle; // maximum steer angle the wheel can have

    JHW_JoyStick joystick;

    public float wheelspeed;
    public float acceleration;

    public bool isaccel;
    public bool isbreak;

    private void Start()
    {
        joystick = GetComponent<JHW_JoyStick>();
        acceleration = 0;
    }
    public void FixedUpdate()
    {
        float motor = maxMotorTorque * acceleration;
        //float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        float steering = joystick.direction.x * wheelspeed;

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
        }

        if(isaccel==false)
        {
            acceleration = 0;
        }
        
    }
    //������ư�� ������ 1�� �����ϰ� ���� 0�� �����ϵ���
    //�극��ũ ��ư�� ������ 0���� ����ȭ

    void AccelBtn()
    {
        isaccel = true;
        acceleration += 0.1f;
    }
    void breakBtn()
    {
        isbreak = true;
        acceleration -= 0.1f;
    }

}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}


