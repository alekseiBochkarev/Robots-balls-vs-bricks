public class SceneConfiguration3 : SceneConfiguration
{
    public ObjectGamePosition[] SetObjects()
    {
        _objectGamePositions = new[]
        {
            new ObjectGamePosition("enemies/UFO", 5, 5, 1), 
            
            new ObjectGamePosition("enemies/BrickFire", 1, 3, 2), 
            new ObjectGamePosition("enemies/BrickFire", 3, 3, 2),
            new ObjectGamePosition("enemies/BrickBombaSmall", 4, 3, 2), 
            new ObjectGamePosition("enemies/BrickBombaSmall", 7, 3, 2), 
            new ObjectGamePosition("enemies/BrickFire", 8, 3, 2), 
            new ObjectGamePosition("enemies/BrickFire", 10, 3, 2), 
            
            new ObjectGamePosition("enemies/BrickSkeleton", 1, 4, 1), 
            new ObjectGamePosition("enemies/BrickSkeleton", 2, 4, 1), 
            new ObjectGamePosition("enemies/BrickSkeleton", 4, 4, 1), 
            new ObjectGamePosition("enemies/BrickSkeleton", 5, 4, 1), 
            new ObjectGamePosition("enemies/BrickSkeleton", 6, 4, 1), 
            new ObjectGamePosition("enemies/BrickSkeleton", 7, 4, 1), 
            new ObjectGamePosition("enemies/BrickSkeleton", 9, 4, 1), 
            new ObjectGamePosition("enemies/BrickSkeleton", 10, 4, 1), 
            
            new ObjectGamePosition("enemies/BrickSkeleton", 2, 5, 1), 
            new ObjectGamePosition("enemies/BrickSkeleton", 9, 5, 1), 
            
            new ObjectGamePosition("enemies/BrickSkeleton", 2, 6, 1),
            new ObjectGamePosition("enemies/BrickSkeleton", 3, 6, 1),
            new ObjectGamePosition("enemies/BrickSkeleton", 4, 6, 1),
            new ObjectGamePosition("enemies/BrickSkeleton", 7, 6, 1),
            new ObjectGamePosition("enemies/BrickSkeleton", 8, 6, 1),
            new ObjectGamePosition("enemies/BrickSkeleton", 9, 6, 1),
            
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
        return _objectGamePositions;
    }
}