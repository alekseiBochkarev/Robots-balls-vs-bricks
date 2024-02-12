public class SceneConfiguration4 : SceneConfiguration
{
    public ObjectGamePosition[] SetObjects()
    {
        _objectGamePositions = new[]
        {
            new ObjectGamePosition("enemies/UFO", 5, 5, 1), 
            
            new ObjectGamePosition("enemies/BrickBlue", 3, 2, 2), 
            new ObjectGamePosition("enemies/BrickBlue", 4, 2, 2),
            new ObjectGamePosition("enemies/BrickBombaSmall", 5, 2, 2), 
            new ObjectGamePosition("enemies/BrickBombaSmall", 6, 2, 2), 
            new ObjectGamePosition("enemies/BrickBlue", 7, 2, 2), 
            new ObjectGamePosition("enemies/BrickBlue", 8, 2, 2), 
            
            new ObjectGamePosition("enemies/BrickSkeleton", 2, 3, 3), 
            new ObjectGamePosition("enemies/BrickSkeleton", 4, 3, 3),
            new ObjectGamePosition("enemies/BrickBombaSmall", 5, 3, 2), 
            new ObjectGamePosition("enemies/BrickBombaSmall", 6, 3, 2), 
            new ObjectGamePosition("enemies/BrickSkeleton", 7, 3, 3), 
            new ObjectGamePosition("enemies/BrickSkeleton", 9, 3, 3), 
            
            new ObjectGamePosition("enemies/BrickSkeleton", 1, 4, 3), 
            new ObjectGamePosition("enemies/BrickSkeleton", 3, 4, 3), 
            new ObjectGamePosition("enemies/BrickSkeleton", 8, 4, 3), 
            new ObjectGamePosition("enemies/BrickSkeleton", 10, 4, 3),

            new ObjectGamePosition("enemies/BrickSquareBlue", 1, 5, 3), 
            new ObjectGamePosition("enemies/BrickSquareBlue", 2, 5, 3),
            new ObjectGamePosition("enemies/BrickSquareBlue", 9, 5, 3), 
            new ObjectGamePosition("enemies/BrickSquareBlue", 10, 5, 3), 
            
            new ObjectGamePosition("enemies/BrickSkeleton", 1, 6, 3),
            new ObjectGamePosition("enemies/BrickSkeleton", 4, 6, 3),
            new ObjectGamePosition("enemies/BrickSkeleton", 7, 6, 3),
            new ObjectGamePosition("enemies/BrickSkeleton", 10, 6, 3),

            new ObjectGamePosition("enemies/BrickSkeleton", 1, 7, 3),
            new ObjectGamePosition("enemies/BrickSkeleton", 2, 7, 3),
            new ObjectGamePosition("enemies/BrickSkeleton", 9, 7, 3),
            new ObjectGamePosition("enemies/BrickSkeleton", 10, 7, 3),
            
            new ObjectGamePosition("enemies/BrickSquareBlue", 2, 8, 3),
            new ObjectGamePosition("enemies/BrickSquareBlue", 5, 8, 3),
            new ObjectGamePosition("enemies/BrickSquareBlue", 6, 8, 3),
            new ObjectGamePosition("enemies/BrickSquareBlue", 9, 8, 3),
            
            new ObjectGamePosition("enemies/BrickBlue", 3, 9, 2),
            new ObjectGamePosition("enemies/BrickSkeleton", 4, 9, 3),
            new ObjectGamePosition("enemies/BrickBombaSmall", 5, 9, 1),
            new ObjectGamePosition("enemies/BrickBombaSmall", 6, 9, 1),
            new ObjectGamePosition("enemies/BrickSkeleton", 7, 9, 3),
            new ObjectGamePosition("enemies/BrickBlue", 8, 9, 2),

            new ObjectGamePosition("extras/Magic Ball Particle", 11, 7, 1),
           
            new ObjectGamePosition("extras/Score Ball Particle", 0, 7, 1),
        };
        return _objectGamePositions;
    }
}