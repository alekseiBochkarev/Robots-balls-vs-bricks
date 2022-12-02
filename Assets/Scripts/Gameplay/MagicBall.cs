using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MoveDownBehaviour

{
    private ParticleSystem m_ParentParticle;
    private GameObject parent;
    private SpecialAttackPanelController m_SpecialAttackPanelController;

    private Color m_ParticleColor;

    private void Awake()
    {
        InitMoveDown();
        
        parent = transform.parent.gameObject;
        m_ParentParticle = GetComponentInParent<ParticleSystem>();

        m_ParticleColor = new Color(0, 1, 0, 0.5f);

        m_SpecialAttackPanelController = GameObject.Find("SpecialAttackUI").GetComponent<SpecialAttackPanelController>();
    }

    private void OnEnable() {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<AbstractBall>() != null)
        {
            m_SpecialAttackPanelController.SetMagicBallAmount(1);
            PlayParticle();
            EventManager.OnBrickDestroyed();
            Destroy(parent, 1);
        } else if (collision.gameObject.tag == "Finish") 
        {
            SuicideMagicBall();
        }
    }

    private void SuicideMagicBall () {
        m_SpecialAttackPanelController.SetMagicBallAmount(1);    // increase balls amount
        PlayParticle();
        //parent.GetComponentInParent<MoveDownBehaviour>().UpdateCurrentPosition();
        //parent.GetComponentInParent<MoveDownBehaviour>().SetZeroToCurrentPosition();
        EventManager.OnBrickDestroyed();
        Destroy(parent, 0.1f);
    }

    private void PlayParticle()
    {
        gameObject.SetActive(false);

        m_ParentParticle.startColor = m_ParticleColor;
        m_ParentParticle.Play();
    }
}
