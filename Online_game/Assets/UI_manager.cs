using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_manager : MonoBehaviour
{
    [SerializeField] GameObject Baslangic, Lobi_Sec, Bekleme, LobiKatil,Lobi_oda;
    public GameObject Acýk_Panel;

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
                Acýk_Panel = Baslangic;

                break;
            case 1:
                Acýk_Panel = Lobi_Sec;
                break;
            case 2:
                Acýk_Panel = Bekleme;
                break;
            case 3:
                Acýk_Panel = LobiKatil;
                break;
            case 4:
                Acýk_Panel = Lobi_oda;
                break;
            default:
                return; 
        }

        UpdateUI();
        Debug.Log(PanelSayi + " çalýþtý");
    }


    private void UpdateUI()
    {
        Baslangic.SetActive(Acýk_Panel == Baslangic);
        Lobi_Sec.SetActive(Acýk_Panel == Lobi_Sec);
        Bekleme.SetActive(Acýk_Panel == Bekleme);
        LobiKatil.SetActive(Acýk_Panel == LobiKatil);
        Lobi_oda.SetActive(Acýk_Panel == Lobi_oda);
    }


}

