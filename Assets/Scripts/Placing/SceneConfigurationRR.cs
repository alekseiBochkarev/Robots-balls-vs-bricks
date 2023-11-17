using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneConfigurationRR : SceneConfiguration
{
    private string[] brickNames = { "enemies/BrickSkeleton", "enemies/BrickSquare", "enemies/BrickSkeleton", "enemies/BrickSkeleton", "enemies/BrickSquareBlue", "enemies/BrickSkeleton",
        "extras/Magic Ball Particle", "extras/Magic Ball Particle", "extras/Score Ball Particle", "extras/Score Ball Particle", "extras/Score Ball Particle",
        "enemies/BrickBombaSmall", "enemies/BrickSquare", "enemies/BrickSquare", "enemies/BrickSquare",
        "enemies/BrickSkeleton", "enemies/BrickSkeleton", "enemies/BrickSquare", "enemies/BrickSkeleton", "enemies/BrickSkeleton" ,
        "enemies/BrickBombaSmall" , "enemies/BrickAborigen", "enemies/BrickSquare", "enemies/BrickSquareBlue", "enemies/BrickSquareBlue",
         "enemies/BrickSkeleton", "enemies/BrickSkeleton", "enemies/BrickSquare",
     "enemies/BrickFire", 
        "enemies/BrickBombaSmall", "extras/Magic Ball Particle", "enemies/BrickSquare", "extras/Magic Ball Particle", "enemies/BrickSquareBlue", "enemies/BrickSquareBlue",
        "extras/Magic Ball Particle", "extras/Score Ball Particle", "extras/Score Ball Particle", "enemies/BrickSquareBlue", "extras/Score Ball Particle"};

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