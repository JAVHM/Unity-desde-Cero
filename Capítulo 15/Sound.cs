using UnityEngine.Audio;
using UnityEngine;

//Con esto podemos crear una lista de sonidos
[System.Serializable]

//Acá ponemos todos los componentes que va a tener nuestro audio
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    //Tono
    [Range(0f, 3f)]
    public float pitch = 1;

    //Que se repita en bucle
    public bool loop;

    //Para objetos 3D en los cuales quieres que el sonido salga de un objeto
    //Mientras más cercas estes será más claro

    [HideInInspector]
    public AudioSource source;
}
