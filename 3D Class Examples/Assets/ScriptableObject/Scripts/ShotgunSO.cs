using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shotgun", menuName = "ScriptableObject/Shotgun")]
public class ShotgunSO : GunBehaviourSO
{
    public int shotgunBulletsPerShot;
    public float shotgunSpread;
    public override void OnClickBehaviour(WeaponHandler handler)
    {
        ShotgunShot(handler);
    }

    void ShotgunShot(WeaponHandler handler)
    {
        Instantiate(gunSFX, handler.transform.position, Quaternion.identity);
        for (int i = 0; i < shotgunBulletsPerShot; i++)
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(Random.Range(0.5F - shotgunSpread, 0.5F + shotgunSpread), Random.Range(0.5F - shotgunSpread, 0.5F + shotgunSpread), 0));
            Shoot(handler, ray);
        }
    }
}
