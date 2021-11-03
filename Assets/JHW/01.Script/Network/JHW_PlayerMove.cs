using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class JHW_PlayerMove : MonoBehaviourPun
{
    //속력
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //내가 생성한 Player가 아니라면
        if (photonView.IsMine == false) return;

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = transform.forward * v + transform.right * h;
        dir.Normalize();

        transform.position = transform.position + dir * speed * Time.deltaTime;
    }
}
