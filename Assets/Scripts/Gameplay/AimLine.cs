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
                if ((currentPosition.x + startPosition.x) > rightBorderX)
                {
                    currentPosition =
                        new Vector3(
                            rightBorderX - ((currentPosition.x + startPosition.x) - rightBorderX), currentPosition.y,
                            currentPosition.z);
                    parts[i].transform.position = new Vector3((currentPosition.x), currentPosition.y + startPosition.y,
                        currentPosition.z + startPosition.z);
                }
                else if (currentPosition.x + startPosition.x < leftBorderX)
                {
                    currentPosition = new Vector3(leftBorderX - ((currentPosition.x + startPosition.x) - leftBorderX),
                        currentPosition.y, currentPosition.z);
                    parts[i].transform.position = new Vector3((currentPosition.x), currentPosition.y + startPosition.y,
                        currentPosition.z + startPosition.z);
                }
                else if (currentPosition.y + startPosition.y > topBorderY)
                {
                    currentPosition = new Vector3(currentPosition.x,
                        topBorderY - ((currentPosition.y + startPosition.y) - topBorderY),
                        currentPosition.z);
                    parts[i].transform.position = new Vector3((currentPosition.x + startPosition.x), currentPosition.y,
                        currentPosition.z + startPosition.z);
                }
                else
                {
                    parts[i].transform.position = new Vector3((currentPosition.x + startPosition.x),
                        currentPosition.y + startPosition.y, currentPosition.z + startPosition.z);
                }
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