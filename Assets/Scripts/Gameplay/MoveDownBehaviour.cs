using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDownBehaviour : MonoBehaviour
{
    // value == 0 - empty, value == 1 - brick, value == 2 - barrier
    private Grid grid;
    private bool needHorizontalMove = false;
    private int x, y;
    private LevelConfig m_levelConfig;

    private void Awake() {
        m_levelConfig = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<LevelConfig>();
        UpdateCurrentPosition();
        //Debug.Log("x " + x + " y " + y);
        //Debug.Log("value x and y+1 = " + m_levelConfig.grid.GetValue(x, y+1));
    }

    void Start() {
        
    }

    public void MoveDown(float howMuch)
    {
        iTween.MoveTo(gameObject, new Vector3(transform.position.x, transform.position.y - howMuch, transform.position.z), 0.25f);
    }

    public void UpdateCurrentPosition () {
        m_levelConfig.grid.GetXY(transform.position, out x, out y);
        //Debug.Log("current position after update x y " + x + " " + y);
    }

    public void SetZeroToCurrentPosition() {
        SetFreeXY();
        //Debug.Log("set zero to pos x y " + x + " " + y);
    }

    public void MoveDown()
    {
        UpdateCurrentPosition();
        if (m_levelConfig.grid.GetValue(x, y+1) == 0) {
            SetFreeXY();
            Vector3 target = m_levelConfig.grid.GetWorldPosition(x, y+1);
            iTween.MoveTo(gameObject, new Vector3(target.x, target.y, target.z), 0.25f);
            StartCoroutine(WaitAndUpdateCurrentPosition());
        } else if (m_levelConfig.grid.GetValue(x, y+1) == 2) {
            needHorizontalMove = true;
        }
    }

    IEnumerator WaitAndUpdateCurrentPosition()
    {
	    //Debug.Log("transform position before waiting " + transform.position);
        yield return new WaitForSeconds(0.5f);
        //Debug.Log("transform position after waiting " + transform.position);
        UpdateCurrentPosition();
        SetBusyXY();
    }

    public void MoveHorizontal () {
        if (needHorizontalMove) {
            if (m_levelConfig.grid.GetValue(x-1, y) == 0) {
                SetFreeXY();
                Vector3 target = m_levelConfig.grid.GetWorldPosition(x-1, y);
                iTween.MoveTo(gameObject, new Vector3(target.x, target.y, target.z), 0.25f);
                StartCoroutine(WaitAndUpdateCurrentPosition());
                needHorizontalMove = false;
            } else if (m_levelConfig.grid.GetValue(x+1, y) == 0) {
                SetFreeXY();
                Vector3 target = m_levelConfig.grid.GetWorldPosition(x+1, y);
                iTween.MoveTo(gameObject, new Vector3(target.x, target.y, target.z), 0.25f);
                StartCoroutine(WaitAndUpdateCurrentPosition());
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
