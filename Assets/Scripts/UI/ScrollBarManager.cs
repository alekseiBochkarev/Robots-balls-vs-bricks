using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBarManager : MonoBehaviour
{
    void OnEnable()
    {
        this.gameObject.GetComponent<Scrollbar>().value = 1;
    }
}
