using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource punchSound;
    [SerializeField] AudioSource music;

    public void PlayPunch()
    {
        punchSound.Play();
    }

    public void PlayMainMenuMusic()
    {
        music.Play();
    }
    
    public void PlayGameMusic()
    {
        music.Play();
    }
}
