using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoverUIManager : MonoBehaviour
{
    public Button botonContinuar;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            botonContinuar.interactable = true;
        }
    }
    public void LoadScene1()
    {
        PlayerPrefs.DeleteKey("Score");//PlayerPrefs.DeleteAll();//Borra todo.
        SceneManager.LoadScene("Scene1");
    }
    public void LoadStoredGame()
    {
        string sceneName = PlayerPrefs.GetString("SceneName");
        GameManager.continueGame = true;
        SceneManager.LoadScene(sceneName);
    }
    public void ConfigGame()
    {
        Debug.LogError("FALTA POR IMPLEMENTAR EL METODO CONFIGGAME");
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
