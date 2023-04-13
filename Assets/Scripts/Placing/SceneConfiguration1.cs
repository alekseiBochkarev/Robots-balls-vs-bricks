public class SceneConfiguration1 : SceneConfiguration
{
    void Awake()
    {
        _objectGamePositions = new[]
        {
            new ObjectGamePosition("enemies/Brick2", 3, 5), new ObjectGamePosition("enemies/Brick2", 2, 7),
            new ObjectGamePosition("enemies/Brick2", 4, 1),
            new ObjectGamePosition("extras/Magic Ball Particle", 5, 2),
            new ObjectGamePosition("extras/Score Ball Particle", 6, 4)
        };
    }
}