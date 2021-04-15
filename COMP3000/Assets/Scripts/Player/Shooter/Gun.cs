using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private float damage;
    [SerializeField]
    private float fireRate;
    [SerializeField]
    private float ammoType;
    [SerializeField]
    private float magSize;
    [SerializeField]
    private float range;
    [SerializeField]
    private float reloadTime;

    [SerializeField]
    private float currentAmmo;


    public Gun()
    {

    }

    private void Start()
    {
        currentAmmo = magSize;
    }

    public float GetDamage()
    {
        return damage;
    }

    public float GetFireRate()
    {
        return fireRate;
    }

    public float GetAmmoType()
    {
        return ammoType;
    }

    public float GetMagSize()
    {
        return magSize;
    }

    public float GetRange()
    {
        return range;
    }

    public float GetCurrentAmmo()
    {
        return currentAmmo;
    }

    public void SetCurrentAmmo(float setTo)
    {
        currentAmmo = setTo;
    }

    public float GetReloadTime()
    {
        return reloadTime;
    }

}
