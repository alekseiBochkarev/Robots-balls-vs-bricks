using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Gameplay;

public class TakeDamageStateBrick : IStateBrick
{
    Brick brick;
    public TakeDamageStateBrick(Brick brick) {
        this.brick = brick;
    }

    public void Enter() {
        
    }

    public void Exit() {
        
    }

    public IEnumerator DoDamage(int applyDamage)
    {
        return null;
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
        TakeDamage(appliedDamage, brick.damageTextColor, brick.damageTextFontSize);
    }

    public void TakeDamage(int appliedDamage, Color damageTextColor, int damageTextFontSize) {
        BeHitGeneral(appliedDamage);
        bool isDamage = true;
        bool isCriticalHit = false;
        DamagePopupController.Instance
        .CreateDamagePopup(brick.brickCoord, appliedDamage, isCriticalHit, isDamage, damageTextColor, damageTextFontSize);

        if (brick.MCurrentBrickHealth <= 0)
        {
            brick.DeathOfBrick(true);
        }
    }
    
    public void TakeDamage(int appliedDamage, string textPopupTextValue, Color textColor, int textFontSize)
    {
        BeHitGeneral(appliedDamage);
        DamagePopupController.Instance
        .CreateTextPopup(brick.brickCoordAbove, textPopupTextValue, textColor, textFontSize);

        if (brick.MCurrentBrickHealth <= 0)
        {
            brick.DeathOfBrick(true);
        }
    }

    private void BeHitGeneral(int appliedDamage)
    {
        brick.animator.Play("takeDamage");
        brick.MCurrentBrickHealth -= appliedDamage;
        brick.m_Text.text = brick.MCurrentBrickHealth.ToString();
        brick.healthBar.SaveCurrentBrickHealth();
        brick.healthBar.ShowHealth();

        // Create DamagePopup with damage above the BRICK
        InitBrickDamagePopupPosition();
    }

    public void DeathOfBrick (bool isInstantiateLoot) {
        brick.SetState(brick.deathStateBrick);
        brick.DeathOfBrick(isInstantiateLoot);
    }

    public void Suicide () {
        brick.SetState(brick.deathStateBrick);
        brick.Suicide();
    }

    public void KillBrick(string textPopupTextValue) {
        brick.appliedDamage = brick.MMaxBrickHealth;
        brick.damageTextColor = TextController.COLOR_BLACK;
        brick.damageTextFontSize = TextController.FONT_SIZE_MAX;
        TakeDamage(brick.appliedDamage, textPopupTextValue, brick.damageTextColor, brick.damageTextFontSize);
    }

    public void ChangeRigidbodyType (RigidbodyType2D rigidbodyType) {} //hmmm its a quastion
    public void Attack () {}
    public void ChangeColor() {} //hmm its a quastion
    
    public IEnumerator MoveToTarget(Vector3 startPos, Vector3 endPos, int currentY, int maxY) {
        yield break;
    }
}
