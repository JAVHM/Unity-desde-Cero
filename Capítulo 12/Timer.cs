using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Agregar
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //timeStart será estática para que al cambiar de escena no se reinicie
    public static float timeStart = 0;
    public Text textBoxPM;
    public Text textBoxLive;
    // Start is called before the first frame update
    void Start()
    {
        //se pone el "toString" para añadir los dos decimales
        //F2 ya existe dentro de Unity y se refiere a la medición del tiempo en dos decimales
        textBoxPM.text = timeStart.ToString("F2");
        textBoxLive.text = timeStart.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        //Al tiempo de inicio se la va a ir sumando el tiempo que pase, segunda a segundo (+1,+1,+1,+1,......)
        timeStart += Time.deltaTime;
        textBoxPM.text = timeStart.ToString("F2");
        textBoxLive.text = timeStart.ToString("F2");
    }
}
