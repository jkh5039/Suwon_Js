using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JHW_WheelCollider : MonoBehaviour
{
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel         //모델 별로 차별화 하기
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
    //엑셀버튼을 누르면 1을 전달하게 떼면 0을 전달하도록
    //브레이크 버튼을 누르면 0까지 음수화

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


