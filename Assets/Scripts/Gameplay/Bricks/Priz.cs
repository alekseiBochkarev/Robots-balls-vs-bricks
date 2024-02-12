using Assets.Scripts.Gameplay;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Gameplay.Loot;

public class Priz : MoveDownBehaviour
{
    public Hero hero;

    // public PolygonCollider2D polygonCollider2D;
    private Rigidbody2D rigidbody2D;
    
    public SpriteRenderer m_SpriteRenderer;
    public ParticleSystem m_ParentParticle;
    public Vector3 brickCoord;
    public Vector3 brickCoordAbove;
    private int attackSkill = 10; // need to define what's the best value for start
    public int appliedDamage;
    public Color damageTextColor;
    public int damageTextFontSize;
    public GameObject parent;
    public GameObject bulletOnlyForRangeAttackedBricks;
    public Animator animator;
    
    public LootBag lootBag;


    public IStateBrick state;

    private void Awake()
    {
        InitMoveDown();
        parent = transform.parent.gameObject;
     //   polygonCollider2D = gameObject.GetComponent<PolygonCollider2D>();
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_ParentParticle = GetComponentInParent<ParticleSystem>();
        hero = GameObject.FindGameObjectWithTag("Hero").GetComponent<Hero>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        
    }
    
    public void ChangeRigidbodyType(RigidbodyType2D rigidbodyType)
    {
        rigidbody2D.bodyType = rigidbodyType;
    }

    /// <summary>
    /// похоже это лишний метд Аттака (так как есть ДуДемедж), хотя я наверно просто могу в нем вызывать дуДемедж
    /// </summary>
    /// <returns></returns>

    public override IEnumerator MoveToTarget(Vector3 startPos, Vector3 endPos, int currentY, int maxY)
    {
        if (currentY + 1 == (maxY - 1))
        {
            Destroy(parent);
        }
        Debug.Log("currentY " + currentY + " maxY " + maxY);
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