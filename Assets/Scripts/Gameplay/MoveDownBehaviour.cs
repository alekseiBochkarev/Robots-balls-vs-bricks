using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MoveDownBehaviour : MonoBehaviour
{
    // value == 0 - empty, value == 1 - brick, value == 2 - barrier
    //private Grid grid;
    public bool needHorizontalMove;
    [SerializeField] private int x, y;
    public LevelConfig m_levelConfig;
    public bool isMovingNow = false;
    public bool canMove;
    Brick brick;
    private bool hasPlannedMoveDown;
    private Vector3 plannedStartPosition;
    private Vector3 plannedTargetPosition;
    private int plannedCurrentY;

    public void InitMoveDown()
    {
        m_levelConfig = LevelConfig.Instance != null
            ? LevelConfig.Instance
            : GameObject.FindGameObjectWithTag("MainCamera").GetComponent<LevelConfig>();
        UpdateCurrentPosition();
        // EventManager.BrickDestroyed += GetPositionAndResetCell;
        needHorizontalMove = false;
        canMove = true;
        //
    }

    private void OnDestroy()
    {
        //EventManager.BrickDestroyed -= GetPositionAndResetCell;
        GetPositionAndResetCell();
    }

    private void OnDisable()
    {
        GetPositionAndResetCell();
    }

    void Start()
    {
        //m_levelConfig = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<LevelConfig>();
        //UpdateCurrentPosition();
        //EventManager.BrickDestroyed += GetPositionAndResetCell;
        //Debug.Log("x " + x + " y " + y);
        //Debug.Log("value x and y+1 = " + m_levelConfig.grid.GetValue(x, y+1));
    }

    public void GetPositionAndResetCell()
    {
        UpdateCurrentPosition();
        SetZeroToCurrentPosition();
    }

    private void UpdateCurrentPosition()
    {
           m_levelConfig.grid.GetXY(this.transform.parent.position, out x, out y);
    }

    private void SetZeroToCurrentPosition()
    {
        SetFreeXY();
    }

    public IEnumerator MoveDown()
    {
        if (TryPlanMoveDown())
        {
            PreparePlannedMoveDown();
            yield return ExecutePlannedMoveDown();
        }
        else
        {
            yield return null;
        }
    }

    public void RefreshGridPosition()
    {
        UpdateCurrentPosition();
    }

    public bool TryPlanMoveDown()
    {
        RefreshGridPosition();
        hasPlannedMoveDown = false;

        if (!canMove)
        {
            return false;
        }

        int targetX = x;
        int targetY = y + 1;
        int targetCellValue = m_levelConfig.grid.GetValue(targetX, targetY);

        if (targetCellValue == 2)
        {
            needHorizontalMove = true;
            return false;
        }

        if (targetCellValue != 0)
        {
            return false;
        }

        PlanMoveDownToCell(targetX, targetY);
        return true;
    }

    public void PlanMoveDownToCell(int targetX, int targetY)
    {
        hasPlannedMoveDown = true;
        plannedStartPosition = transform.parent.position;
        plannedTargetPosition = m_levelConfig.grid.GetWorldPosition(targetX, targetY);
        plannedCurrentY = targetY + 1;
        needHorizontalMove = false;
    }

    public void CancelPlannedMoveDown()
    {
        hasPlannedMoveDown = false;
    }

    public void PreparePlannedMoveDown()
    {
        if (hasPlannedMoveDown)
        {
            SetFreeXY();
        }
    }

    public IEnumerator ExecutePlannedMoveDown()
    {
        if (!hasPlannedMoveDown)
        {
            yield break;
        }

        hasPlannedMoveDown = false;
        yield return MoveAndUpdateCurrentPosition(plannedStartPosition, plannedTargetPosition, plannedCurrentY,
            m_levelConfig.GetHeight());
    }

    public virtual IEnumerator MoveToTarget(Vector3 startPos, Vector3 endPos, int currentY, int maxY)
    {
        isMovingNow = true;
        float speed = 0.1f; //  скорость прогресса (от начальной до конечной позиции)
        float progress = 0;
        while (true)
        {
            progress += speed;
            transform.parent.position = Vector3.Lerp(startPos, endPos, progress);
            if (progress >= 1)
            {
                isMovingNow = false;
                yield break; // выход из корутины, если находимся в конечной позиции
            }

            yield return
                null; // если выхода из корутины не произошло, то продолжаем выполнять цикл while в следующем кадре
        }
    }

    IEnumerator MoveAndUpdateCurrentPosition(Vector3 startPos, Vector3 endPos, int currentY, int maxY)
    {
            yield return StartCoroutine(MoveToTarget(startPos, endPos, currentY, maxY));
            UpdateCurrentPosition();
            SetBusyXY();
        
    }

    public IEnumerator MoveHorizontal()
    {
        if (needHorizontalMove)
        {
            if (m_levelConfig.grid.GetValue(x - 1, y) == 0)
            {
                SetFreeXY();
                Vector3 target = m_levelConfig.grid.GetWorldPosition(x - 1, y);
                //iTween.MoveTo(gameObject, new Vector3(target.x, target.y, target.z), 0.05f);
                //StartCoroutine(WaitAndUpdateCurrentPosition());
                yield return MoveAndUpdateCurrentPosition(gameObject.transform.position, target, y+1, m_levelConfig.GetHeight());
                needHorizontalMove = false;
            }
            else if (m_levelConfig.grid.GetValue(x + 1, y) == 0)
            {
                SetFreeXY();
                Vector3 target = m_levelConfig.grid.GetWorldPosition(x + 1, y);
                //iTween.MoveTo(gameObject, new Vector3(target.x, target.y, target.z), 0.05f);
                //StartCoroutine(WaitAndUpdateCurrentPosition());
                yield return MoveAndUpdateCurrentPosition(gameObject.transform.position, target, y+1, m_levelConfig.GetHeight());
                needHorizontalMove = false;
            }

            needHorizontalMove = false;
        }
    }

    private void SetBusyXY()
    {
        m_levelConfig.grid.SetValue(x, y, 1);
    }

    private void SetFreeXY()
    {
        m_levelConfig.grid.SetValue(x, y, 0);
    }

    public int X
    {
        get { return x; }
    }

    public int Y
    {
        get { return y; }
    }
}
