using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private ScriptableObject[] levelsSO;
    [SerializeField] private LevelDisplay levelDisplay;
    private int currentIndex;

    private void Awake() 
    {
       ChangeScriptableObject(PlayerPrefs.GetInt("currentScene", 0)); // displays last opened level when we open level selection
    }

    public void ChangeScriptableObject(int _change)
    {
        currentIndex += _change;

        if (currentIndex < 0) currentIndex = levelsSO.Length - 1;
        else if (currentIndex > levelsSO.Length - 1) currentIndex = 0;

        if (levelDisplay != null) levelDisplay.DisplayMap( (LevelSO)levelsSO[currentIndex]);
    
    }
}
