using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class KH_Test : MonoBehaviour
{
    string s = "zacd";

    float rotX;
    float rotY;
    // Start is called before the first frame update
    void Start()
    {
        //string answer = s;
        //char[] ch = s.ToCharArray();

        //var sort = ch.OrderByDescending(c => c).ToArray();
        //sort.ToString();
        //for(int i=0; i < s.Length; i++)
        //{
        //    print(sort[i]);

        //}
        rotX = transform.localEulerAngles.x;
        rotY = transform.localEulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Test()
    {
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        rotX += my * 200 * Time.deltaTime;
        rotY += mx * 200 * Time.deltaTime;
        rotX = Mathf.Clamp(rotX, -60, 60);
        transform.localEulerAngles = new Vector3(rotX, rotY, 0);
    }
}
