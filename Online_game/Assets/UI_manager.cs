using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_manager : MonoBehaviour
{
    [SerializeField] GameObject Baslangic, Lobi_Sec, Bekleme, LobiKatil,Lobi_oda;
    public GameObject Ac�k_Panel;

    public static UI_manager instance = null;
    public int _PanelSayi;

    
    public int PanelSayi
    {
        get { return _PanelSayi;}

        set {
            _PanelSayi = value;
            UI_degis();
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void UI_degis()
    {
        switch (PanelSayi)
        {
            case 0:
                Ac�k_Panel = Baslangic;

                break;
            case 1:
                Ac�k_Panel = Lobi_Sec;
                break;
            case 2:
                Ac�k_Panel = Bekleme;
                break;
            case 3:
                Ac�k_Panel = LobiKatil;
                break;
            case 4:
                Ac�k_Panel = Lobi_oda;
                break;
            default:
                return; 
        }

        UpdateUI();
        Debug.Log(PanelSayi + " �al��t�");
    }


    private void UpdateUI()
    {
        Baslangic.SetActive(Ac�k_Panel == Baslangic);
        Lobi_Sec.SetActive(Ac�k_Panel == Lobi_Sec);
        Bekleme.SetActive(Ac�k_Panel == Bekleme);
        LobiKatil.SetActive(Ac�k_Panel == LobiKatil);
        Lobi_oda.SetActive(Ac�k_Panel == Lobi_oda);
    }


}

