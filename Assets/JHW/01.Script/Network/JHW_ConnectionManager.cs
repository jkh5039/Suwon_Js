using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class JHW_ConnectionManager : MonoBehaviourPunCallbacks
{
    public InputField inputNickName;

    void Start()
    {

    }

    void Update()
    {

    }

    public void OnConnect()
    {
        //게임 버전 설정
        PhotonNetwork.GameVersion = "1.0.0";
        //접속 시도(name -> master)
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnected()
    {
        base.OnConnected();
        print(System.Reflection.MethodBase.GetCurrentMethod());
    }
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        print(System.Reflection.MethodBase.GetCurrentMethod());

        //만약에 InputFiled에 값이 있다면
        if (inputNickName.text.Length > 0)
        {
            //닉네임 설정
            PhotonNetwork.NickName = inputNickName.text;
            //로비 진입
            PhotonNetwork.JoinLobby();
            //PhotonNetwork.JoinLobby(new TypedLobby("로비 이름", LobbyType.Default));
        }
        else
        {
            print("닉네임을 입력해주세요");
        }

    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        print("로비 접속 성공");
        //로비씬으로 이동
        PhotonNetwork.LoadLevel("JHW_LobbyScene");
    }
}
