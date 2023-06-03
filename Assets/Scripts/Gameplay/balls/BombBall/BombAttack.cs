using UnityEngine;

public class BombAttack : MonoBehaviour, AttackBehaviour
{
    GameObject ballPrefab;
    AudioSource audioSource; 

    public void SpecialAttack(Vector3 position, GameObject brick)
    {
       ballPrefab = Resources.Load<GameObject>("BombCloneBall");
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
       GameObject bombCloneBall = Instantiate(ballPrefab, position, Quaternion.identity);
    }
}
