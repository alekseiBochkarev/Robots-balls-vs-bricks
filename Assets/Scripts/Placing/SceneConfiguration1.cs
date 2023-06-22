public class SceneConfiguration1 : SceneConfiguration
{
    void Awake()
    {
        _objectGamePositions = new[]
        {
            new ObjectGamePosition("enemies/BrickBlue", 1, 3, 2), 
			new ObjectGamePosition("enemies/BrickBlue", 2, 3, 2),
			new ObjectGamePosition("enemies/BrickSquare", 3, 3, 2),
            new ObjectGamePosition("enemies/BrickSquare", 4, 3, 2),
            new ObjectGamePosition("enemies/BrickSquare", 5, 3, 2),
            new ObjectGamePosition("enemies/BrickSquare", 6, 3, 2),
            new ObjectGamePosition("enemies/BrickSquare", 7, 3, 2),
            new ObjectGamePosition("enemies/BrickSquare", 8, 3, 2),
            new ObjectGamePosition("enemies/BrickBlue", 9, 3, 2),
            new ObjectGamePosition("enemies/BrickBlue", 10, 3, 2),
            
            new ObjectGamePosition("enemies/BrickBlue", 10, 4, 2),
           
            new ObjectGamePosition("enemies/BrickSquare", 1, 5, 2),
            new ObjectGamePosition("enemies/BrickSquare", 3, 5, 2),
            new ObjectGamePosition("enemies/BrickSquare", 4, 5, 2),
            new ObjectGamePosition("enemies/BrickSquare", 5, 5, 2),
            new ObjectGamePosition("enemies/BrickBlue", 6, 5, 2),
            new ObjectGamePosition("enemies/BrickSquare", 7, 5, 2),
            new ObjectGamePosition("enemies/BrickSquare", 8, 5, 2),
            new ObjectGamePosition("enemies/BrickSquare", 10, 5, 2),
            
            new ObjectGamePosition("enemies/BrickBlue", 1, 6, 2),
            
            new ObjectGamePosition("enemies/BrickBlue", 1, 7, 2), 
			new ObjectGamePosition("enemies/BrickBlue", 2, 7, 2),
			new ObjectGamePosition("enemies/BrickBlue", 3, 7, 2),
            new ObjectGamePosition("enemies/BrickSquare", 4, 7, 2),
            new ObjectGamePosition("enemies/BrickSquare", 5, 7, 2),
            new ObjectGamePosition("enemies/BrickSquare", 6, 7, 2),
            new ObjectGamePosition("enemies/BrickSquare", 7, 7, 2),
            new ObjectGamePosition("enemies/BrickSquare", 8, 7, 2),
            new ObjectGamePosition("enemies/BrickSquare", 9, 7, 2),
            new ObjectGamePosition("enemies/BrickBlue", 10, 7, 2),
            
            new ObjectGamePosition("extras/Magic Ball Particle", 1, 2, 1),
            new ObjectGamePosition("extras/Score Ball Particle", 10, 2, 1)
        };
    }
}