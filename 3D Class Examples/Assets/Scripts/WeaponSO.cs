using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Weapon", menuName = "ScriptableObject/Weapon")]
public class WeaponSO : ScriptableObject
{
    public Sprite reticle;
    public List<GunBehaviourSO> behaviours;

    public virtual void OnClickBehaviour(WeaponHandler handler)
    {
        foreach (var item in behaviours)
        {
            item.OnClickBehaviour(handler);
        }
    }
}
