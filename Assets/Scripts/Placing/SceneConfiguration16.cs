public class SceneConfiguration16 : SceneConfiguration
{
    void Awake()
    {
        _objectGamePositions = new[]
        {
	        new ObjectGamePosition("enemies/UFO", 5, 5, 1), 
	        
	        new ObjectGamePosition("enemies/BrickSquareBlue", 1, 1, 12),
			new ObjectGamePosition("enemies/BrickSquareBlue", 3, 1, 12),
			new ObjectGamePosition("enemies/BrickSquareBlue", 4, 1, 12),
			new ObjectGamePosition("enemies/BrickSquareBlue", 5, 1, 12),
			new ObjectGamePosition("enemies/BrickSquareBlue", 6, 1, 12),
			new ObjectGamePosition("enemies/BrickSquareBlue", 7, 1, 12),
			new ObjectGamePosition("enemies/BrickSquareBlue", 8, 1, 12),
			new ObjectGamePosition("enemies/BrickSquareBlue", 10, 1, 12),

			new ObjectGamePosition("enemies/BrickSimpleTriangle1", 0, 2, 12), 
            new ObjectGamePosition("enemies/Brick3", 2, 2, 12),
            new ObjectGamePosition("enemies/Brick3", 5, 2, 12),
            new ObjectGamePosition("enemies/Brick3", 6, 2, 12),
            new ObjectGamePosition("enemies/Brick3", 9, 2, 12),
            new ObjectGamePosition("enemies/BrickSimpleTriangle2", 11, 2, 12),

            new ObjectGamePosition("enemies/BrickSquarePurple", 0, 3, 12), 
            new ObjectGamePosition("enemies/Brick3", 2, 3, 12),
            new ObjectGamePosition("enemies/Brick3", 3, 3, 12), 
            new ObjectGamePosition("enemies/Brick3", 4, 3, 12),
            new ObjectGamePosition("enemies/Brick3", 5, 3, 12),
            new ObjectGamePosition("enemies/Brick3", 6, 3, 12),
            new ObjectGamePosition("enemies/Brick3", 7, 3, 12),
            new ObjectGamePosition("enemies/Brick3", 8, 3, 12),
            new ObjectGamePosition("enemies/BrickSquarePurple", 11, 3, 12),

			new ObjectGamePosition("enemies/BrickSimpleTriangle4", 0, 4, 12), 
            new ObjectGamePosition("enemies/Brick3", 2, 4, 12),
            new ObjectGamePosition("enemies/Brick3", 4, 4, 12),
            new ObjectGamePosition("enemies/Brick3", 5, 4, 12),
            new ObjectGamePosition("enemies/BrickBombaSmall", 6, 4, 12),
            new ObjectGamePosition("enemies/BrickBombaSmall", 7, 4, 12),
            new ObjectGamePosition("enemies/Brick3", 8, 4, 12),
            new ObjectGamePosition("enemies/Brick3", 9, 4, 12),
            new ObjectGamePosition("enemies/BrickSimpleTriangle3", 11, 4, 12),

            new ObjectGamePosition("enemies/BrickSquareBlue", 1, 5, 8), 
            new ObjectGamePosition("enemies/BrickSquareBlue", 4, 5, 8),
            new ObjectGamePosition("enemies/BrickSquareBlue", 5, 5, 8), 
            new ObjectGamePosition("enemies/BrickSquareBlue", 6, 5, 8), 
            new ObjectGamePosition("enemies/BrickSquareBlue", 7, 5, 8), 
            new ObjectGamePosition("enemies/BrickSquareBlue", 8, 5, 8),
            new ObjectGamePosition("enemies/BrickSquareBlue", 9, 5, 8), 
            new ObjectGamePosition("enemies/BrickSquareBlue", 10, 5, 8), 

            new ObjectGamePosition("extras/Magic Ball Particle", 2, 1, 1),
            new ObjectGamePosition("extras/Magic Ball Particle", 10, 2, 1),
            
            new ObjectGamePosition("extras/Score Ball Particle", 9, 3, 1),
            new ObjectGamePosition("extras/Score Ball Particle", 1, 4, 1),
            new ObjectGamePosition("extras/Score Ball Particle", 3, 5, 1),
        };
    }
}