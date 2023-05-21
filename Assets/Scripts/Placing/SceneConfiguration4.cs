public class SceneConfiguration4 : SceneConfiguration
{
    void Awake()
    {
        _objectGamePositions = new[]
        {
            new ObjectGamePosition("enemies/Brick3", 0, 2, 10), 
            new ObjectGamePosition("enemies/Brick3", 11, 2, 10),

            new ObjectGamePosition("enemies/Brick2", 0, 3, 20), 
            new ObjectGamePosition("enemies/Brick2", 1, 3, 20),
            new ObjectGamePosition("enemies/Brick2", 10, 3, 20), 
            new ObjectGamePosition("enemies/Brick2", 11, 3, 20),

            new ObjectGamePosition("enemies/Brick3", 0, 4, 20), 
            new ObjectGamePosition("enemies/Brick3", 1, 4, 20), 
            new ObjectGamePosition("enemies/Brick3", 2, 4, 20), 
            new ObjectGamePosition("enemies/Brick3", 9, 4, 20), 
            new ObjectGamePosition("enemies/Brick3", 10, 4, 10), 
            new ObjectGamePosition("enemies/Brick3", 11, 4, 10),

            new ObjectGamePosition("enemies/Brick3", 0, 5, 10), 
            new ObjectGamePosition("enemies/Brick3", 1, 5, 10),
            new ObjectGamePosition("enemies/Brick3", 2, 5, 10), 
            new ObjectGamePosition("enemies/Brick3", 3, 5, 10), 
            new ObjectGamePosition("enemies/Brick3", 8, 5, 10), 
            new ObjectGamePosition("enemies/Brick3", 9, 5, 10),
            new ObjectGamePosition("enemies/Brick3", 10, 5, 10), 
            new ObjectGamePosition("enemies/Brick3", 11, 5, 10), 
            
            new ObjectGamePosition("enemies/Brick2", 0, 6, 30),
            new ObjectGamePosition("enemies/Brick2", 1, 6, 10),
            new ObjectGamePosition("enemies/Brick2", 2, 6, 10),
            new ObjectGamePosition("enemies/Brick2", 3, 6, 30),
            new ObjectGamePosition("enemies/Brick2", 8, 6, 30),
            new ObjectGamePosition("enemies/Brick2", 9, 6, 10),
            new ObjectGamePosition("enemies/Brick2", 10, 6, 10),
            new ObjectGamePosition("enemies/Brick2", 11, 6, 30),

            new ObjectGamePosition("extras/Magic Ball Particle", 0, 1, 1),
            
            new ObjectGamePosition("extras/Score Ball Particle", 1, 2, 1),
        };
    }
}