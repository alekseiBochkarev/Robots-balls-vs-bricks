public class SceneConfiguration3 : SceneConfiguration
{
    void Awake()
    {
        _objectGamePositions = new[]
        {
            new ObjectGamePosition("enemies/Brick3", 3, 2, 6), 
            new ObjectGamePosition("enemies/Brick3", 4, 2, 6),
            new ObjectGamePosition("enemies/Brick3", 5, 2, 6), 
            new ObjectGamePosition("enemies/Brick3", 6, 2, 6), 
            new ObjectGamePosition("enemies/Brick3", 7, 2, 6), 
            new ObjectGamePosition("enemies/Brick3", 8, 2, 6), 
            
            new ObjectGamePosition("enemies/Brick2", 2, 3, 6), 
            new ObjectGamePosition("enemies/Brick2", 4, 3, 6),
            new ObjectGamePosition("enemies/BrickTriangle", 5, 3, 6), 
            new ObjectGamePosition("enemies/Brick2", 6, 3, 6), 
            new ObjectGamePosition("enemies/Brick2", 7, 3, 6), 
            new ObjectGamePosition("enemies/Brick2", 9, 3, 6), 
            
            new ObjectGamePosition("enemies/Brick3", 1, 4, 6), 
            new ObjectGamePosition("enemies/Brick3", 3, 4, 6), 
            new ObjectGamePosition("enemies/BrickBlue", 8, 4, 6), 
            new ObjectGamePosition("enemies/BrickBlue", 10, 4, 6),

            new ObjectGamePosition("enemies/BrickSquare", 1, 5, 6), 
            new ObjectGamePosition("enemies/BrickSquare", 2, 5, 6),
            new ObjectGamePosition("enemies/BrickSquare", 9, 5, 6), 
            new ObjectGamePosition("enemies/BrickSquare", 10, 5, 6), 
            
            new ObjectGamePosition("enemies/Brick2", 1, 6, 6),
            new ObjectGamePosition("enemies/Brick2", 4, 6, 6),
            new ObjectGamePosition("enemies/BrickBlue", 7, 6, 6),
            new ObjectGamePosition("enemies/BrickBlue", 10, 6, 6),

            new ObjectGamePosition("enemies/Brick3", 1, 7, 6),
            new ObjectGamePosition("enemies/Brick3", 2, 7, 6),
            new ObjectGamePosition("enemies/Brick3", 9, 7, 6),
            new ObjectGamePosition("enemies/BrickTriangle", 10, 7, 6),
            
            new ObjectGamePosition("enemies/BrickSquare", 2, 8, 6),
            new ObjectGamePosition("enemies/BrickSquare", 5, 8, 6),
            new ObjectGamePosition("enemies/BrickSquare", 6, 8, 6),
            new ObjectGamePosition("enemies/BrickSquare", 9, 8, 6),
            
            new ObjectGamePosition("enemies/Brick3", 3, 9, 6),
            new ObjectGamePosition("enemies/Brick3", 4, 9, 6),
            new ObjectGamePosition("enemies/Brick3", 5, 9, 6),
            new ObjectGamePosition("enemies/Brick3", 6, 9, 6),
            new ObjectGamePosition("enemies/Brick3", 7, 9, 6),
            new ObjectGamePosition("enemies/Brick3", 8, 9, 6),

            new ObjectGamePosition("extras/Magic Ball Particle", 11, 7, 1),
            new ObjectGamePosition("extras/Magic Ball Particle", 11, 8, 1),
            new ObjectGamePosition("extras/Magic Ball Particle", 11, 9, 1),
            new ObjectGamePosition("extras/Magic Ball Particle", 11, 10, 1),
            new ObjectGamePosition("extras/Magic Ball Particle", 11, 11, 1),
            
            new ObjectGamePosition("extras/Score Ball Particle", 0, 7, 1),
        };
    }
}