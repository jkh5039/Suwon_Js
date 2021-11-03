using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class JHW_LobbyManager : MonoBehaviourPunCallbacks
{
    //������
    public InputField roomName;
    //�ο���
    public InputField maxPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCreate()
    {
        RoomOptions roomOptions = new RoomOptions();
        //�ο� �� ����
        roomOptions.MaxPlayers = byte.Parse(maxPlayer.text);
        //���� �̸����� ���� �����
        PhotonNetwork.CreateRoom(roomName.text, roomOptions, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        print("�� ���� �Ϸ�");
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        print("�� ���� ���� : " + returnCode + ", " + message);
    }
    public void OnJoin()
    {
        //������
        PhotonNetwork.JoinRoom(roomName.text);
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        print("�� ���� �Ϸ�");
        //Play������ �̵�
        PhotonNetwork.LoadLevel("JHW_PlayScene");
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        print("�� ���� ���� : " + returnCode + ", " + message);
    }
}
