using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class bekleme : MonoBehaviour
{
    TMPro.TextMeshProUGUI text;

    private void OnEnable()
    {
        text = GetComponent<TextMeshProUGUI>();
        StartCoroutine(zamanlama());
    }
    IEnumerator zamanlama()
    {
        
        bool WhileActive=false;
        while (isActiveAndEnabled && !WhileActive)
        {
            WhileActive = true;
            text.text = "";

            for (int j = 0; j < 3; j++)
            {                  
                text.text += ".";
                yield return new WaitForSeconds(0.2f);
            }
            WhileActive = false;
        }
    }
}
