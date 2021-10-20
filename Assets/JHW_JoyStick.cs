using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JHW_JoyStick : MonoBehaviour
{
  //  public float speed;
    public FixedJoystick fixedJoystick;
    //public Rigidbody rb;

    public Vector3 direction;

    public void FixedUpdate()
    {
        direction = /* Vector3.forward * fixedJoystick.Vertical +*/ Vector3.right * fixedJoystick.Horizontal;


        //rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }
}
