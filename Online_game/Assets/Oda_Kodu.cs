using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class Oda_Kodu : MonoBehaviourPunCallbacks
{
    static TextMeshProUGUI Kod;

    private void Awake()
    {
        Kod = GetComponent<TextMeshProUGUI>();
    }


    public static void UpdateRoomName()
    {
        if (PhotonNetwork.CurrentRoom.CustomProperties.TryGetValue("Oda_ismi", out object value))
        {
            Kod.text = value as string;
        }
    }

    public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
    {
        base.OnRoomPropertiesUpdate(propertiesThatChanged);

        if (propertiesThatChanged.ContainsKey("Oda_ismi"))
        {
            UpdateRoomName();
        }
    }
}
