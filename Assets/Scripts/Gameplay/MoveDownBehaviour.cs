using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDownBehaviour : MonoBehaviour
{
    public void MoveDown(float howMuch)
    {
        iTween.MoveTo(gameObject, new Vector3(transform.position.x, transform.position.y - howMuch, transform.position.z), 0.25f);
    }
}
