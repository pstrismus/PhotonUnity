using ExitGames.Client.Photon;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using System.Collections.Generic;

public class Lobi : MonoBehaviourPunCallbacks
{
    public static string Oda_ismi;
    [SerializeField] GameObject Lobi_sec, LobiOda, BeklemeEkraný, Basla;
    [SerializeField] TMP_InputField textInput;
    [SerializeField] static GameObject Player1, Player2, Player3, Player4;
    [SerializeField] GameObject[] playerArray = { Player1, Player2, Player3, Player4 };

    [SerializeField] List<string> existingRooms = new List<string>();

    public void Online_Ol()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.GameVersion = "1.0.0";
    }

    public void Lobi_olustur()
    {
        if (PhotonNetwork.IsConnected)
        {
            Oda_ismi = Random.Range(1216545, 9999999).ToString();
            PhotonNetwork.CreateRoom(Oda_ismi, new RoomOptions() { MaxPlayers = 4 }, null);
        }
    }

    public void Lobi_Katýl()
    {
        if (PhotonNetwork.IsConnected)
        {
            string roomName = textInput.text;
            if (!string.IsNullOrEmpty(roomName))
            {
                PhotonNetwork.JoinRoom(roomName); // Odada katýlmayý dene
            }
            else
            {
                Debug.LogError("Oda ismi boþ olamaz.");
            }
        }
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Odaya katýlma baþarýsýz: " + message);
    }

    public static void disconnectOnline()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Disconnect();
        }
    }

    public static void disconnectRoom()
    {
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.LeaveRoom();
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log(" Baðlandý[Pun2]");
        UI_manager.instance.PanelSayi = 1;
        PlayerConnectRoom("1");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log(Oda_ismi + " Baðlandý[Pun2]");
        UI_manager.instance.PanelSayi = 4;
        Oda_Kodu.UpdateRoomName();
        RoomSetings();
    }

    public override void OnCreatedRoom()
    {
        Debug.Log(Oda_ismi + " oluþtu");
        Hashtable properties = new Hashtable { { "Oda_ismi", Oda_ismi } };
        PhotonNetwork.CurrentRoom.SetCustomProperties(properties);
        Oda_Kodu.UpdateRoomName();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log($"Yeni oyuncu katýldý: {newPlayer.NickName} (ID: {newPlayer.ActorNumber})");
        PlayerConnectRoom(newPlayer.ActorNumber.ToString());
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
        Debug.Log($"Oyuncu Çýktý: {otherPlayer.NickName} (ID: {otherPlayer.ActorNumber})");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        UI_manager.instance.PanelSayi = 0;
        base.OnDisconnected(cause);
    }

    public override void OnLeftRoom()
    {
        UI_manager.instance.PanelSayi = 1;
        base.OnLeftRoom();
    }

    public void RoomSetings()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Basla.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Baþla";
        }
        else
        {
            Basla.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Hazýr Ol";
        }
    }

    public void PlayerConnectRoom(string plyrname)
    {
        foreach (GameObject player in playerArray)
        {
            player.GetComponent<PlayerJoim>().Isitfull = plyrname;
        }
    }
}
