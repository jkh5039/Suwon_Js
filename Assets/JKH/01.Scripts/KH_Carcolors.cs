using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KH_Carcolors : MonoBehaviour
{
    //차 종류들1
    //public GameObject carColor;
    //public GameObject[] carColors;
    MeshRenderer mr;

    public Material[] carMaterials;
    int num;
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        //mr.materials[1] = carMaterials[0];
        //MultiImage.instance.isGenesis = true;

    }


    void Update()
    {

        if (Input.GetKey(KeyCode.Alpha1))
        {
            mr.materials[1].color = Color.black;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            mr.materials[1].color = Color.white;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            mr.materials[1].color = Color.gray;
        }

        if (MultiImage.instance.isAudi)
        {
            mr.materials[1].color = Color.gray;
            // mr.materials[1] = carMaterials[1]; //silver
        }
        if (MultiImage.instance.isBenz)
        {
            mr.materials[1].color = Color.black;
            //mr.materials[1] = carMaterials[0]; //black
        }
        if (MultiImage.instance.isGenesis)
        {
            mr.materials[1].color = Color.white;
            //mr.materials[1] = carMaterials[2]; //white
        }

        


    }
}
