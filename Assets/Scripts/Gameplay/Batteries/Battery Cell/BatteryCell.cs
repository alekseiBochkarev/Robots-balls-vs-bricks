using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class BatteryCell : MonoBehaviour
{
    /**
     * BatteryCell содержит в себе логику изменения спрайта под разные цвета
     */
    [SerializeField] private Sprite greenCellSprite;
    [SerializeField] private Sprite yellowCellSprite;
    [SerializeField] private Sprite redCellSprite;

    private Image _cellSprite;

    private void Start()
    {
        _cellSprite = this.transform.GetComponent<Image>();
        Debug.Log("_cellSprite is -> " + _cellSprite);
      //  LoadSprites();
    }

    public void ChangeCellColor(BatteryCellColors cellColor)
    {
        _cellSprite = this.transform.GetComponent<Image>();
        Debug.Log("greenCellSprite is -> " + greenCellSprite);
        Debug.Log("yellowCellSprite is -> " + yellowCellSprite);
        Debug.Log("redCellSprite is -> " + redCellSprite);
        switch (cellColor)
        {
            case BatteryCellColors.Green:
                _cellSprite.sprite = greenCellSprite;
                break;
            case BatteryCellColors.Yellow:
                _cellSprite.sprite = yellowCellSprite;
                break;
            case BatteryCellColors.Red:
                _cellSprite.sprite = redCellSprite;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(cellColor), cellColor, "There's wrong cellColor used!");
        }
    }

    private void LoadSprites()
    {
        Debug.Log("Load Sprites");
        greenCellSprite = Resources.Load<Sprite>("Batteries/BatteryCell/Battery_Cell_Green");
        yellowCellSprite = Resources.Load<Sprite>("Batteries/BatteryCell/Battery_Cell_Yellow");
        redCellSprite = Resources.Load<Sprite>("Batteries/BatteryCell/Battery_Cell_Red");
        Assert.IsNotNull(greenCellSprite);
        Assert.IsNotNull(yellowCellSprite);
        Assert.IsNotNull(redCellSprite);
        
        
        Debug.Log("AFTER LOADSPRITES: greenCellSprite is -> " + greenCellSprite);
        Debug.Log("AFTER LOADSPRITES: yellowCellSprite is -> " + yellowCellSprite);
        Debug.Log("AFTER LOADSPRITES: redCellSprite is -> " + redCellSprite);
    }
}

public enum BatteryCellColors
{
    Green,
    Yellow,
    Red
}