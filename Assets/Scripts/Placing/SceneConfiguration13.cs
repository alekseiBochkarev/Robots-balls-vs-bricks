public class SceneConfiguration13 : SceneConfiguration
{
    public ObjectGamePosition[] SetObjects()
    {
        _objectGamePositions = new[]
        {
            new ObjectGamePosition("enemies/UFO", 5, 5, 1), 
            
            new ObjectGamePosition("enemies/BrickSquarePurple", 0, 1, 10), 
            new ObjectGamePosition("enemies/BrickSquarePurple", 1, 1, 10), 
            new ObjectGamePosition("enemies/BrickSquarePurple", 2, 1, 10), 
            new ObjectGamePosition("enemies/BrickSquarePurple", 3, 1, 10), 
            new ObjectGamePosition("enemies/BrickSquarePurple", 4, 1, 10), 
            
            new ObjectGamePosition("enemies/BrickFire", 5, 2, 8),
            new ObjectGamePosition("enemies/BrickFire", 6, 2, 8),
            
            new ObjectGamePosition("enemies/BrickFire", 0, 3, 8),
            new ObjectGamePosition("enemies/BrickFire", 1, 3, 8), 
            new ObjectGamePosition("enemies/BrickBombaSmall", 2, 3, 8), 
            new ObjectGamePosition("enemies/BrickFire", 3, 3, 8), 
            new ObjectGamePosition("enemies/BrickFire", 5, 3, 8),
            new ObjectGamePosition("enemies/BrickFire", 6, 3, 8), 
            new ObjectGamePosition("enemies/BrickFire", 7, 3, 8), 
            new ObjectGamePosition("enemies/BrickSquare", 8, 3, 10),
            new ObjectGamePosition("enemies/BrickSquare", 9, 3, 10),
            new ObjectGamePosition("enemies/BrickSquare", 10, 3, 10),
            new ObjectGamePosition("enemies/BrickSquare", 11, 3, 10),
            
            new ObjectGamePosition("enemies/BrickFire", 0, 4, 8),
            new ObjectGamePosition("enemies/BrickFire", 1, 4, 8), 
            new ObjectGamePosition("enemies/BrickFire", 2, 4, 8), 
            new ObjectGamePosition("enemies/BrickFire", 3, 4, 8), 
           
            new ObjectGamePosition("enemies/BrickFire", 5, 5, 8),
            new ObjectGamePosition("enemies/BrickFire", 6, 5, 8), 
            new ObjectGamePosition("enemies/BrickSquare", 7, 5, 10), 
            new ObjectGamePosition("enemies/BrickFire", 8, 5, 8),
            new ObjectGamePosition("enemies/BrickFire", 9, 5, 8),
            
            new ObjectGamePosition("enemies/BrickSquarePurple", 1, 6, 10),
            new ObjectGamePosition("enemies/BrickSquarePurple", 2, 6, 10),
            new ObjectGamePosition("enemies/BrickSquarePurple", 3, 6, 10),
            new ObjectGamePosition("enemies/BrickSquarePurple", 4, 6, 10),
            new ObjectGamePosition("enemies/BrickFire", 5, 6, 8),
            new ObjectGamePosition("enemies/BrickFire", 6, 6, 8), 
            new ObjectGamePosition("enemies/BrickSquare", 7, 6, 10), 
            new ObjectGamePosition("enemies/BrickFire", 8, 6, 8),
            new ObjectGamePosition("enemies/BrickBombaSmall", 9, 6, 8),
            
            new ObjectGamePosition("extras/Magic Ball Particle", 2, 2, 1),
            new ObjectGamePosition("extras/Magic Ball Particle", 2, 5, 1),
            
            new ObjectGamePosition("extras/Score Ball Particle", 9, 4, 1),
        };
        return _objectGamePositions;
    }
}