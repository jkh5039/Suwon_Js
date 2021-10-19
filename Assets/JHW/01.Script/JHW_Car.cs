using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JHW_Car : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("obstacle") && collision.transform.CompareTag("ground"))
        {
            print("자동차가 충돌했습니다");
        }
    }
}
