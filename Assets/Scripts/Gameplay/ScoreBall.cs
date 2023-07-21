using UnityEngine;
using System.Collections;

public class ScoreBall : MoveDownBehaviour
{
    //private BricksRow m_Parent;
    private ParticleSystem m_ParentParticle;
    private GameObject parent;
    [SerializeField] private AudioClip clip;
    private GameObject camera;
    private Color m_ParticleColor;

    private void Awake()
    {
        InitMoveDown();
        camera = GameObject.Find("MainCamera");
        parent = transform.parent.gameObject;
    //    m_Parent = GetComponentInParent<BricksRow>();
        m_ParentParticle = GetComponentInParent<ParticleSystem>();

        m_ParticleColor = new Color(0, 1, 0, 0.5f);
    }

    private void OnEnable() {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<AbstractBall>() != null)
        {
            BallLauncher.Instance.m_TempAmount++;    // increase balls amount
            PlayParticle();
            //parent.GetComponentInParent<MoveDownBehaviour>().UpdateCurrentPosition();
            //parent.GetComponentInParent<MoveDownBehaviour>().SetZeroToCurrentPosition();
            EventManager.OnBrickDestroyed();
            camera.GetComponent<AudioManager>().PlayAudio(clip);
            Destroy(parent, 1);
        }  else if (collision.gameObject.tag == "Finish") 
        {
            SuicideScoreBall();
        }
    }

    private void SuicideScoreBall () {
        BallLauncher.Instance.m_TempAmount++;    // increase balls amount
        PlayParticle();
        //parent.GetComponentInParent<MoveDownBehaviour>().UpdateCurrentPosition();
        //parent.GetComponentInParent<MoveDownBehaviour>().SetZeroToCurrentPosition();
        EventManager.OnBrickDestroyed();
        Destroy(parent, 0.1f);
    }

    private void Update()
    {
       
    }

    private void PlayParticle()
    {
        gameObject.SetActive(false);

        m_ParentParticle.startColor = m_ParticleColor;
        m_ParentParticle.Play();
    }
}