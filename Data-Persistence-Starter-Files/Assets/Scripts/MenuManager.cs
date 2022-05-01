using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public InputField CurrPlrInput;
    public Text BestPlayerText;
    private void Start()
    {
        BestPlayerText.text += SavesManager.Instance.BestPlayer.HighScorePlayer + " : " + SavesManager.Instance.BestPlayer.HighScore;
    }
    public void StartNew()
    {
        if (CurrPlrInput.text == "")
        {
            Debug.Log("Error! Enter the Name!");
            return;
        }
        SavesManager.Instance.CurrPlayer = CurrPlrInput.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        EditorApplication.ExitPlaymode();
    }
}
