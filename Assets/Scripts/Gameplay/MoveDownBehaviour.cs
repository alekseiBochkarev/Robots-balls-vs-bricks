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
        grid = m_levelConfig.grid;
        UpdateCurrentPosition();
        Debug.Log("x " + x + " y " + y);
        Debug.Log("value x and y+1 = " + grid.GetValue(x, y+1));
    }

    void Start() {
        
    }

    public void MoveDown(float howMuch)
    {
        iTween.MoveTo(gameObject, new Vector3(transform.position.x, transform.position.y - howMuch, transform.position.z), 0.25f);
    }

    public void UpdateCurrentPosition () {
        grid.GetXY(transform.position, out x, out y);
        Debug.Log("current position after update x y " + x + " " + y);
    }

    public void SetZeroToCurrentPosition() {
        grid.SetValue(x, y, 0);
        Debug.Log("set zero to pos x y " + x + " " + y);
    }

    public void MoveDown()
    {
        if (grid.GetValue(x, y+1) == 0) {
            Vector3 target = grid.GetWorldPosition(x, y+1);
            iTween.MoveTo(gameObject, new Vector3(target.x, target.y, target.z), 0.25f);
            grid.SetValue(x, y, 0);
            grid.SetValue(x, y+1, 1);
            StartCoroutine(WaitAndUpdateCurrentPosition());
        } else if (grid.GetValue(x, y+1) == 2) {
            needHorizontalMove = true;
        }
    }

    IEnumerator WaitAndUpdateCurrentPosition()
    {
	    Debug.Log("transform position before waiting " + transform.position);
        yield return new WaitForSeconds(0.26f);
        Debug.Log("transform position after waiting " + transform.position);
        UpdateCurrentPosition();
    }

    public void MoveHorizontal () {
        if (needHorizontalMove) {
            if (grid.GetValue(x-1, y) == 0) {
                Vector3 target = grid.GetWorldPosition(x-1, y);
                iTween.MoveTo(gameObject, new Vector3(target.x, target.y, target.z), 0.25f);
                grid.SetValue(x, y, 0);
                grid.SetValue(x-1, y, 1);
                UpdateCurrentPosition();
                needHorizontalMove = false;
            } else if (grid.GetValue(x+1, y) == 0) {
                Vector3 target = grid.GetWorldPosition(x+1, y);
                iTween.MoveTo(gameObject, new Vector3(target.x, target.y, target.z), 0.25f);
                grid.SetValue(x, y, 0);
                grid.SetValue(x+1, y, 1);
                UpdateCurrentPosition();
                needHorizontalMove = false;
            }
        }
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
