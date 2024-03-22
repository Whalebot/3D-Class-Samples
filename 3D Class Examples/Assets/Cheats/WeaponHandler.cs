using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponHandler : MonoBehaviour
{
    public WeaponSO currentWeapon;
    public Image reticle;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        reticle.sprite = currentWeapon.reticle;

        if (Input.GetMouseButtonDown(0))
        {
            currentWeapon.OnClickBehaviour(this);
        }
        if (Input.GetMouseButton(0))
        {
            currentWeapon.OnClickBehaviour(this);
        }
    }


}
