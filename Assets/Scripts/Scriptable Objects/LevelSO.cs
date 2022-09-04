using UnityEngine;

[CreateAssetMenu (fileName = "New Map", menuName = "Scriptable Objects/Map")]
public class LevelSO : ScriptableObject
{
    public int levelIndex;
    public string levelName;
    public string levelDescription;
    public Color nameColor;
    public Sprite levelImage;
    public Object sceneToLoad;

}
