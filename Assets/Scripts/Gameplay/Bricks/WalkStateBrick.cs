using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Gameplay;

public class WalkStateBrick : IStateBrick
{
    Brick brick;

    public WalkStateBrick(Brick brick)
    {
        this.brick = brick;
    }

    public void Enter()
    {
        brick.animator.Play("walk");
    }

    public void Exit()
    {
    }

    public IEnumerator DoDamage(int applyDamage)
    {
        Debug.Log("do Attack ");
        brick.SetState(brick.attackStateBrick);
        yield return brick.DoDamage(applyDamage);
    }

    public void HealUp(float healHealthUpAmount) // heals Health of the BRICK
    {
        InitBrickDamagePopupPosition();
        bool isCriticalHit = false;
        bool isDamage = false;
        brick.damageTextColor = TextController.COLOR_RED;
        brick.damageTextFontSize = TextController.FONT_SIZE_MAX;
        int healHealthUpAmountInt = (int)healHealthUpAmount;
        brick.MCurrentBrickHealth += healHealthUpAmountInt;
        brick.healthBar.SaveCurrentBrickHealth();
        brick.healthBar.ShowHealth();


        DamagePopupController.Instance.CreateDamagePopup(brick.brickCoord, healHealthUpAmountInt, isCriticalHit,
            isDamage, brick.damageTextColor, brick.damageTextFontSize);
    }

    private void InitBrickDamagePopupPosition() // init brickPosition and change Y to show damagePopup above the BRICK
    {
        float damagePopupHeight = .5f;
        brick.brickCoord = brick.m_ParentParticle.transform.position;
        brick.brickCoordAbove =
            new Vector3(brick.brickCoord.x, brick.brickCoord.y + damagePopupHeight, brick.brickCoord.z);
    }

    public void TakeDamage(int appliedDamage)
    {
    }

    public void TakeDamage(int appliedDamage, Color damageTextColor, int damageTextFontSize)
    {
    }

    public void TakeDamage(int appliedDamage, string textPopupTextValue, Color textColor, int textFontSize)
    {
    }

    public void DeathOfBrick(bool isInstantiateLoot)
    {
        brick.SetState(brick.deathStateBrick);
        brick.DeathOfBrick(isInstantiateLoot);
    }

    public void Suicide()
    {
        //  brick.SetState(brick.deathStateBrick);
        //  brick.Suicide();
    }

    public void KillBrick(string textPopupTextValue)
    {
    }

    public void ChangeRigidbodyType(RigidbodyType2D rigidbodyType)
    {
    } //hmmm its a quastion

    public void Attack()
    {
    }

    public void ChangeColor()
    {
    } //hmm its a quastion

    public IEnumerator MoveToTarget(Vector3 startPos, Vector3 endPos, int currentY, int maxY)
    {
        //Debug.Log("currentY " + currentY + " maxY " + maxY);
        if (currentY + 1 == (maxY-1))
        {
            Debug.Log("set state IsWaitMeleeAttack");
            brick.IsWaitMeleeAttack = true;
        }
        brick.isMovingNow = true;
        float speed = 0.1f; //  скорость прогресса (от начальной до конечной позиции)
        float progress = 0;
        while (true)
        {
            progress += speed;
            brick.transform.parent.position = Vector3.Lerp(startPos, endPos, progress);
            if (progress >= 1)
            {
                brick.isMovingNow = false;
                yield break; // выход из корутины, если находимся в конечной позиции
            }

            yield return
                null; // если выхода из корутины не произошло, то продолжаем выполнять цикл while в следующем кадре
        }
    }
}