using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void IniciarJogo()
    {
        SceneManager.LoadScene(2);
    }
    
    public void EncerrarJogo()
    {
        Application.Quit();
    }
}
