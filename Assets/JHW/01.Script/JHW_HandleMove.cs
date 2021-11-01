using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JHW_HandleMove : MonoBehaviour
{
    JHW_JoyStick joystick;
    // Start is called before the first frame update
    void Start()
    {
        joystick = GameObject.Find("1P").GetComponent<JHW_JoyStick>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(0f, 0f, -joystick.direction.x *100f);
    }
}
