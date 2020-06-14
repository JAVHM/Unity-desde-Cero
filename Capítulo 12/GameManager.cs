using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Las modenas condicionan el pasar al siguiente nivel
    public static float coinsLeft = 0;
    //Gaurdamos el número de muertes
    public static int deaths = 0;
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        //Reiniciamos el contador de las monedas restantes ya que es estático
        GameManager.coinsLeft = 0;
        deaths++;
    }

    public void NextLevel()
    {
        //Si hay cero monedas restantes en el nivel se puede pasar de nivel
        if(coinsLeft == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

