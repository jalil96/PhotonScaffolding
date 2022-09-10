using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NetManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI statusText;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        button.interactable = false;
        statusText.text = "Connecting to Master...";
    }

    public void Connect()
    {
        var roomOptions = new RoomOptions
        {
            MaxPlayers = 4,
            IsOpen = true,
            IsVisible = true
        };
        PhotonNetwork.JoinOrCreateRoom("MainRoom", roomOptions, TypedLobby.Default);
        button.interactable = false;
        statusText.text = "Creating/Joining room...";
    }

    public override void OnConnectedToMaster()
    {
        button.interactable = false;
        PhotonNetwork.JoinLobby();
        statusText.text = "Joining Lobby...";
    }

    public override void OnCreatedRoom()
    {
        statusText.text = "Room Created!";
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        statusText.text = "Room creating failed";
        button.interactable = true;
    }

    public override void OnJoinedRoom()
    {
        statusText.text = "Joined Room!";
        button.interactable = false;
        PhotonNetwork.LoadLevel("Gameplay");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        statusText.text = "Joining room failed";
        button.interactable = true;
    }

    public override void OnJoinedLobby()
    {
        button.interactable = true;
        statusText.text = "Joined Lobby successfully";
    }

    public override void OnLeftLobby()
    {
        base.OnLeftLobby();
        statusText.text = "Lobby failed connecting";
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        
    }
}
