using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
    void Awake()
    {
        //para chamar um som num  script fazer: FindObjectOfType<AudioManager>().PlaySound("NomedoSom");

        if (instance == null) //fazemos isto porque com o DontDestroy acabamos por ter 2 audiomanagers , verificamos se existe uma instancia
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);//ao mudar de cena o audiomanager nao é destruido e assim a musica de tema nao da restart

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.loop = s.loop;
        }
    }

    //Musica durante o jogo , depois nao esquecer ativar o loop
    private void Start()
    {
       
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
