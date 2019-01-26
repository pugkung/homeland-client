using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerConnector : MonoBehaviourPunCallbacks
{
    public GameObject clientConsole;
    public string defaultName;

    private string gameVersion = "1";
    private string roomName = "NewRoom";

    private Text consoleOutput;
    private string outTxt;

    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start()
    {
        consoleOutput = clientConsole.GetComponent<Text>();
        Connect();
    }

    // Attmpt to join room created by server module
    public void Connect()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRoom(roomName);
        }
        else
        {
            PhotonNetwork.GameVersion = gameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Successfully connected to PUN");
        PhotonNetwork.NickName = defaultName;
        PhotonNetwork.JoinRoom(roomName);
    }


    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("OnDisconnected() was called by PUN with reason {0}", cause);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
    }
}
