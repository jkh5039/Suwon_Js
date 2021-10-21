using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class KH_Test : MonoBehaviour
{
    string s = "zacd";
    // Start is called before the first frame update
    void Start()
    {
        string answer = s;
        char[] ch = s.ToCharArray();
        
        var sort = ch.OrderByDescending(c => c).ToArray();
        sort.ToString();
        for(int i=0; i < s.Length; i++)
        {
            print(sort[i]);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
