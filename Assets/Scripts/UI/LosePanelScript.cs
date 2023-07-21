using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LosePanelScript : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    private GameObject camera;

    private void Awake()
    {
        camera = GameObject.Find("MainCamera");
    }

    private void OnEnable()
    {
        camera.GetComponent<AudioManager>().PlayAudio(clip); 
    }
}