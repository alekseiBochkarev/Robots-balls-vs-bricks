using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Data_Managing
{
    public class ObjectPool : MonoBehaviour
    {
        public GameObject managingPrefab; // used for instantiate new items into the pool
        public int managingCount;
        public bool growOverAmount = true; // if true => allows the pool to grow when all items are being used

        private List<GameObject> pool = new List<GameObject>(); // pool that contains all instantiated/destroyed items

        private void Start()
        {
            if (managingPrefab != null && managingCount > 0)
            {
                for (int i = 0; i < managingCount; i++)
                {
                    AddPrefabToThePool(managingPrefab);
                    pool[i].gameObject.transform.SetParent(this.transform);
                }
            }
        }

        public void AddPrefabToThePool(GameObject prefab, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                AddPrefabToThePool(prefab);
            }
        }

        public void AddPrefabToThePool(GameObject prefab)
        {
            var instance = Instantiate(prefab);
            instance.SetActive(false);
            pool.Add(instance);
        }

        public GameObject Instantiate(string comboTypeName, Vector3 position, Quaternion rotation)
        {
            /*
            foreach (var item in pool)
            {
                // if current item is not active and haven't been used yet:
                 // - return it to reuse it from pool
                 //
                if (item.name.StartsWith(comboTypeName) && !item.activeInHierarchy)
                {
                    Debug.Log("COMBO item name " + item.name);
                    item.transform.position = position;
                    item.transform.rotation = rotation;
                    item.transform.SetParent(this.transform);
                    item.SetActive(true);
                    return item;
                }
            }*/

            /* if there are no inactive items in the pool and we allowed to grow the pool:
             * - creates another instance of prefab
             * - adds to the pool and returns it
             * */
            if (growOverAmount)
            {
                if (comboTypeName.Contains("Combo"))
                {
                    var comboPrefab = Resources.Load<GameObject>("ComboAttacks/" + comboTypeName);
                    var _instance = (GameObject) Instantiate(comboPrefab, position, rotation);
                    _instance.transform.SetParent(this.transform);
                    pool.Add(_instance);
                    return _instance;
                }    
                var instance = (GameObject) Instantiate(managingPrefab, position, rotation);
                instance.transform.SetParent(this.transform);
                pool.Add(instance);
                return instance;
            }
            /* if there are no inactive items in the pool and we aren't allowed to grow the pool:
             * - returns null
             * */
            return null;
        }
    }
}