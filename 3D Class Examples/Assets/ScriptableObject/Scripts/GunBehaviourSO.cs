using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun Behaviour", menuName = "ScriptableObject/Gun Behaviour")]
public class GunBehaviourSO : ScriptableObject
{
    public float gunRange = 10;
    public float gunImpactForce = 10;
    public LayerMask gunMask;
    public GameObject gunDecal;
    public GameObject gunSFX;

    public virtual void OnClickBehaviour(WeaponHandler handler)
    {
        PistolShot(handler);
    }
    void PistolShot(WeaponHandler handler)
    {
        Instantiate(gunSFX, handler.transform.position, Quaternion.identity);
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        Shoot(handler, ray);
    }

    protected void Shoot(WeaponHandler handler, Ray ray)
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
                    hit.rigidbody.AddForceAtPosition((hit.point - handler.transform.position).normalized * gunImpactForce, hit.point);

                }

                CheatCharacter character = hit.collider.GetComponentInParent<CheatCharacter>();
                if (character != null)
                {
                    character.TakeHit();
                }
            }
        }
    }
}
