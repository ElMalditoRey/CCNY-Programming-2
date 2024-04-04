using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class textGameManager : MonoBehaviour
{

    //-------------------------------------------------- code for instancing a singleton and loading before the scene -----------//

    private static textGameManager _MgrInstance; //declaring that an instance of this script exists

    public static textGameManager myInstance { //the constructor function, this described a way to get or spawn the game manager whenever it is called

        get //this get function will run once a textGameManager instance is declared in any of our code
        {

            if(_MgrInstance == null) //if there is no actual instance in scene yet (private mgr == null), then spawn a gameobject
            {
                GameObject myGO = new GameObject("GameManager");
                myGO.AddComponent<textGameManager>();
                DontDestroyOnLoad(myGO);
            }
            return _MgrInstance; //return a valid game manager
        }   
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)] //the following method runs before the scene loads
    public static void InitializeManager()
    {
        textGameManager newMgr = textGameManager.myInstance;
    }

    // ----------------------------------------- end -----------------------------//





    public List<string> myInventory;

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
