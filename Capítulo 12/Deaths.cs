using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Agregar
using UnityEngine.UI;

public class Deaths : MonoBehaviour
{
    public Text textBoxPM;
    public Text textBoxLive;
    public int deaths;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debido a que existen dos frames en los cuales coliciona y por lo visto se reinicia el nivel 2 veces cuando eres golpeado...
        //..GameManager.deaths suma 2, por lo que para solucionarlo facilmente divido entre dos la sumatoria.
        deaths = GameManager.deaths / 2;
        textBoxPM.text = deaths.ToString();
        textBoxLive.text = deaths.ToString();
    }
}
