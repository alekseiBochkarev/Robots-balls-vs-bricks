using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    private bool m_CanPlaySound = true;
    private AudioSource m_AudioSource;


    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(AudioClip clip)
    {
        m_AudioSource.PlayOneShot(clip);
       // Debug.Log("play sound");
    }
}