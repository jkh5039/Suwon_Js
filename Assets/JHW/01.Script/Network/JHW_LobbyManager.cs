using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class JHW_LobbyManager : MonoBehaviourPunCallbacks
{
    //방제목
    public InputField roomName;
    //인원수
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
        //인원 수 제한
        roomOptions.MaxPlayers = byte.Parse(maxPlayer.text);
        //방의 이름으로 방을 만든다
        PhotonNetwork.CreateRoom(roomName.text, roomOptions, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        print("방 생성 완료");
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        print("방 생성 실패 : " + returnCode + ", " + message);
    }
    public void OnJoin()
    {
        //방입장
        PhotonNetwork.JoinRoom(roomName.text);
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        print("방 입장 완료");
        //Play씬으로 이동
        PhotonNetwork.LoadLevel("JHW_PlayScene");
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        print("방 입장 실패 : " + returnCode + ", " + message);
    }
}
