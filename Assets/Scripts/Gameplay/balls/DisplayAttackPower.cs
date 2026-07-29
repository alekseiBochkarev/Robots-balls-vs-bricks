using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public class DisplayAttackPower : MonoBehaviour
{
    private IBall ballComponent;
    [SerializeField]
    private Text textMeshPro;

    void Start()
    {
        // ����� ���������, ����������� ��������� IBall
        ballComponent = GetComponent<IBall>();

        if (ballComponent == null)
        {
            UnityEngine.Debug.LogError("Component implementing IBall not found on the GameObject.");
            return;
        }

        // Standard UI Text used instead of a TMP component.
        textMeshPro.alignment = TextAnchor.MiddleCenter;

        // �������� �����
        UpdateText();
    }

    void UpdateText()
    {
        textMeshPro.text = $"{ballComponent.GetAttackPower}";
    }

    void Update()
    {
        // ��������� ����� ������ ���� (���� ����������)
        UpdateText();
    }
}
