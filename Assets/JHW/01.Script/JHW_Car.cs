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
        if (other.transform.CompareTag("obstacle") || other.transform.CompareTag("ground"))
        {
            print("�ڵ����� �浹�߽��ϴ�");
            crashCount++;
        }
    }
}
