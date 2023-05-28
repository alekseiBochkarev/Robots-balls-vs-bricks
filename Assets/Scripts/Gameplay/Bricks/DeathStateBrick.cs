using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathStateBrick : IStateBrick
{
    Brick brick;
    public DeathStateBrick(Brick brick) {
        this.brick = brick;
    }
    
    public void Enter() {
        //Debug.Log("DEATH STATE BRICK");
       // brick.animator.Play("death");
       //brick.animator.enabled = false;
        //brick.animator.enabled = true;
       // brick.animator.Play("death"); 
    }

    public void Exit(){}
    public IEnumerator DoDamage(int applyDamage)
    {
        return null;
    }
    public void HealUp(float healHealthUpAmount){}
    public void TakeDamage (int appliedDamage){}
    public void TakeDamage(int appliedDamage, Color damageTextColor, int damageTextFontSize){}
    public void TakeDamage(int appliedDamage, string textPopupTextValue, Color textColor, int textFontSize){}
    
    public void DeathOfBrick (bool isInstantiateLoot){
        
        //AnimatorClipInfo[] m_AnimatorClipInfo = brick.animator.GetCurrentAnimatorClipInfo(0);
        //Output the name of the starting clip
        
        
        //Debug.Log("Starting clip : " + m_AnimatorClipInfo[0].clip);
            
        Color color = new Color(brick.m_SpriteRenderer.color.r, brick.m_SpriteRenderer.color.g, brick.m_SpriteRenderer.color.b, 0.5f);
        brick.m_ParentParticle.startColor = color;
        brick.m_ParentParticle.Play();
        //2 - set Grid to 0
        //gameObject.GetComponentInParent<MoveDownBehaviour>().UpdateCurrentPosition();
        //gameObject.GetComponentInParent<MoveDownBehaviour>().SetZeroToCurrentPosition();
            // 3 - hide this Brick or this row
        brick.gameObject.SetActive(false);
            //m_Parent.CheckBricksActivation();
            // 4 - Set coin 
        EventManager.OnBrickDestroyed();
        if (isInstantiateLoot)
        {
            // Drop loot if has a chance
            brick.lootBag.InstantiateLoot();
        }
        
        //   WalletController.Instance.AddCoinAndShow();
        //destroy parent gameObject
       brick.Destroy();
    }

    public void Suicide (){
        DeathOfBrick(true);
    }

    public void KillBrick(string textPopupTextValue){}
    public void ChangeRigidbodyType (RigidbodyType2D rigidbodyType){} //hmmm its a quastion
    public void Attack (){}
    public void ChangeColor(){} //hmm its a quastion
    public IEnumerator MoveToTarget(Vector3 startPos, Vector3 endPos, int currentY, int maxY){yield break;}
}
