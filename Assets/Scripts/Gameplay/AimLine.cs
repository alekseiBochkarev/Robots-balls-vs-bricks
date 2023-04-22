using UnityEngine;
using System.Collections.Generic;
public class AimLine : MonoBehaviour
{
    private float partLength = 0.5f;
    private int numberOfParts = 10;
    public GameObject aimPartPrefab;
    private List<GameObject> parts;

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
            for (int i = 0; i < parts.Count; i ++)
            {
            parts[i].transform.SetParent(this.transform, true);
            Vector3 currentPosition = (endPosition - startPosition).normalized * partLength * (i + 1);
           /* if (currentPosition.x > GetComponent<BallLauncher>().rightBorder.transform.position.x)
            {
                currentPosition = Vector3.Reflect(currentPosition, new Vector3(1, 0, 0));
            }*/
            parts[i].transform.position = new Vector3((currentPosition.x + startPosition.x), (currentPosition.y + startPosition.y), currentPosition.z);
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
        for(int i = parts.Count - 1; i >= 0; i--)
        {
            Destroy(parts[i]);
            parts.RemoveAt(i); // о размере списка не заморачиваемся вообще
        }
        parts.Clear();
        parts = null;
    }
}