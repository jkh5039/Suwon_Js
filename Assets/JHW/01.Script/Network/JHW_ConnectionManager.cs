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
        //���� ���� ����
        PhotonNetwork.GameVersion = "1.0.0";
        //���� �õ�(name -> master)
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

        //���࿡ InputFiled�� ���� �ִٸ�
        if (inputNickName.text.Length > 0)
        {
            //�г��� ����
            PhotonNetwork.NickName = inputNickName.text;
            //�κ� ����
            PhotonNetwork.JoinLobby();
            //PhotonNetwork.JoinLobby(new TypedLobby("�κ� �̸�", LobbyType.Default));
        }
        else
        {
            print("�г����� �Է����ּ���");
        }

    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        print("�κ� ���� ����");
        //�κ������ �̵�
        PhotonNetwork.LoadLevel("JHW_LobbyScene");
    }
}
