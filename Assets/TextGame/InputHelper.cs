using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputHelper : MonoBehaviour
{
    public TextMeshProUGUI bodyText;
    public TMP_InputField inputText;
    public string newBody;
    public string replaceTarget;

    public void replaceText()
    {
        string myInput = inputText.text;
        string newMsg = newBody.Replace(replaceTarget, myInput);
        bodyText.text = newMsg;
    }
}
