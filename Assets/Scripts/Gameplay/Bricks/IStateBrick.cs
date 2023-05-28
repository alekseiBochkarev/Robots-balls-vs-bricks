using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateBrick
{
    public void Enter();
    public void Exit();
    public IEnumerator DoDamage(int applyDamage);
    public void HealUp(float healHealthUpAmount);
    public void TakeDamage (int appliedDamage);
    public void TakeDamage(int appliedDamage, Color damageTextColor, int damageTextFontSize);
    public void TakeDamage(int appliedDamage, string textPopupTextValue, Color textColor, int textFontSize);
    public void DeathOfBrick(bool isInstantiateLoot); 
    public void Suicide ();
    public void KillBrick(string textPopupTextValue);
    public void ChangeRigidbodyType (RigidbodyType2D rigidbodyType); //hmmm its a quastion
    public void Attack ();
    public void ChangeColor(); //hmm its a quastion
    public IEnumerator MoveToTarget(Vector3 startPos, Vector3 endPos, int currentY, int maxY);
}
