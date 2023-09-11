public class SceneConfiguration24 : SceneConfiguration
{
    void Awake()
    {
        _objectGamePositions = new[]
        {
            new ObjectGamePosition("enemies/UFO", 5, 5, 1), 
            
            new ObjectGamePosition("enemies/BrickBombaSmall", 0, 1, 24),
            new ObjectGamePosition("enemies/BrickBombaSmall", 4, 1, 24),
            new ObjectGamePosition("enemies/BrickBombaSmall", 8, 1, 24),
            new ObjectGamePosition("enemies/BrickBombaSmall", 9, 1, 24),
            new ObjectGamePosition("enemies/BrickBombaSmall", 10, 1, 24),

            new ObjectGamePosition("enemies/BrickBombaSmall", 0, 2, 24),
            new ObjectGamePosition("enemies/BrickBoss2", 2, 2, 180),
            new ObjectGamePosition("enemies/BrickBombaSmall", 4, 2, 24),
            new ObjectGamePosition("enemies/BrickBombaSmall", 7, 2, 24),
            new ObjectGamePosition("enemies/BrickBombaSmall", 11, 2, 24),

            new ObjectGamePosition("enemies/BrickBombaSmall", 0, 3, 24),
            new ObjectGamePosition("enemies/BrickSquare", 5, 3, 24),
            new ObjectGamePosition("enemies/BrickBombaSmall", 6, 3, 24),
            new ObjectGamePosition("enemies/BrickBoss", 9, 3, 180),
            new ObjectGamePosition("enemies/BrickBombaSmall", 11, 3, 24),

            new ObjectGamePosition("enemies/Brick3", 1, 4, 24),
            new ObjectGamePosition("enemies/BrickSquare", 5, 4, 24),
                      
            new ObjectGamePosition("enemies/BrickBombaSmall", 2, 5, 24),
            new ObjectGamePosition("enemies/BrickBombaSmall", 8, 5, 24),
            new ObjectGamePosition("enemies/BrickBombaSmall", 9, 5, 24),
            new ObjectGamePosition("enemies/Brick3", 10, 5, 24),
            
            new ObjectGamePosition("enemies/BrickBombaSmall", 3, 6, 24),
            new ObjectGamePosition("enemies/BrickBoss3", 5, 6, 180),
            new ObjectGamePosition("enemies/BrickBombaSmall", 7, 6, 24),
                        
            new ObjectGamePosition("enemies/BrickBombaSmall", 4, 8, 12),
            new ObjectGamePosition("enemies/BrickBombaSmall", 5, 8, 12),
            
        };
    }
}