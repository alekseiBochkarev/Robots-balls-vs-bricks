using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.DataManaging.Utills
{
    public class Utills
    {
        public static Vector3 WorldPosition;

        public static Vector3 RandomVectors;

        public static void SaveMouseWorldPosition()
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane + 10; // + 10 because camera on -10, while all objects on z equals 0
            WorldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        }

        public static Vector3 GetMouseWorldPosition()
        {
            return WorldPosition;
        }

        public static void InitRandomCoordInRange(float x, float y)
        {
            RandomVectors = new Vector3(Random.Range(-x, x), Random.Range(-y, y));
        }

        public static Vector3 GetRandomVector(float x, float y)
        {
            InitRandomCoordInRange(x, y);
            return RandomVectors;
        }

        public void Shuffle<T>(List<T> inputList)
        {
            for (int i = 0; i < inputList.Count - 1; i++)
            {
                T temp = inputList[i];
                int rand = Random.Range(i, inputList.Count);
                inputList[i] = inputList[rand];
                inputList[rand] = temp;
            }
        }
    }
}