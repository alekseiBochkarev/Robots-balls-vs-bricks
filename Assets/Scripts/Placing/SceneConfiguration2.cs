public class SceneConfiguration2 : SceneConfiguration
{
    void Awake()
    {
        _objectGamePositions = new[]
        {
            new ObjectGamePosition("enemies/Brick2", 2, 1, 10), 
new ObjectGamePosition("enemies/Brick2", 2, 2, 10),
            new ObjectGamePosition("enemies/Brick2", 2, 3, 10),
            new ObjectGamePosition("extras/Magic Ball Particle", 5, 7, 1),
            new ObjectGamePosition("extras/Score Ball Particle", 6, 8, 1)
        };
    }
}