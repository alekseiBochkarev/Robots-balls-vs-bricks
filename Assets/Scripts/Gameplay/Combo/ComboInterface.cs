using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Combo
{
    public interface ComboInterface
    {
        public void ComboAttack(Vector3 position, GameObject brick);
    }
}