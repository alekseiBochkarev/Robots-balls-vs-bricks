public class SceneConfiguration2 : SceneConfiguration
{
    void Awake()
    {
        _objectGamePositions = new[]
        {
            new ObjectGamePosition("enemies/Brick3", 1, 3, 30), 
            new ObjectGamePosition("enemies/Brick3", 3, 3, 10),
            new ObjectGamePosition("enemies/Brick3", 4, 3, 10), 
            new ObjectGamePosition("enemies/Brick3", 7, 3, 10), 
            new ObjectGamePosition("enemies/Brick3", 8, 3, 10), 
            new ObjectGamePosition("enemies/Brick3", 10, 3, 30), 
            
            new ObjectGamePosition("enemies/Brick3", 1, 4, 10), 
            new ObjectGamePosition("enemies/Brick3", 2, 4, 30), 
            new ObjectGamePosition("enemies/Brick3", 4, 4, 10), 
            new ObjectGamePosition("enemies/Brick3", 5, 4, 10), 
            new ObjectGamePosition("enemies/Brick3", 6, 4, 10), 
            new ObjectGamePosition("enemies/Brick3", 7, 4, 10), 
            new ObjectGamePosition("enemies/Brick3", 9, 4, 30), 
            new ObjectGamePosition("enemies/Brick3", 10, 4, 10), 
            
            new ObjectGamePosition("enemies/Brick3", 2, 5, 10), 
            new ObjectGamePosition("enemies/Brick3", 9, 5, 10), 
            
            new ObjectGamePosition("enemies/Brick2", 2, 6, 10),
            new ObjectGamePosition("enemies/Brick2", 3, 6, 30),
            new ObjectGamePosition("enemies/Brick2", 4, 6, 10),
            new ObjectGamePosition("enemies/Brick2", 7, 6, 10),
            new ObjectGamePosition("enemies/Brick2", 8, 6, 30),
            new ObjectGamePosition("enemies/Brick2", 9, 6, 10),
            
            new ObjectGamePosition("enemies/Brick3", 3, 7, 10),
            new ObjectGamePosition("enemies/Brick3", 4, 7, 30),
            new ObjectGamePosition("enemies/Brick3", 5, 7, 30),
            new ObjectGamePosition("enemies/Brick3", 6, 7, 30),
            new ObjectGamePosition("enemies/Brick3", 7, 7, 30),
            new ObjectGamePosition("enemies/Brick3", 8, 7, 10),
            
            new ObjectGamePosition("extras/Magic Ball Particle", 11, 5, 1),
            
            new ObjectGamePosition("extras/Score Ball Particle", 0, 5, 1),
            
            new ObjectGamePosition("extras/Score Ball Particle", 1, 7, 1),
            new ObjectGamePosition("extras/Score Ball Particle", 10, 7, 1),
            
            new ObjectGamePosition("extras/Score Ball Particle", 2, 9, 1),
            new ObjectGamePosition("extras/Score Ball Particle", 9, 9, 1),
        };
    }
}