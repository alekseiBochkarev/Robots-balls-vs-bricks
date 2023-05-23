using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Gameplay;

public class IdleStateBrick : IStateBrick 
{
    Brick brick;
    public IdleStateBrick(Brick brick) {
        this.brick = brick;
        
    }

    public void Enter() {
        //Debug.Log("Enter Idle behaviour");
        //brick.animator.SetBool("walk", false);
    }

    public void Exit() {
        //Debug.Log("Exit Idle behaviour");
    }

    public void DoDamage(int applyDamage) {
        brick.SetState(brick.attackStateBrick);
        brick.DoDamage(applyDamage);
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
        brick.SetState(brick.takeDamageStateBrick);
        brick.TakeDamage(appliedDamage);
        brick.SetState(this);
    }

    public void TakeDamage(int appliedDamage, Color damageTextColor, int damageTextFontSize) {
        brick.SetState(brick.takeDamageStateBrick);
        brick.TakeDamage(appliedDamage, damageTextColor, damageTextFontSize);
        brick.SetState(this);
    }
    
    public void TakeDamage(int appliedDamage, string textPopupTextValue, Color textColor, int textFontSize) {
        brick.SetState(brick.takeDamageStateBrick);
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
    
    public IEnumerator MoveToTarget(Vector3 startPos, Vector3 endPos) {
        brick.SetState(brick.walkStateBrick);
        yield return brick.MoveToTarget(startPos, endPos);
        brick.SetState(this);
        yield break;
    }

}
