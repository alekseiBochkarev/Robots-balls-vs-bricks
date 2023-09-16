using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MoveDownBehaviour

{
    private ParticleSystem m_ParentParticle;
    private GameObject parent;
    private SpecialAttackPanelController m_SpecialAttackPanelController;
    [SerializeField] private AudioClip clip;
    private GameObject camera;
    private Color m_ParticleColor;
    //ожидание последнего хода
    private bool isWaitMeleeAttack;

    public bool IsWaitMeleeAttack
    {
        get => isWaitMeleeAttack;
        set => isWaitMeleeAttack = value;
    }

    private void Awake()
    {
        InitMoveDown();
        camera = GameObject.Find("MainCamera");
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
            camera.GetComponent<AudioManager>().PlayAudio(clip);
            Destroy(parent, 1);
        } else if (collision.gameObject.tag == "Finish")   //кажется это не используем, переделали в переопределенный MoveToTarget
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

    public override IEnumerator MoveToTarget(Vector3 startPos, Vector3 endPos, int currentY, int maxY)
    {
        if (IsWaitMeleeAttack)
        {
            SuicideMagicBall();
        }

        if (currentY + 1 == (maxY - 1))
        {
            Debug.Log("set state IsWaitMeleeAttack");
            IsWaitMeleeAttack = true;
        }
        isMovingNow = true;
        float speed = 0.1f; //  скорость прогресса (от начальной до конечной позиции)
        float progress = 0;
        while (true)
        {
            progress += speed;
            transform.parent.position = Vector3.Lerp(startPos, endPos, progress);
            if (progress >= 1)
            {
                isMovingNow = false;
                yield break; // выход из корутины, если находимся в конечной позиции
            }

            yield return
                null; // если выхода из корутины не произошло, то продолжаем выполнять цикл while в следующем кадре
        }
    }
}
