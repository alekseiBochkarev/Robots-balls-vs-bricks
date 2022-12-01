using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDownBehaviour : MonoBehaviour
{
    // value == 0 - empty, value == 1 - brick, value == 2 - barrier
    //private Grid grid;
    private bool needHorizontalMove = false;
    [SerializeField] private int x, y;
    private LevelConfig m_levelConfig;
    public bool isMovingNow = false;
    Brick brick;

    private void Awake() {
        m_levelConfig = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<LevelConfig>();
        UpdateCurrentPosition();
        EventManager.BrickDestroyed += GetPositionAndResetCell;
        //Debug.Log("x " + x + " y " + y);
        //Debug.Log("value x and y+1 = " + m_levelConfig.grid.GetValue(x, y+1));
    }

    private void OnDestroy() {
        EventManager.BrickDestroyed -= GetPositionAndResetCell;
    }

    void Start() {
        
    }

  /*  public void MoveDown(float howMuch)
    {
        iTween.MoveTo(gameObject, new Vector3(transform.position.x, transform.position.y - howMuch, transform.position.z), 0.05f);
    }*/

    public void GetPositionAndResetCell () {
        UpdateCurrentPosition();
        SetZeroToCurrentPosition();
    }

    private void UpdateCurrentPosition () {
        m_levelConfig.grid.GetXY(this.transform.position, out x, out y);
        //Debug.Log("current position after update x y " + x + " " + y);
    }

    private void SetZeroToCurrentPosition() {
        SetFreeXY();
        //Debug.Log("set zero to pos x y " + x + " " + y);
    }

    public void MoveDown()
    {
        UpdateCurrentPosition();
        if (m_levelConfig.grid.GetValue(x, y+1) == 0) {
            SetFreeXY();
            Vector3 target = m_levelConfig.grid.GetWorldPosition(x, y+1);
            //iTween.MoveTo(gameObject, new Vector3(target.x, target.y, target.z), 0.05f);
            StartCoroutine(MoveAndUpdateCurrentPosition(gameObject.transform.position, target));
        } else if (m_levelConfig.grid.GetValue(x, y+1) == 2) {
            needHorizontalMove = true;
        }
    }

    IEnumerator MoveToTarget(Vector3 startPos, Vector3 endPos)
    {
        isMovingNow = true;
        float speed = 0.1f; //  скорость прогресса (от начальной до конечной позиции)
        float progress = 0;
        while (true)
        {
            if (transform.GetComponentInChildren<Brick>() != null) {
                brick = transform.GetComponentInChildren<Brick>();
                brick.SetState(brick.walkStateBrick);
            }
            progress += speed;
            transform.position = Vector3.Lerp(startPos, endPos, progress);
            if (progress  >= 1) {
                isMovingNow = false;
                if (transform.GetComponentInChildren<Brick>() != null) {
                    brick = transform.GetComponentInChildren<Brick>();
                    Debug.Log("stop brick");
                    brick.SetState(brick.idleStateBrick);
                }
                yield break; // выход из корутины, если находимся в конечной позиции
            }
            yield return null; // если выхода из корутины не произошло, то продолжаем выполнять цикл while в следующем кадре
        }
    }

    IEnumerator MoveAndUpdateCurrentPosition(Vector3 startPos, Vector3 endPos)
    {
	    yield return StartCoroutine(MoveToTarget(startPos, endPos));
        //Debug.Log("transform position before waiting " + transform.position);
        //yield return new WaitForSeconds(0.25f);
        //Debug.Log("transform position after waiting " + transform.position);
        UpdateCurrentPosition();
        SetBusyXY();
    }

    public void MoveHorizontal () {
        if (needHorizontalMove) {
            if (m_levelConfig.grid.GetValue(x-1, y) == 0) {
                SetFreeXY();
                Vector3 target = m_levelConfig.grid.GetWorldPosition(x-1, y);
                //iTween.MoveTo(gameObject, new Vector3(target.x, target.y, target.z), 0.05f);
                //StartCoroutine(WaitAndUpdateCurrentPosition());
                StartCoroutine(MoveAndUpdateCurrentPosition(gameObject.transform.position, target));
                needHorizontalMove = false;
            } else if (m_levelConfig.grid.GetValue(x+1, y) == 0) {
                SetFreeXY();
                Vector3 target = m_levelConfig.grid.GetWorldPosition(x+1, y);
                //iTween.MoveTo(gameObject, new Vector3(target.x, target.y, target.z), 0.05f);
                //StartCoroutine(WaitAndUpdateCurrentPosition());
                StartCoroutine(MoveAndUpdateCurrentPosition(gameObject.transform.position, target));
                needHorizontalMove = false;
            }
            needHorizontalMove = false;
        }
    }

    private void SetBusyXY () {
        m_levelConfig.grid.SetValue(x,y,1);
    }

    private void SetFreeXY () {
        m_levelConfig.grid.SetValue(x,y,0);
    }

    public int X
    {
        get
        {
            return x;
        }
    }

    public int Y
    {
        get
        {
            return y;
        }
    }

}
