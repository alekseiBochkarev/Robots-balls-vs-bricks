using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDestroy : MonoBehaviour, AfterCollisionBehaviour
{
    public void DestroyAfterCollision()
    {
        Debug.Log("no destroy");
    }
}
