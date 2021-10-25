using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JHW_ParkingCheck : MonoBehaviour
{
    public Image c_FL;

    // Start is called before the first frame update
    void Start()
    {
        c_FL = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("parkingzone"))
        {
            c_FL.color = Color.green;
        }
    }
}
