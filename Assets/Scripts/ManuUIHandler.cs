using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]


public class ManuUIHandler : MonoBehaviour
{

    public TMP_InputField PlayerNameField;

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
      


    public void HandleNameInput(string pname)
    {
        
        SaveDataManager.Instance.playerName = PlayerNameField.text;
       
    }

    
}
