using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunHandler : MonoBehaviour
{
    public Image gunReticle;
    public CheatWeaponSO currentWeapon;
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void ChangeWeapon()
    {
        gunReticle.sprite = currentWeapon.reticle;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentWeapon.OnClickBehaviour(this);
        }
        if (Input.GetMouseButton(0))
        {
            currentWeapon.OnHoldBehaviour(this);
        }
        if (Input.GetMouseButtonUp(2))
        {
            currentWeapon.OnReleaseBehaviour(this);
        }
    }

}
