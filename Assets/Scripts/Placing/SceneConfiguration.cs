using UnityEngine;
public class SceneConfiguration : MonoBehaviour
{
    public ObjectGamePosition[] _objectGamePositions;
    public ObjectGamePosition[] SetObjects() {
        return new ObjectGamePosition[1];
    }

    public void Awake()
    {
        Debug.Log("Awake for scene Configuration");
        SceneConfiguration1 sceneConfiguration = new SceneConfiguration1();
        _objectGamePositions = sceneConfiguration.SetObjects();
    }

}