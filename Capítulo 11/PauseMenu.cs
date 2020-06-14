using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject menuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    //Cierra el Menu de pausa y el tiempo coontinua * 1
    public void Resume()
    {
        menuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    //Se abre el Menú de pausa y el tiempo se multiplica * 0, por lo que se para
    public void Pause()
    {
        menuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    //Cuando vuelves al menú te aseguras que las monedas restantes sean igual a 0
    public void goMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        GameManager.coinsLeft = 0;
    }
}
