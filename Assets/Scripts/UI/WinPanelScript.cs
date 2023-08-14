using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinPanelScript : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    private GameObject camera;

    private void Awake()
    {
        camera = GameObject.Find("MainCamera");
    }

    private void OnEnable()
    {   
		BallLauncher.Instance.ReturnAllBallsToNewStartPosition();
		camera.GetComponent<AudioManager>().PlayAudio(clip); 
    }
}