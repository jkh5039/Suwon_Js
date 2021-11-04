using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        crashCount = 0;
        laps = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "JHW_MiniGame2")
        {
            laps_text.text = "Laps " + laps + " / 3";

        }
    }


    private void OnTriggerEnter(Collider other)
    {


        if (other.transform.CompareTag("obstacle") && SceneManager.GetActiveScene().name == "KH_ARDetect")
        {
            print("�ڵ����� �浹�߽��ϴ� : " + crashCount);
            crashCount++;
            JHW_SoundManager.instance.PlayCrash();
        }
        //----------------------------------------------------------
        if (SceneManager.GetActiveScene().name == "JHW_MiniGame2")
        {

            if (other.transform == startFinishLine.transform)
            {
                if (isCP1 == true && isCP2 == true && isCP3 == true)
                {
                    laps++;
                    JHW_SoundManager.instance.PlaySuccess();
                    isCP1 = false;
                    isCP2 = false;
                    isCP3 = false;
                }
                print("�ǴϽö��� ��� Lap : " + laps);
                
                //laps_text.text = "Laps " + laps + " / 3";
            }
            if (other.transform == checkPoint_1.transform)
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
    }

    public void OnClickCheatKey()
    {
        laps++;
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
