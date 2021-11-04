using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KH_Carcolors : MonoBehaviour
{
    //차 종류들
    public GameObject carColor;
    public GameObject[] carColors;
    MeshRenderer mr;

    public Material[] carMaterials;
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mr.materials[0] = carMaterials[0];
    }

    
    void Update()
    {
    }
}
