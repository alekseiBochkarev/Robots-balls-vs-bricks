﻿using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneConfiguration77 : SceneConfiguration
{
    public ObjectGamePosition[] SetObjects()
    {
        _objectGamePositions = new[]
        {
            new ObjectGamePosition("enemies/UFO", 5, 5, SceneManager.GetActiveScene().buildIndex), 
            
            new ObjectGamePosition("enemies/BrickPrizSkin26", 5,5,SceneManager.GetActiveScene().buildIndex),
            
            new ObjectGamePosition("enemies/BrickBombaSmall", 3, 2, SceneManager.GetActiveScene().buildIndex), 
            new ObjectGamePosition("enemies/BrickSquarePurple", 4, 2, SceneManager.GetActiveScene().buildIndex),
            new ObjectGamePosition("enemies/BrickSquarePurple", 5, 2, SceneManager.GetActiveScene().buildIndex),
            new ObjectGamePosition("enemies/BrickSquarePurple", 6, 2, SceneManager.GetActiveScene().buildIndex),
            new ObjectGamePosition("enemies/BrickSquarePurple", 7, 2, SceneManager.GetActiveScene().buildIndex),
            
            new ObjectGamePosition("enemies/BrickSquarePurple", 3, 3, SceneManager.GetActiveScene().buildIndex), 
            new ObjectGamePosition("enemies/BrickSquarePurple", 4, 3, SceneManager.GetActiveScene().buildIndex), 
            new ObjectGamePosition("enemies/BrickBombaSmall", 5, 3, SceneManager.GetActiveScene().buildIndex), 
            new ObjectGamePosition("enemies/BrickSquarePurple", 6, 3, SceneManager.GetActiveScene().buildIndex), 
            new ObjectGamePosition("enemies/BrickSquarePurple", 7, 3, SceneManager.GetActiveScene().buildIndex), 
            
            new ObjectGamePosition("enemies/BrickSquarePurple", 3, 4, SceneManager.GetActiveScene().buildIndex), 
            new ObjectGamePosition("enemies/BrickSquareBlue", 4, 4, SceneManager.GetActiveScene().buildIndex), 
            new ObjectGamePosition("enemies/BrickSquareBlue", 5, 4, SceneManager.GetActiveScene().buildIndex), 
            new ObjectGamePosition("enemies/BrickSquarePurple", 6, 4, SceneManager.GetActiveScene().buildIndex), 
            new ObjectGamePosition("enemies/BrickBombaSmall", 7, 4, SceneManager.GetActiveScene().buildIndex), 
            
            new ObjectGamePosition("enemies/BrickSquareBlue", 3, 5, SceneManager.GetActiveScene().buildIndex), 
            new ObjectGamePosition("enemies/BrickSquareBlue", 4, 5, SceneManager.GetActiveScene().buildIndex), 
            new ObjectGamePosition("enemies/BrickSquarePurple", 6, 5, SceneManager.GetActiveScene().buildIndex), 
            new ObjectGamePosition("enemies/BrickSquarePurple", 7, 5, SceneManager.GetActiveScene().buildIndex), 
            
            new ObjectGamePosition("enemies/BrickBombaSmall", 3, 6, SceneManager.GetActiveScene().buildIndex), 
            new ObjectGamePosition("enemies/BrickSquareBlue", 4, 6, SceneManager.GetActiveScene().buildIndex), 
            new ObjectGamePosition("enemies/BrickSquarePurple", 5, 6, SceneManager.GetActiveScene().buildIndex), 
            new ObjectGamePosition("enemies/BrickSquareBlue", 6, 6, SceneManager.GetActiveScene().buildIndex), 
            new ObjectGamePosition("enemies/BrickSquareBlue", 7, 6, SceneManager.GetActiveScene().buildIndex), 
            
            new ObjectGamePosition("enemies/BrickSquareBlue", 3, 7, SceneManager.GetActiveScene().buildIndex), 
            new ObjectGamePosition("enemies/BrickSquareBlue", 4, 7, SceneManager.GetActiveScene().buildIndex), 
            new ObjectGamePosition("enemies/BrickBombaSmall", 5, 7, SceneManager.GetActiveScene().buildIndex), 
            new ObjectGamePosition("enemies/BrickSquareBlue", 6, 7, SceneManager.GetActiveScene().buildIndex), 
            new ObjectGamePosition("enemies/BrickSquareBlue", 7, 7, SceneManager.GetActiveScene().buildIndex), 
            
            new ObjectGamePosition("enemies/BrickSquareBlue", 3, 8, SceneManager.GetActiveScene().buildIndex), 
            new ObjectGamePosition("enemies/BrickSquareBlue", 4, 8, SceneManager.GetActiveScene().buildIndex), 
            new ObjectGamePosition("enemies/BrickSquarePurple", 5, 8, SceneManager.GetActiveScene().buildIndex), 
            new ObjectGamePosition("enemies/BrickBombaSmall", 6, 8, SceneManager.GetActiveScene().buildIndex), 
            new ObjectGamePosition("enemies/BrickSquareBlue", 7, 8, SceneManager.GetActiveScene().buildIndex), 
			
        };
        return _objectGamePositions;
    }
}