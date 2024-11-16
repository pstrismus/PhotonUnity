using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class KopyalaYapistir : MonoBehaviour
{
   [SerializeField] TMP_InputField PasteText;
    [SerializeField] TextMeshProUGUI CopyText;

    public void Kopyala()
    {
        if (CopyText !=null)
        {
            TextEditor Copy = new TextEditor();
            Copy.text = CopyText.text;
            Copy.SelectAll();
            Copy.Copy();
        }
    }


    public void Yapistir()
    {
        if (PasteText != null)
        {
            TextEditor Paste = new TextEditor();
            Paste.isMultiline = true;
            Paste.Paste();
            PasteText.text = Paste.text;
        }
    }
}
