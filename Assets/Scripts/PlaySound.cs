using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public string audioClipName;
    public void PlayAudio()
    {
        FindObjectOfType<AudioManager>().PlaySound(audioClipName);
    }
}
