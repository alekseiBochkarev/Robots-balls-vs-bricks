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

    public ObjectGamePosition[] SetObjects()
    {
        _objectGamePositions = new[]
        {
            new ObjectGamePosition("enemies/UFO", 5, 5, 1), 
            
            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(0, 3), 1, SceneManager.GetActiveScene().buildIndex),
            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(4, 6), 1, SceneManager.GetActiveScene().buildIndex),
            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(7, 9), 1, SceneManager.GetActiveScene().buildIndex),
            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(10, 11), 1, SceneManager.GetActiveScene().buildIndex),

            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(0, 3), 2, SceneManager.GetActiveScene().buildIndex),
            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(4, 6), 2, SceneManager.GetActiveScene().buildIndex),
            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(7, 9), 2, SceneManager.GetActiveScene().buildIndex),
            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(10, 11), 2, SceneManager.GetActiveScene().buildIndex),

            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(0, 3), 3, SceneManager.GetActiveScene().buildIndex),
            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(4, 6), 3, SceneManager.GetActiveScene().buildIndex),
            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(7, 11), 3, SceneManager.GetActiveScene().buildIndex),

            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(0, 3), 4, SceneManager.GetActiveScene().buildIndex),
            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(4, 6), 4, SceneManager.GetActiveScene().buildIndex),
            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(7, 9), 4, SceneManager.GetActiveScene().buildIndex),
            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(10, 11), 4, SceneManager.GetActiveScene().buildIndex),

            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(0, 3), 5, SceneManager.GetActiveScene().buildIndex),
            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(4, 6), 5, SceneManager.GetActiveScene().buildIndex),
            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(7, 11), 5, SceneManager.GetActiveScene().buildIndex),

            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(0, 3), 6, SceneManager.GetActiveScene().buildIndex),
            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(4, 6), 6, SceneManager.GetActiveScene().buildIndex),
            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(7, 9), 6, SceneManager.GetActiveScene().buildIndex),
            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(10, 11), 6, SceneManager.GetActiveScene().buildIndex),

            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(0, 3), 7, SceneManager.GetActiveScene().buildIndex),
            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(4, 6), 7, SceneManager.GetActiveScene().buildIndex),
            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(7, 9), 7, SceneManager.GetActiveScene().buildIndex),
            new ObjectGamePosition(brickNames[Random.Range(0, brickNames.Length)], Random.Range(10, 11), 7, SceneManager.GetActiveScene().buildIndex),
        };
        return _objectGamePositions;
    }

}