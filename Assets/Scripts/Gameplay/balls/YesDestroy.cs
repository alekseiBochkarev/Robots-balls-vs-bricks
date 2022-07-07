using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YesDestroy : MonoBehaviour, AfterCollisionBehaviour
{
    public void DestroyAfterCollision()
    {
        Debug.Log("destroy");
        //Destroy(this.gameObject, .00000005f);
        this.gameObject.GetComponent<AbstractBall>().Disable();
        Destroy(this.gameObject);
    }
}
