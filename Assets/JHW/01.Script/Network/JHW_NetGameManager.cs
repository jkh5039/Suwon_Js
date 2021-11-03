using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class JHW_NetGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //나의 플레이어를 생성
        Vector3 pos = new Vector3(Random.Range(-3.0f, 3.0f), 0, Random.Range(-3.0f, 3.0f));
        PhotonNetwork.Instantiate("Player",pos,Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
