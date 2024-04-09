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
            _MgrInstance = FindObjectOfType<textGameManager>();
            //if there is no actual instance in scene yet (private mgr == null even after Find()), then spawn a gameobject & add script
            if (_MgrInstance == null) 
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
    private string playerName;   


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetName(string input)
    {
        playerName = input;
    }

    public void SetName(TMP_InputField myInput)
    {
        playerName = myInput.text;
    }

    public string GetName()
    {
        return playerName;
    }
}
