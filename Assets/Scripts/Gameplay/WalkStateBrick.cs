using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Gameplay;

public class WalkStateBrick : IStateBrick
{
    Brick brick;
    public WalkStateBrick(Brick brick) {
        this.brick = brick;
    }

    public void Enter() {
        //Debug.Log("Enter Walk behaviour");
        brick.animator.SetBool("walk", true);
    }

    public void Exit() {
        //Debug.Log("Exit Walk behaviour");
    }

    public void DoDamage(int applyDamage) {
        brick.animator.SetBool("attack", true);
        brick.hero.TakeDamage(applyDamage);
    }

    public void HealUp(float healHealthUpAmount) // heals Health of the BRICK
    {
        InitBrickDamagePopupPosition();
        bool isCriticalHit = false;
        bool isDamage = false;
        brick.damageTextColor = TextController.COLOR_RED;
        brick.damageTextFontSize = TextController.FONT_SIZE_MAX;
        int healHealthUpAmountInt = (int) healHealthUpAmount;
        brick.m_currentBrickHealth += healHealthUpAmountInt;
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

    public void TakeDamage (int appliedDamage) {}
    public void TakeDamage(int appliedDamage, Color damageTextColor, int damageTextFontSize) {}
    public void TakeDamage(int appliedDamage, string textPopupTextValue, Color textColor, int textFontSize) {}
    public void DeathOfBrick () {}
    public void Suicide () {}
    public void KillBrick(string textPopupTextValue) {}
    public void ChangeRigidbodyType (RigidbodyType2D rigidbodyType) {} //hmmm its a quastion
    public void Attack () {}
    public void ChangeColor() {} //hmm its a quastion
    public IEnumerator MoveToTarget(Vector3 startPos, Vector3 endPos) {
        yield break; 
    }
}
