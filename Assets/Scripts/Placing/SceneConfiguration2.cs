public class SceneConfiguration2 : SceneConfiguration
{
    void Awake()
    {
        _objectGamePositions = new[]
        {
            new ObjectGamePosition("enemies/BrickFire", 1, 3, 2), 
            new ObjectGamePosition("enemies/BrickFire", 3, 3, 2),
            new ObjectGamePosition("enemies/BrickFire", 4, 3, 2), 
            new ObjectGamePosition("enemies/BrickFire", 7, 3, 2), 
            new ObjectGamePosition("enemies/BrickFire", 8, 3, 2), 
            new ObjectGamePosition("enemies/BrickFire", 10, 3, 2), 
            
            new ObjectGamePosition("enemies/BrickFire", 1, 4, 1), 
            new ObjectGamePosition("enemies/BrickFire", 2, 4, 1), 
            new ObjectGamePosition("enemies/BrickFire", 4, 4, 1), 
            new ObjectGamePosition("enemies/BrickFire", 5, 4, 1), 
            new ObjectGamePosition("enemies/BrickFire", 6, 4, 1), 
            new ObjectGamePosition("enemies/BrickFire", 7, 4, 1), 
            new ObjectGamePosition("enemies/BrickFire", 9, 4, 1), 
            new ObjectGamePosition("enemies/BrickFire", 10, 4, 1), 
            
            new ObjectGamePosition("enemies/BrickFire", 2, 5, 1), 
            new ObjectGamePosition("enemies/BrickFire", 9, 5, 1), 
            
            new ObjectGamePosition("enemies/BrickFire", 2, 6, 1),
            new ObjectGamePosition("enemies/BrickFire", 3, 6, 1),
            new ObjectGamePosition("enemies/BrickFire", 4, 6, 1),
            new ObjectGamePosition("enemies/BrickFire", 7, 6, 1),
            new ObjectGamePosition("enemies/BrickFire", 8, 6, 1),
            new ObjectGamePosition("enemies/BrickFire", 9, 6, 1),
            
            new ObjectGamePosition("enemies/BrickSquare", 3, 7, 4),
            new ObjectGamePosition("enemies/BrickSquare", 4, 7, 4),
            new ObjectGamePosition("enemies/BrickSquare", 5, 7, 4),
            new ObjectGamePosition("enemies/BrickSquare", 6, 7, 4),
            new ObjectGamePosition("enemies/BrickSquare", 7, 7, 4),
            new ObjectGamePosition("enemies/BrickSquare", 8, 7, 4),
            
            new ObjectGamePosition("extras/Magic Ball Particle", 11, 5, 1),
            
            new ObjectGamePosition("extras/Score Ball Particle", 0, 5, 1),
            
            new ObjectGamePosition("extras/Score Ball Particle", 1, 7, 1),
            new ObjectGamePosition("extras/Score Ball Particle", 10, 7, 1),
            
            new ObjectGamePosition("extras/Score Ball Particle", 2, 9, 1),
            new ObjectGamePosition("extras/Score Ball Particle", 9, 9, 1),
        };
    }
}