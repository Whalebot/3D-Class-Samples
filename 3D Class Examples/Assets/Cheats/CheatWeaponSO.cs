using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "ScriptableObjects/Weapon")]
public class CheatWeaponSO : ScriptableObject
{
    public Sprite reticle;

    public bool shotgun;
    public float gunRange = 10;
    public float gunImpactForce = 10;
    public int shotgunBullets = 5;
    public float shotGunSpread = 0.1f;
    public LayerMask gunMask;
    public GameObject gunDecal;
    public GameObject gunSFX;

    public virtual void OnClickBehaviour(GunHandler gun)
    {
        if (!shotgun)
            Shoot(gun);
        else
            Shotgun(gun);
    }
    public virtual void OnHoldBehaviour(GunHandler gun) { }
    public virtual void OnReleaseBehaviour(GunHandler gun) { }

    void Shotgun(GunHandler gun)
    {
        //Shotgun SFX
        Instantiate(gunSFX, gun.transform.position, Quaternion.identity);

        for (int i = 0; i < shotgunBullets; i++)
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(Random.Range(0.5f - shotGunSpread, 0.5f + shotGunSpread), Random.Range(0.5f - shotGunSpread, 0.5f + shotGunSpread)));

            FireRay(gun.transform, ray);
        }
    }

    void FireRay(Transform t, Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit hit, gunRange, gunMask))
        {
            if (hit.collider)
            {
                Quaternion hitRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                GameObject decal = Instantiate(gunDecal, hit.point, hitRotation);
                decal.transform.parent = hit.transform;

                if (hit.rigidbody)
                {
                    hit.rigidbody.AddForceAtPosition((hit.point - t.transform.position).normalized * gunImpactForce, hit.point);
                }

                CheatCharacter character = hit.collider.GetComponentInParent<CheatCharacter>();

                if (character != null)
                {
                    character.TakeHit();
                }
            }
        }
    }

    protected void Shoot(GunHandler gun)
    {
        Instantiate(gunSFX, gun.transform.position, Quaternion.identity);
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));

        FireRay(gun.transform, ray);
    }
}
