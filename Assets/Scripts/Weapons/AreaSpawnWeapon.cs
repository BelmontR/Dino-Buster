using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpawnWeapon : WeaponController
{
    public GameObject weaponObject;

    protected override void Attack()
    {
        base.Attack();
        weaponObject.SetActive(true);
    }

}
