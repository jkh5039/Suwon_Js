using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JHW_ParkingCheck : MonoBehaviour
{
    public Image c_FL;
    public Image c_FR;
    public Image c_BL;
    public Image c_BR;

    public GameObject m_FL;
    public GameObject m_FR;
    public GameObject m_BL;
    public GameObject m_BR;

    public bool AllChecked;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(c_FL.color == Color.green&& c_FR.color == Color.green&& c_BL.color == Color.green&& c_BR.color == Color.green)
        {
            AllChecked = true;
        }
        print(AllChecked);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == m_FL) c_FL.color = Color.green;
        if (other.gameObject == m_FR) c_FR.color = Color.green;
        if (other.gameObject == m_BL) c_BL.color = Color.green;
        if (other.gameObject == m_BR) c_BR.color = Color.green;

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == m_FL) c_FL.color = Color.white; AllChecked = false;
        if (other.gameObject == m_FR) c_FR.color = Color.white; AllChecked = false;
        if (other.gameObject == m_BL) c_BL.color = Color.white; AllChecked = false;
        if (other.gameObject == m_BR) c_BR.color = Color.white; AllChecked = false;
    }
}
