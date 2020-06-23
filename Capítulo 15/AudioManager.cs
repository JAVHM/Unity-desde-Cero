using UnityEngine;
using System;
//Agregar
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    //Creamos nuestra lista de sonidos
    public Sound[] sounds;

    //Con instance vamos a asegurarnos de que solo haya un AudioManager
    public static AudioManager instance;
    // Start is called before the first frame update

    void Awake()
    {
        //Con instance vamos a asegurarnos de que solo haya un AudioManager
        if (instance == null)
            instance = this;
        //Con esto el objeto no se destruye al pasar de escena o el reinicio de la misma
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        //Sound, definimos que nos referimos a un sonido
        //"s" es el sonido
        //la lista de sonidos "s" es sounds
        //Para cada sonido en la lista de sonidos....
        foreach (Sound s in sounds)
        {
            //Estas son las cosas que son necesarias para cada sonido
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        Play("BackGroundMusic");
    }

    float newVol = 1;
    float newPitch = 1;
    void Update()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "BackGroundMusic");
        s.source.volume = newVol;
        s.source.pitch = newPitch;
    }

    public void Play(string name)
    {
        //En la lista de sonidos ("Sound") está "s", se le va agragar a sus componentes estás variables
        //1. Le decimos a que lista nos referimos
        //2. Ahora que en esa lista lo busque por su nombre
        Sound s = Array.Find(sounds, sound => sound.name == name);
        //Si no se encuentra el sonido retornar nulo
        if (s == null)
        {
            Debug.LogError("No se encontró el audio!");
            return;
        }
        s.source.Play();
    }

    //Creamos una clase dinamica en la cual el valor del temporal "temp" varía según el Slider
    public void SetBGVolume(float temp)
    {
        newVol = temp;
    }

    public void SetBGPitch(float temp)
    {
        newPitch = temp;
    }
}
