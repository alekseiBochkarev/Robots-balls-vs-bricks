using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathStateBrick : MonoBehaviour, IStateBrick
{
    Brick brick;
    public DeathStateBrick(Brick brick) {
        this.brick = brick;
    }
    
    public void Enter() {
       // brick.animator.Play("death");
       brick.animator.enabled = false;
        brick.animator.enabled = true;
        brick.animator.Play("death"); 
    }

    public void Exit(){}
    public void DoDamage(int applyDamage){}
    public void HealUp(float healHealthUpAmount){}
    public void TakeDamage (int appliedDamage){}
    public void TakeDamage(int appliedDamage, Color damageTextColor, int damageTextFontSize){}
    public void TakeDamage(int appliedDamage, string textPopupTextValue, Color textColor, int textFontSize){}
    
    public void DeathOfBrick (){
        
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

        // Drop loot if has a chance
        brick.lootBag.InstantiateLoot();

        //   WalletController.Instance.AddCoinAndShow();
        //destroy parent gameObject
       //Destroy(brick.parent, 1);  
        
    }

    public void Suicide (){
            
        // 1 - play a particle
        Color color = new Color(brick.m_SpriteRenderer.color.r, brick.m_SpriteRenderer.color.g, brick.m_SpriteRenderer.color.b, 0.5f);
        brick.m_ParentParticle.startColor = color;
        brick.m_ParentParticle.Play();
        //2 - set Grid to 0
        //gameObject.GetComponentInParent<MoveDownBehaviour>().UpdateCurrentPosition();
        //gameObject.GetComponentInParent<MoveDownBehaviour>().SetZeroToCurrentPosition();
            // 3 - hide this Brick or this row
        brick.gameObject.SetActive(false);
        EventManager.OnBrickDestroyed();

        // Drop loot if has a chance
        brick.lootBag.InstantiateLoot();

            //m_Parent.CheckBricksActivation();
            //destroy parent gameObject
        //brick.Destroy(brick.parent, 0.1f); ------ MOVE THIS TO BRICK
    }

    public void KillBrick(string textPopupTextValue){}
    public void ChangeRigidbodyType (RigidbodyType2D rigidbodyType){} //hmmm its a quastion
    public void Attack (){}
    public void ChangeColor(){} //hmm its a quastion
    public IEnumerator MoveToTarget(Vector3 startPos, Vector3 endPos){yield break;}
}
