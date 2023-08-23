using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Animation
{
    public class UfoAnimationScript : MonoBehaviour
    {
        [SerializeField] private GameObject fire;
        private Vector3 startPos;

        private void Start()
        {
            fire.SetActive(true);
            startPos = transform.position;
            StartCoroutine(MoveUp());
        }

        public IEnumerator MoveUp()
        {
            Vector3 endPos = new Vector3(startPos.x, startPos.y + 2);
            float speed = 0.1f; //  скорость прогресса (от начальной до конечной позиции)
            float progress = 0;
            while (true)
            {
                progress += speed;
                this.transform.position = Vector3.Lerp(startPos, endPos, progress);
                if (progress >= 1)
                {
                    yield return MoveAway(endPos); // выход из корутины, если находимся в конечной позиции
                }

                yield return
                    null; // если выхода из корутины не произошло, то продолжаем выполнять цикл while в следующем кадре
            }
        }

        public IEnumerator MoveAway(Vector3 startPos)
        {
            Vector3 endPos = new Vector3(startPos.x + 5, startPos.y + 5);
            float speed = 0.1f; //  скорость прогресса (от начальной до конечной позиции)
            float progress = 0;
            while (true)
            {
                progress += speed;
                this.transform.position = Vector3.Lerp(startPos, endPos, progress);
                if (progress >= 1)
                {
                    yield return DestroyUfo(); // выход из корутины, если находимся в конечной позиции
                }

                yield return
                    null; // если выхода из корутины не произошло, то продолжаем выполнять цикл while в следующем кадре
            }
        }

        public IEnumerator DestroyUfo()
        {
            Destroy(this.gameObject);
            yield break;
        }
    }
}