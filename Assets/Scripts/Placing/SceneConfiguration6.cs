public class SceneConfiguration6 : SceneConfiguration
{
    public ObjectGamePosition[] SetObjects()
    {
        _objectGamePositions = new[]
        {
            new ObjectGamePosition("enemies/UFO", 5, 5, 1), 
            
            new ObjectGamePosition("enemies/Brick3", 0, 2, 8), 
            new ObjectGamePosition("enemies/Brick3", 11, 2, 8),

            new ObjectGamePosition("enemies/Brick3", 0, 3, 2), 
            new ObjectGamePosition("enemies/Brick3", 1, 3, 2),
            new ObjectGamePosition("enemies/Brick3", 10, 3, 2), 
            new ObjectGamePosition("enemies/Brick3", 11, 3, 2),

            new ObjectGamePosition("enemies/Brick3", 0, 4, 8), 
            new ObjectGamePosition("enemies/BrickBombaSmall", 1, 4, 8), 
            new ObjectGamePosition("enemies/Brick3", 2, 4, 8), 
            new ObjectGamePosition("enemies/Brick3", 9, 4, 8), 
            new ObjectGamePosition("enemies/BrickBombaSmall", 10, 4, 8), 
            new ObjectGamePosition("enemies/Brick3", 11, 4, 8),

            new ObjectGamePosition("enemies/BrickSquareBlue", 0, 5, 8), 
            new ObjectGamePosition("enemies/BrickSquareBlue", 1, 5, 8),
            new ObjectGamePosition("enemies/BrickSquareBlue", 2, 5, 8), 
            new ObjectGamePosition("enemies/BrickSquareBlue", 3, 5, 8), 
            new ObjectGamePosition("enemies/BrickSquareBlue", 8, 5, 8), 
            new ObjectGamePosition("enemies/BrickSquareBlue", 9, 5, 8),
            new ObjectGamePosition("enemies/BrickSquareBlue", 10, 5, 8), 
            new ObjectGamePosition("enemies/BrickSquareBlue", 11, 5, 8), 
            
            new ObjectGamePosition("enemies/Brick3", 0, 6, 2),
            new ObjectGamePosition("enemies/Brick3", 1, 6, 2),
            new ObjectGamePosition("enemies/Brick3", 2, 6, 2),
            new ObjectGamePosition("enemies/Brick3", 3, 6, 2),
            new ObjectGamePosition("enemies/Brick3", 8, 6, 2),
            new ObjectGamePosition("enemies/Brick3", 9, 6, 2),
            new ObjectGamePosition("enemies/Brick3", 10, 6, 2),
            new ObjectGamePosition("enemies/Brick3", 11, 6, 2),

            new ObjectGamePosition("extras/Magic Ball Particle", 0, 1, 1),
            new ObjectGamePosition("extras/Magic Ball Particle", 11, 1, 1),
            
            new ObjectGamePosition("extras/Score Ball Particle", 1, 2, 1),
            new ObjectGamePosition("extras/Score Ball Particle", 10, 2, 1),
        };
        return _objectGamePositions;
    }
}