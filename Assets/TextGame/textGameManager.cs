using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class textGameManager : MonoBehaviour
{

    public TMP_InputField myInput;
    public string playerName;

    public GameObject inputField;
    public GameObject submitButton;
    public GameObject WelcomeObject;
    public GameObject sceneChanger;
    TextMeshProUGUI WelcomeText;

    public string welcomeMessage;
    public string replaceText;
    


    // Start is called before the first frame update
    void Start()
    {
        WelcomeText = WelcomeObject.GetComponent<TextMeshProUGUI>();
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetName()
    {
        playerName = myInput.text;
        submitButton.SetActive(false);
        inputField.SetActive(false);

        string newWelcome = welcomeMessage.Replace(replaceText, playerName);
        WelcomeText.text = newWelcome;

        sceneChanger.SetActive(true);
    }
}
