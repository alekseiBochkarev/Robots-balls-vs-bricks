public class SceneConfiguration9 : SceneConfiguration
{
    void Awake()
    {
        _objectGamePositions = new[]
        {
            new ObjectGamePosition("enemies/Brick3", 1, 2, 12),
            new ObjectGamePosition("enemies/Brick3", 10, 2, 12),
            
            new ObjectGamePosition("enemies/BrickBoss", 5, 4, 40),

            new ObjectGamePosition("extras/Magic Ball Particle", 5, 2, 1),
            
            new ObjectGamePosition("extras/Score Ball Particle", 3, 3, 1),
            new ObjectGamePosition("extras/Score Ball Particle", 7, 3, 1),
        };
    }
}