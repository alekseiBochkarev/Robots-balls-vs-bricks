using UnityEngine;
public class InstaKillComboAttack : MonoBehaviour, ComboAttackBehaviour
{
  public string instaKillMessageText;
  public InstaKillComboAttack(string text)
  {
    this.instaKillMessageText = text;
  }
  public void ComboAttack(Vector3 position, GameObject brick)
  {
    System.Random rn = new System.Random();
    int rnNum = rn.Next(1, 10);
   // Debug.Log("Random Num for InstaKill Ball is -> " + rnNum);
    if (rnNum == 1)
    {
      //  Debug.Log("Try Kill Brick with InstaKill Ball");
        brick.GetComponent<Brick>().KillBrick(instaKillMessageText);
    }
  }
}
