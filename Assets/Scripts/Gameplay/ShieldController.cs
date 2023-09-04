using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Gameplay;

public class ShieldController : MonoBehaviour
{
    private Vector3 brickCoord;
    private Vector3 brickCoordAbove;
    private Color damageTextColor;
    private int damageTextFontSize;
    private ParticleSystem m_ParentParticle;

    private void Awake()
    {
        m_ParentParticle = GetComponentInParent<ParticleSystem>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<IBall>() != null)
        {
            InitBrickDamagePopupPosition();
            string textPopupTextValue = Translator.Translate("Block");
            // polygonCollider2D.isTrigger = false;
            damageTextColor = collision.gameObject.GetComponent<IBall>().GetDamageTextColor;
            damageTextFontSize = collision.gameObject.GetComponent<IBall>().GetDamageTextFontSize;
            //TakeDamage(appliedDamage, damageTextColor, damageTextFontSize);
            DamagePopupController.Instance
        .CreateTextPopup(brickCoordAbove, textPopupTextValue, damageTextColor, damageTextFontSize);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<IBall>() != null)
        {
            InitBrickDamagePopupPosition();
            string textPopupTextValue = Translator.Translate("Block");
            // polygonCollider2D.isTrigger = false;
            damageTextColor = collider.gameObject.GetComponent<IBall>().GetDamageTextColor;
            damageTextFontSize = collider.gameObject.GetComponent<IBall>().GetDamageTextFontSize;
            //TakeDamage(appliedDamage, damageTextColor, damageTextFontSize);
            DamagePopupController.Instance
        .CreateTextPopup(brickCoordAbove, textPopupTextValue, damageTextColor, damageTextFontSize);
            Destroy(gameObject);
        }
    }

    private void InitBrickDamagePopupPosition() // init brickPosition and change Y to show damagePopup above the BRICK
    {
        float damagePopupHeight = .5f;
        brickCoord = m_ParentParticle.transform.position;
        brickCoordAbove = new Vector3(brickCoord.x, brickCoord.y + damagePopupHeight, brickCoord.z);
    }
}
