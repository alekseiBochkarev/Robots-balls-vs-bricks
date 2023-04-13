public class SceneConfiguration2 : SceneConfiguration
{
    void Awake()
    {
        _objectGamePositions = new[]
        {
            new ObjectGamePosition("enemies/Brick2", 2, 1), new ObjectGamePosition("enemies/Brick2", 2, 2),
            new ObjectGamePosition("enemies/Brick2", 2, 3),
            new ObjectGamePosition("extras/Magic Ball Particle", 5, 7),
            new ObjectGamePosition("extras/Score Ball Particle", 6, 8)
        };
    }
}