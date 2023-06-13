using System;
using Skins.Abstract;
using Skins.Heads;
using UnityEngine;

namespace Skins
{
    public class Tester : MonoBehaviour
    {
        private IInventory _inventory;

        private void Awake()
        {
            var inventoryCapacity = 10;
            _inventory = new InventoryHead(inventoryCapacity);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
               // AddRobotHead();
            if (Input.GetKeyDown(KeyCode.R))
                RemoveRobotHead();
        }
/*
        private void AddRobotHead()
        {
            var robotHead = new RobotHead();
            _inventory.TryToAdd(this, robotHead);
        }
*/
        private void RemoveRobotHead()
        {
            _inventory.Remove(this, typeof(RobotHead));
        }
    }
}