using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JHW_WheelCollider : MonoBehaviour
{
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel         //모델 별로 차별화 하기
    public float maxSteeringAngle; // maximum steer angle the wheel can have

    public JHW_JoyStick joystick;

    public float wheelspeed;
    public float acceleration;

    public bool isaccel=false;
    public bool isback=false;

    public Rigidbody car;

    private void Start()
    {
       //joystick = GameObject.Find("Player").GetComponent<JHW_JoyStick>();
        acceleration = 0;
        //car = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name== "KH_ARDetect")
        {
            maxMotorTorque = 10;
        }
        if(transform.root.name=="RaceGame")
        {
            maxMotorTorque = 40;
        }
        // 방향, 구동
        float motor = maxMotorTorque * acceleration;

        float steering = maxSteeringAngle* joystick.direction.x * wheelspeed; //모바일 버전 조이스틱
        //float steering = Input.acceleration.x; //모바일 버전 틸트

        //float steering = maxSteeringAngle * Input.GetAxis("Horizontal")*wheelspeed; // pc 버전

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
        
        //버튼 불함수
        if (isaccel == true)
        {
            acceleration += 0.1f;
            if (acceleration >= 1) acceleration = 1;
        }
        if(isback==true)
        {
            acceleration -= 0.1f;
            if (acceleration <= -1) acceleration = -1;
        }
        if(isaccel==false && isback==false)
        {
            acceleration = 0;
        }

    }
    
    public void AccelBtnDown()
    {
        isaccel = true;
    }
    public void AccelBtnUP()
    {
        isaccel = false;
    }
    public void BackBtnDown()
    {
        isback = true;
    }
    public void BackBtnUp()
    {
        isback = false;
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



