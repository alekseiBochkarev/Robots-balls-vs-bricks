using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Assets.Scripts.Gameplay;

public class AttackStateBrick : MonoBehaviour, IStateBrick
{
    Brick brick;
    public AttackStateBrick(Brick brick) {
        this.brick = brick;
    }

    public void Enter() {
        
    }

    public void Exit() {
    }

    public IEnumerator DoDamage(int applyDamage)
    {
        if (brick.CanDoctor)
        {
            int healupPower = 2;
            HealUp(healupPower);
        }

        if (brick.IsWaitMeleeAttack)
        {
           /* iTween.MoveTo(brick.parent,
                iTween.Hash("position", new Vector3(brick.hero.transform.position.x, brick.hero.transform.position.y, brick.hero.transform.position.z),
                    "easetype", iTween.EaseType.linear, "time", (Vector2.Distance(this.brick.transform.position, brick.hero.transform.position))/10));*/
            brick.animator.Play("attack");
            brick.hero.TakeDamage(applyDamage); // later remove it
            yield return new WaitForSeconds(0.1f);
            brick.SetState(brick.idleStateBrick);
            brick.DeathOfBrick(false);
            yield break;
        }

        if (brick.CanRangeAttack)
        {
            brick.animator.Play("attack");
            var bullet = Instantiate(brick.bulletOnlyForRangeAttackedBricks, this.brick.transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().AttackPower = (applyDamage/2);
            yield return new WaitForSeconds(0.1f);
            brick.SetState(brick.idleStateBrick);
            yield break;
        }

        brick.SetState(brick.idleStateBrick);
        yield break;
    }

    public void HealUp(float healHealthUpAmount) // heals Health of the BRICK
    {
        InitBrickDamagePopupPosition();
        bool isCriticalHit = false;
        bool isDamage = false;
        brick.damageTextColor = TextController.COLOR_GREEN;
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
        
    }

    public void TakeDamage(int appliedDamage, Color damageTextColor, int damageTextFontSize) {
        
    }
    
    public void TakeDamage(int appliedDamage, string textPopupTextValue, Color textColor, int textFontSize) {
        
    }

    public void DeathOfBrick (bool isInstantiateLoot) {
        brick.SetState(brick.deathStateBrick);
        brick.DeathOfBrick(isInstantiateLoot);
    }

    public void Suicide () {
      //  brick.SetState(brick.deathStateBrick);
     //   brick.Suicide();
    }

    public void KillBrick(string textPopupTextValue) {
        brick.SetState(brick.takeDamageStateBrick);
        brick.KillBrick(textPopupTextValue);
    }

    public void ChangeRigidbodyType (RigidbodyType2D rigidbodyType) {} //hmmm its a quastion
    public void Attack () {}
    public void ChangeColor() {} //hmm its a quastion
    
    public IEnumerator MoveToTarget(Vector3 startPos, Vector3 endPos, int currentY, int maxY) {
        yield break;
    }
}
