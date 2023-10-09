using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneConfigurationRR : SceneConfiguration
{
    private string[] brickNames = { "enemies/BrickSquareBlue", "enemies/BrickSkeleton", "enemies/BrickSkeleton", "enemies/BrickSkeleton", "enemies/BrickSkeleton" ,
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
            
            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(0, 1), 1, SceneManager.GetActiveScene().buildIndex * 10),
            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(2, 3), 1, SceneManager.GetActiveScene().buildIndex * 10),
            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(4, 5), 1, SceneManager.GetActiveScene().buildIndex * 10),
            
            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(0, 1), 2, SceneManager.GetActiveScene().buildIndex * 10),
            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(2, 3), 2, SceneManager.GetActiveScene().buildIndex * 10),
            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(4, 5), 2, SceneManager.GetActiveScene().buildIndex * 10),

            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(0, 1), 3, SceneManager.GetActiveScene().buildIndex * 10),
            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(2, 3), 3, SceneManager.GetActiveScene().buildIndex * 10),
            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(4, 5), 3, SceneManager.GetActiveScene().buildIndex * 10),
            
        };
    }

}