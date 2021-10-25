using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JHW_ParkingZone : MonoBehaviour
{
    public float successDistance;
    GameObject ParkingPoint;
    GameObject ParkingZonePoint;
    public Text clearText;
    public Text crashText;

    bool issuccess = false;

    JHW_Car car;
    JHW_ParkingCheck pc;

    // Start is called before the first frame update
    void Start()
    {
        ParkingPoint = GameObject.Find("ParkingPoint");
        ParkingZonePoint = GameObject.Find("ParkingZonePoint");
       
        car = GameObject.Find("Body").GetComponent<JHW_Car>();
        pc = GameObject.Find("ParkingZone").GetComponent<JHW_ParkingCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        if (successDistance >= Vector3.Distance(ParkingPoint.transform.position, ParkingZonePoint.transform.position) && pc.AllChecked==true)
        {
            if (issuccess == false)
            {
                print("½ºÅ×ÀÌÁö ¼º°ø");
                Time.timeScale = 0;
                clearText.gameObject.SetActive(true);
                crashText.text = "ºÎµúÈù È½¼ö : " + car.crashCount;
                crashText.gameObject.SetActive(true);
            }

            issuccess = true;
        }
    }
}
