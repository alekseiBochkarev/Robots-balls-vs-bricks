public class SceneConfiguration4 : SceneConfiguration
{
    void Awake()
    {
        _objectGamePositions = new[]
        {
            new ObjectGamePosition("enemies/Brick3", 0, 2, 8), 
            new ObjectGamePosition("enemies/Brick3", 11, 2, 8),

            new ObjectGamePosition("enemies/Brick2", 0, 3, 2), 
            new ObjectGamePosition("enemies/Brick2", 1, 3, 2),
            new ObjectGamePosition("enemies/Brick2", 10, 3, 2), 
            new ObjectGamePosition("enemies/Brick2", 11, 3, 2),

            new ObjectGamePosition("enemies/Brick3", 0, 4, 8), 
            new ObjectGamePosition("enemies/Brick3", 1, 4, 8), 
            new ObjectGamePosition("enemies/Brick3", 2, 4, 8), 
            new ObjectGamePosition("enemies/Brick3", 9, 4, 8), 
            new ObjectGamePosition("enemies/Brick3", 10, 4, 8), 
            new ObjectGamePosition("enemies/Brick3", 11, 4, 8),

            new ObjectGamePosition("enemies/BrickSquare", 0, 5, 8), 
            new ObjectGamePosition("enemies/BrickSquare", 1, 5, 8),
            new ObjectGamePosition("enemies/BrickSquare", 2, 5, 8), 
            new ObjectGamePosition("enemies/BrickSquare", 3, 5, 8), 
            new ObjectGamePosition("enemies/BrickSquare", 8, 5, 8), 
            new ObjectGamePosition("enemies/BrickSquare", 9, 5, 8),
            new ObjectGamePosition("enemies/BrickSquare", 10, 5, 8), 
            new ObjectGamePosition("enemies/BrickSquare", 11, 5, 8), 
            
            new ObjectGamePosition("enemies/Brick2", 0, 6, 2),
            new ObjectGamePosition("enemies/Brick2", 1, 6, 2),
            new ObjectGamePosition("enemies/Brick2", 2, 6, 2),
            new ObjectGamePosition("enemies/Brick2", 3, 6, 2),
            new ObjectGamePosition("enemies/Brick2", 8, 6, 2),
            new ObjectGamePosition("enemies/Brick2", 9, 6, 2),
            new ObjectGamePosition("enemies/Brick2", 10, 6, 2),
            new ObjectGamePosition("enemies/Brick2", 11, 6, 2),

            new ObjectGamePosition("extras/Magic Ball Particle", 0, 1, 1),
            
            new ObjectGamePosition("extras/Score Ball Particle", 1, 2, 1),
        };
    }
}