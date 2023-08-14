public class SceneConfiguration9 : SceneConfiguration
{
    void Awake()
    {
        _objectGamePositions = new[]
        {
            new ObjectGamePosition("enemies/Brick3", 0, 2, 12),
            new ObjectGamePosition("enemies/Brick3", 11, 2, 12),
            
            new ObjectGamePosition("enemies/Brick3", 0, 3, 12),
            new ObjectGamePosition("enemies/Brick3", 11, 3, 12),
            
            new ObjectGamePosition("enemies/Brick3", 0, 4, 12),
            new ObjectGamePosition("enemies/Brick3", 11, 4, 12),
            
            new ObjectGamePosition("enemies/Brick3", 1, 5, 12),
            new ObjectGamePosition("enemies/Brick3", 10, 5, 12),
            
            new ObjectGamePosition("enemies/Brick3", 2, 6, 12),
            new ObjectGamePosition("enemies/Brick3", 9, 6, 12),
            
            new ObjectGamePosition("enemies/Brick3", 3, 7, 12),
            new ObjectGamePosition("enemies/Brick3", 8, 7, 12),
            
            new ObjectGamePosition("enemies/Brick3", 4, 8, 12),
            new ObjectGamePosition("enemies/Brick3", 7, 8, 12),
            
            new ObjectGamePosition("enemies/BrickBombaSmall", 5, 8, 12),
            new ObjectGamePosition("enemies/BrickBombaSmall", 6, 8, 12),
            
            new ObjectGamePosition("enemies/BrickBoss", 5, 4, 40),

            new ObjectGamePosition("extras/Magic Ball Particle", 5, 2, 1),
            
            new ObjectGamePosition("extras/Score Ball Particle", 3, 3, 1),
            new ObjectGamePosition("extras/Score Ball Particle", 7, 3, 1),
        };
    }
}