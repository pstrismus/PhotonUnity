using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Degis : MonoBehaviour
{
    [SerializeField] int Sayi;

    public void Degis()
    {
        UI_manager.instance.PanelSayi = Sayi;
    }
}
