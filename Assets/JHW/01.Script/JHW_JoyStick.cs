using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JHW_JoyStick : MonoBehaviour
{
  //  public float speed;
    public FixedJoystick fixedJoystick;
    //public Rigidbody rb;

    public Vector3 direction;

    public void FixedUpdate()
    {
        /*direction =  Vector3.forward * fixedJoystick.Vertical + */

        if(SceneManager.GetActiveScene().name == "KH_ARDetect")
        {
            direction = Vector3.right * fixedJoystick.Horizontal;  //조이스틱
        }
        if(transform.root.name == "RaceGame")
        {
            direction = new Vector3( Input.acceleration.x,0,0); //휴대폰 기울이기
        }


        //rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }
}
