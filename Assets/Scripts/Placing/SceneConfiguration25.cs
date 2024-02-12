public class SceneConfiguration25 : SceneConfiguration
{
    public ObjectGamePosition[] SetObjects()
    {
        _objectGamePositions = new[]
        {
            new ObjectGamePosition("enemies/UFO", 5, 5, 1), 
            
            new ObjectGamePosition("enemies/BrickSquarePurple", 0, 1, 24),
            new ObjectGamePosition("enemies/BrickSkeleton", 1, 1, 24),
            new ObjectGamePosition("enemies/BrickBombaSmall", 2, 1, 4),
            new ObjectGamePosition("enemies/BrickSkeleton", 3, 1, 24),
            new ObjectGamePosition("enemies/BrickSquarePurple", 4, 1, 24),
            new ObjectGamePosition("enemies/BrickSkeleton", 5, 1, 24),
            new ObjectGamePosition("enemies/BrickSquarePurple", 6, 1, 24),
            new ObjectGamePosition("enemies/BrickSkeleton", 7, 1, 24),
            new ObjectGamePosition("enemies/BrickSquarePurple", 8, 1, 24),
            new ObjectGamePosition("enemies/BrickSkeleton", 9, 1, 24),
            new ObjectGamePosition("enemies/BrickSquarePurple", 10, 1, 24),
            new ObjectGamePosition("enemies/BrickSkeleton", 11, 1, 24),

            new ObjectGamePosition("enemies/BrickSquarePurple", 3, 2, 24),
            new ObjectGamePosition("enemies/BrickSimpleTriangle3", 10, 2, 24),
            new ObjectGamePosition("enemies/BrickSquarePurple", 11, 2, 24),

            new ObjectGamePosition("enemies/BrickSquarePurple", 1, 3, 24),
            new ObjectGamePosition("enemies/BrickBombaSmall", 2, 3, 24),
            new ObjectGamePosition("enemies/BrickSquarePurple", 3, 3, 24),
            new ObjectGamePosition("enemies/BrickSquarePurple", 4, 3, 24),
            new ObjectGamePosition("enemies/BrickSquarePurple", 5, 3, 24),
            new ObjectGamePosition("enemies/BrickBlue", 7, 3, 180),
            new ObjectGamePosition("enemies/BrickSquarePurple", 8, 3, 24),
            new ObjectGamePosition("enemies/BrickSimpleTriangle1", 9, 3, 24),
            new ObjectGamePosition("enemies/BrickFire", 11, 3, 8),

            new ObjectGamePosition("enemies/BrickSquarePurple", 1, 4, 24),
            new ObjectGamePosition("enemies/BrickSquarePurple", 7, 4, 24),
            new ObjectGamePosition("enemies/BrickBombaSmall", 8, 4, 24),
            new ObjectGamePosition("enemies/BrickBlue", 9, 4, 24),
            new ObjectGamePosition("enemies/BrickSquarePurple", 11, 4, 24),
                      
            new ObjectGamePosition("enemies/BrickSquarePurple", 1, 5, 24),
            new ObjectGamePosition("enemies/BrickSkeleton", 7, 5, 24),
            new ObjectGamePosition("enemies/BrickSquarePurple", 9, 5, 24),
            new ObjectGamePosition("enemies/BrickFire", 11, 5, 8),
            
            new ObjectGamePosition("enemies/BrickBoss3", 4, 6, 90),
            new ObjectGamePosition("enemies/BrickBlue", 9, 6, 24),
            new ObjectGamePosition("enemies/BrickSquarePurple", 11, 6, 24),

            new ObjectGamePosition("enemies/BrickSkeleton", 0, 7, 12),
            new ObjectGamePosition("enemies/BrickSkeleton", 1, 7, 12),
            new ObjectGamePosition("enemies/BrickBombaSmall", 2, 7, 12),
            new ObjectGamePosition("enemies/BrickBlue", 6, 7, 12),
            new ObjectGamePosition("enemies/BrickSquarePurple", 7, 7, 12),
            new ObjectGamePosition("enemies/BrickBlue", 8, 7, 12),
            new ObjectGamePosition("enemies/BrickSquarePurple", 9, 7, 12),
            new ObjectGamePosition("enemies/BrickFire", 11, 7, 8),

            new ObjectGamePosition("extras/Magic Ball Particle", 6, 2, 1),
            new ObjectGamePosition("extras/Magic Ball Particle", 10, 5, 1),

            new ObjectGamePosition("extras/Score Ball Particle", 0, 4, 1),
            new ObjectGamePosition("extras/Score Ball Particle", 4, 4, 1),
        };
        return _objectGamePositions;
    }
}