using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneConfigurationRR_1 : SceneConfiguration
{
    private string[] brickNames = { "enemies/BrickSquareBig", "enemies/BrickSquareBlue", "enemies/BrickSkeleton", "enemies/BrickSkeleton", "enemies/BrickSkeleton", "enemies/BrickSkeleton" ,
        "extras/Magic Ball Particle", "extras/Magic Ball Particle", "extras/Score Ball Particle", "extras/Score Ball Particle", "extras/Score Ball Particle",
        "enemies/BrickSquare" , "enemies/BrickSquareBlue", "enemies/BrickSquareBlue", "enemies/BrickSquareBlue", "enemies/BrickBombaSmall",
        "enemies/BrickSkeleton", "enemies/BrickSkeleton", "enemies/BrickSkeleton", "enemies/BrickSkeleton" ,
        "enemies/BrickSquarePurple" , "enemies/BrickBombaSmall" , "enemies/BrickAborigen",
        "enemies/BrickSimpleTriangle3", "enemies/BrickSkeleton", "enemies/BrickSkeleton",
    "enemies/BrickBlue", "enemies/BrickFire", "enemies/Brick3", "enemies/Brick3a" ,
        "enemies/Brick2", "enemies/BrickTriangle", "enemies/BrickBombaSmall", "extras/Magic Ball Particle", "extras/Magic Ball Particle", 
        "extras/Magic Ball Particle", "extras/Score Ball Particle", "extras/Score Ball Particle", "extras/Score Ball Particle"};

    void Awake()
    {
        _objectGamePositions = new[]
        {
            new ObjectGamePosition("enemies/UFO", 5, 5, 1), 
            
            new ObjectGamePosition(brickNames[Random.Range(0, 1)], Random.Range(2, 6), 4, 1500),
            

        };
    }

}