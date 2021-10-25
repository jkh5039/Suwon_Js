using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JHW_Car : MonoBehaviour
{
    public int crashCount;

    //public static JHW_Car instance;

    // Start is called before the first frame update
    void Start()
    {
        crashCount=0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("obstacle"))
        {
            print("자동차가 충돌했습니다");
            crashCount++;
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.transform.CompareTag("obstacle"))
    //    {
    //        print("자동차가 충돌했습니다");
    //        crashCount++;
    //    }
    //}
}
