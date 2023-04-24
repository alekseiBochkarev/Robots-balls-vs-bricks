using System.Collections.Generic;
using UnityEngine;

public class AimLine : MonoBehaviour
{
    public static AimLine Instance;

    [SerializeField] private int numberOfParts;
    private float partLength = 0.3f;
    public GameObject aimPartPrefab;
    private List<GameObject> parts;
    private HeroStats _heroStats;

    private float rightBorderX;
    private float leftBorderX;
    private float topBorderY;

    private void Awake()
    {
        rightBorderX = GetComponent<BallLauncher>().rightBorder.transform.position.x;
        leftBorderX = GetComponent<BallLauncher>().leftBorder.transform.position.x;
        topBorderY = GetComponent<BallLauncher>().topBorder.transform.position.y;

        Instance = this;
    }

    private void Start()
    {
        _heroStats = new HeroStats();
        numberOfParts = (int)_heroStats.SightLength;
    }

    public void ChangePartLength(int sightLength)
    {
        numberOfParts = sightLength;
    }


    private void CreateDraw()
    {
        parts = new List<GameObject>();
        for (int i = 0; i < numberOfParts; i++)
        {
            GameObject part = Instantiate(aimPartPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            parts.Add(part);
        }
    }

    public void AimLineDraw(Vector3 startPosition, Vector3 endPosition)
    {
        if (parts != null)
        {
            for (int i = 0; i < parts.Count; i++)
            {
                parts[i].transform.SetParent(this.transform, true);
                Vector3 currentPosition = (endPosition - startPosition).normalized * partLength * (i + 1);
				float positionX = currentPosition.x + startPosition.x;
				float positionY = currentPosition.y + startPosition.y;
                if ((currentPosition.x + startPosition.x) > rightBorderX)
                {
                    positionX = rightBorderX - ((currentPosition.x + startPosition.x) - rightBorderX);
                }
                if ((currentPosition.x + startPosition.x) < leftBorderX)
                {
                    positionX = leftBorderX - ((currentPosition.x + startPosition.x) - leftBorderX);
                }
                if ((currentPosition.y + startPosition.y) > topBorderY)
                {
                    positionY = topBorderY - ((currentPosition.y + startPosition.y) - topBorderY);
                }
                parts[i].transform.position = new Vector3(positionX, positionY, currentPosition.z + startPosition.z);
            }
        }
        else
        {
            CreateDraw();
            AimLineDraw(startPosition, endPosition);
        }
    }

    public void RemoveDraw()
    {
        for (int i = parts.Count - 1; i >= 0; i--)
        {
            Destroy(parts[i]);
            parts.RemoveAt(i); // о размере списка не заморачиваемся вообще
        }

        parts.Clear();
        parts = null;
    }
}