using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerJoim : MonoBehaviour
{
    public  string Isitfull;

    public void joinplyr(string playerName)
    {
        if (Isitfull == null &&playerName!=null)
        {
            Isitfull = playerName;
        }
        else
        {
            Isitfull = "boþ";
        }
        gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Isitfull;
    }

    private void OnEnable()
    {
        joinplyr(null);
    }
}
