using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Gameplay;

public class FreezeStateBrick : IStateBrick
{
    Brick brick;
    private int countOfFreezeStep;
    private int maxCountOfFreezeStep = 1;
    public FreezeStateBrick(Brick brick) {
        this.brick = brick;
    }

    public void Enter() {
        brick.ice.SetActive(true);
    }

    public void Exit() {
        brick.ice.SetActive(false);
    }

    public void DoDamage(int applyDamage) {
       
    }

    public void HealUp(float healHealthUpAmount) // heals Health of the BRICK
    {
        InitBrickDamagePopupPosition();
        bool isCriticalHit = false;
        bool isDamage = false;
        brick.damageTextColor = TextController.COLOR_RED;
        brick.damageTextFontSize = TextController.FONT_SIZE_MAX;
        int healHealthUpAmountInt = (int) healHealthUpAmount;
        brick.MCurrentBrickHealth += healHealthUpAmountInt;
        brick.healthBar.SaveCurrentBrickHealth();
        brick.healthBar.ShowHealth();

        DamagePopupController.Instance.CreateDamagePopup(brick.brickCoord, healHealthUpAmountInt, isCriticalHit, isDamage, brick.damageTextColor, brick.damageTextFontSize);
    }

     private void InitBrickDamagePopupPosition() // init brickPosition and change Y to show damagePopup above the BRICK
    {
        float damagePopupHeight = .5f;
        brick.brickCoord = brick.m_ParentParticle.transform.position;
        brick.brickCoordAbove = new Vector3(brick.brickCoord.x, brick.brickCoord.y + damagePopupHeight, brick.brickCoord.z);
    }

    public void TakeDamage (int appliedDamage) {
        brick.SetStateWithoutExit(brick.takeDamageStateBrick);
        brick.TakeDamage(appliedDamage);
        brick.SetState(this);
    }

    public void TakeDamage(int appliedDamage, Color damageTextColor, int damageTextFontSize) {
        brick.SetStateWithoutExit(brick.takeDamageStateBrick);
        brick.TakeDamage(appliedDamage, damageTextColor, damageTextFontSize);
        brick.SetState(this);
    }
    
    public void TakeDamage(int appliedDamage, string textPopupTextValue, Color textColor, int textFontSize) {
        brick.SetStateWithoutExit(brick.takeDamageStateBrick);
        brick.TakeDamage(appliedDamage, textPopupTextValue, textColor, textFontSize);
        brick.SetState(this);
    }

    public void DeathOfBrick () {
        brick.SetState(brick.deathStateBrick);
        brick.DeathOfBrick();
    }

    public void Suicide () {
        brick.SetState(brick.deathStateBrick);
        brick.Suicide();
    }

    public void KillBrick(string textPopupTextValue) {
        brick.SetState(brick.takeDamageStateBrick);
        brick.KillBrick(textPopupTextValue);
    }
    public void ChangeRigidbodyType (RigidbodyType2D rigidbodyType) {} //hmmm its a quastion
    public void Attack () {}
    public void ChangeColor() {} //hmm its a quastion
    
    public IEnumerator MoveToTarget(Vector3 startPos, Vector3 endPos)
    {
        countOfFreezeStep++;
        if (countOfFreezeStep > maxCountOfFreezeStep)
        {
            countOfFreezeStep = 0;
            brick.SetState(brick.walkStateBrick);
            yield return brick.MoveToTarget(startPos, endPos);
            brick.SetState(brick.idleStateBrick);
        }
    }
}
