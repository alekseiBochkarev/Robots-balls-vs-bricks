public class SceneConfiguration10 : SceneConfiguration
{
    public ObjectGamePosition[] SetObjects()
    {
        _objectGamePositions = new[]
        {
            new ObjectGamePosition("enemies/UFO", 5, 5, 1), 
            
            new ObjectGamePosition("enemies/BrickBombaSmall", 1, 1, 10),
            new ObjectGamePosition("enemies/BrickSquareBlue", 2, 1, 10), 
            new ObjectGamePosition("enemies/BrickSquareBlue", 3, 1, 10),
            new ObjectGamePosition("enemies/BrickSquareBlue", 8, 1, 10), 
            new ObjectGamePosition("enemies/BrickSquareBlue", 9, 1, 10),
            new ObjectGamePosition("enemies/BrickBombaSmall", 10, 1, 10), 
            
            new ObjectGamePosition("enemies/BrickAborigen", 0, 2, 2), 
            new ObjectGamePosition("enemies/BrickAborigen", 4, 2, 2),
            new ObjectGamePosition("enemies/BrickAborigen", 7, 2, 2),
            new ObjectGamePosition("enemies/BrickAborigen", 11, 2, 2),

            new ObjectGamePosition("enemies/BrickSquareBlue", 0, 3, 4), 
            new ObjectGamePosition("enemies/BrickAborigen", 2, 3, 4),
            new ObjectGamePosition("enemies/BrickSquareBlue", 4, 3, 4), 
            new ObjectGamePosition("enemies/BrickSquareBlue", 7, 3, 4),
            new ObjectGamePosition("enemies/BrickAborigen", 9, 3, 4),
            new ObjectGamePosition("enemies/BrickSquareBlue", 11, 3, 4),

            new ObjectGamePosition("enemies/BrickAborigen", 0, 4, 2), 
            new ObjectGamePosition("enemies/BrickAborigen", 11, 4, 2),

            new ObjectGamePosition("enemies/BrickAborigen", 0, 5, 10),
            new ObjectGamePosition("enemies/BrickSquareBlue", 1, 5, 10),
            new ObjectGamePosition("enemies/BrickSquareBlue", 2, 5, 10), 
            new ObjectGamePosition("enemies/BrickSquareBlue", 3, 5, 10), 
            new ObjectGamePosition("enemies/BrickSimpleTriangle4", 4, 5, 10), 
            new ObjectGamePosition("enemies/BrickSimpleTriangle3", 7, 5, 10),
            new ObjectGamePosition("enemies/BrickSquareBlue", 8, 5, 10), 
            new ObjectGamePosition("enemies/BrickSquareBlue", 9, 5, 10), 
            new ObjectGamePosition("enemies/BrickSquareBlue", 10, 5, 2),
            new ObjectGamePosition("enemies/BrickAborigen", 11, 5, 2),
            
            new ObjectGamePosition("enemies/BrickSimpleTriangle4", 0, 6, 10),
            new ObjectGamePosition("enemies/BrickSimpleTriangle3", 11, 6, 10),
            
            new ObjectGamePosition("enemies/BrickSquareBlue", 3, 7, 10), 
            new ObjectGamePosition("enemies/BrickSquareBlue", 4, 7, 10), 
            new ObjectGamePosition("enemies/BrickSquareBlue", 5, 7, 10),
            new ObjectGamePosition("enemies/BrickSquareBlue", 6, 7, 10), 
            new ObjectGamePosition("enemies/BrickSquareBlue", 7, 7, 10), 
            new ObjectGamePosition("enemies/BrickSquareBlue", 8, 7, 10),
            
            new ObjectGamePosition("extras/Magic Ball Particle", 3, 8, 1), 
            new ObjectGamePosition("extras/Magic Ball Particle", 4, 8, 1), 
            new ObjectGamePosition("extras/Magic Ball Particle", 5, 8, 1),
            
            new ObjectGamePosition("extras/Score Ball Particle", 6, 8, 1), 
            new ObjectGamePosition("extras/Score Ball Particle", 7, 8, 1), 
            new ObjectGamePosition("extras/Score Ball Particle", 8, 8, 1),
            
        };
        return _objectGamePositions;
    }
}