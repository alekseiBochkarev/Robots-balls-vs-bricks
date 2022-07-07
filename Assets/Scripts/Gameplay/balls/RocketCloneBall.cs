using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCloneBall : AbstractBall
{
    public RocketCloneBall()
    {
        attackBehaviour = new NoAttack();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Brick>() != null)
            Destroy(gameObject, .5f);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Brick>() != null)
            Destroy(gameObject, .5f);
    }
}
