using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JHW_Car : MonoBehaviour
{
    public int crashCount;

    public GameObject startFinishLine;
    public GameObject checkPoint_1;
    public GameObject checkPoint_2;
    public GameObject checkPoint_3;

    public bool isStartFinish;
    public bool isCP1;
    public bool isCP2;
    public bool isCP3;
    public int laps;

    public Text laps_text;

    // Start is called before the first frame update
    void Start()
    {
        crashCount=0;
        laps = 1;
    }

    // Update is called once per frame
    void Update()
    {
        laps_text.text = "Laps " + laps + " / 3";
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.CompareTag("obstacle"))
        {
            print("�ڵ����� �浹�߽��ϴ� : " + crashCount);
            crashCount++;
        }

        if (other.transform==startFinishLine.transform)
        {
            if(isCP1==true && isCP2==true && isCP3==true)
            {
                laps++;

                isCP1 = false;
                isCP2 = false;
                isCP3 = false;
            }
            print("�ǴϽö��� ��� Lap : " + laps) ;
            
        }
        if(other.transform==checkPoint_1.transform)
        {
            print("üũ����Ʈ 1 ���");
            isCP1 = true;
        }
        if (other.transform == checkPoint_2.transform)
        {
            print("üũ����Ʈ 2 ���");
            isCP2 = true;
        }
        if (other.transform == checkPoint_3.transform)
        {
            print("üũ����Ʈ 3 ���");
            isCP3 = true;
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.transform.CompareTag("obstacle"))
    //    {
    //        print("�ڵ����� �浹�߽��ϴ�");
    //        crashCount++;
    //    }
    //}
}
