using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonHelper : MonoBehaviour
{
    public textGameManager myMgr;
    public string myKey;

    public void Start()
    {
        myMgr = textGameManager.myInstance;
    }
    //little script to change to a new scene
    public void GoToScene(string sceneName)
    {
        Debug.Log("Pressed the button!");
        SceneManager.LoadScene(sceneName);
    }

    public void AddToInventory(string item)
    {
        myMgr.myInventory.Add(item);
    }

    public void EnableObject(GameObject target)
    {
        target.SetActive(true);
    }

    public void SetName(string name)
    {
        myMgr.name = name;
    }
    
    public void replaceText(string body, string target, string replacement)
    {

    }
}
