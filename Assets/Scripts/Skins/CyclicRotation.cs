using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclicRotation : MonoBehaviour
{
    public float minAngle = -1.5f;        // Минимальный угол поворота
    public float maxAngle = 1.5f;      // Максимальный угол поворота
    public float speed = 2f;           // Скорость поворота

    private void Update()
    {
        // Вычисляем текущий угол поворота
        float angle = Mathf.PingPong(Time.time * speed, maxAngle - minAngle) + minAngle;

        // Устанавливаем вращение объекта
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
