using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JHW_ParkingZone : MonoBehaviour
{
    public float successDistance;
    public float car_parkingDistance;
    GameObject ParkingPoint;
    GameObject ParkingZonePoint;
    public Text clearText;
    public Text crashText;
    public Text indicator;

    bool issuccess = false;

    public JHW_Car carCollider;
    JHW_ParkingCheck pc;

    // Start is called before the first frame update
    void Start()
    {
        ParkingPoint = GameObject.Find("ParkingPoint");
        ParkingZonePoint = GameObject.Find("ParkingZonePoint");
       
        //car = GameObject.Find("VehicleCollider").GetComponent<JHW_Car>();
        pc = GameObject.Find("ParkingZone").GetComponent<JHW_ParkingCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        car_parkingDistance = Vector3.Distance(ParkingPoint.transform.position, ParkingZonePoint.transform.position);
        indicator.text = "��ǥ ��������\n�Ÿ� : " + (car_parkingDistance*10f).ToString("F2") + "M";

        if (successDistance >= car_parkingDistance && pc.AllChecked==true)
        {
            if (issuccess == false)
            {
                print("�������� ����");
                Time.timeScale = 0;
                clearText.gameObject.SetActive(true);
                crashText.text = "�ε��� Ƚ�� : " + carCollider.crashCount;
                crashText.gameObject.SetActive(true);
                JHW_SoundManager.instance.PlaySuccess();
            }

            issuccess = true;
        }
       // print(Vector3.Distance(ParkingPoint.transform.position, ParkingZonePoint.transform.position));
    }
}
