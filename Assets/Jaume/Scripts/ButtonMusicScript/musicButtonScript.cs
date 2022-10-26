using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class musicButtonScript : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip buttonMusic;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void playButtonMusic()
    {
        StartCoroutine(PlayAudio(buttonMusic));
    }

    IEnumerator PlayAudio(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();
        yield return new WaitForSeconds(audio.length);
    }
}
