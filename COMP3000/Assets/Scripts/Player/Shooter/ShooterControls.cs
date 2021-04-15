using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterControls : MonoBehaviour
{
    [SerializeField]
    int selectedGun = 0;
    [SerializeField]
    GameObject holster;

    Gun gunStats;

    public Camera cam;

    public bool firing = false;
    public bool reloading = false;
    private float nextTimeToFire = 0f;

    public ParticleSystem burst;

    // Start is called before the first frame update
    // Ensure correct gun is selected
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            if (i == selectedGun)
            {
                holster.transform.GetChild(selectedGun).gameObject.SetActive(true);
            }
            else
            {
                holster.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        gunStats = holster.transform.GetChild(selectedGun).GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        if (reloading)
        {
            return;
        }

        if (firing == true)
        {
            OnFire();
        }
    }

    public void OnFire()
    {
        // Check it can fire
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / gunStats.GetFireRate();

            // If no ammo, reload instead
            if (gunStats.GetCurrentAmmo() <= 0)
            {
                StartCoroutine(OnReload());
            }
            else
            {

                // Play fire animation
                burst.Play();

                // Check for hit
                RaycastHit hit;
                // origin                   direction               out     max distance
                if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, gunStats.GetRange()))
                {
                    EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
                    if (target != null)
                    {
                        target.TakeDamage(gunStats.GetDamage());
                    }
                }

                // Reduce ammo even if no hit
                gunStats.SetCurrentAmmo(gunStats.GetCurrentAmmo() - 1);
            }

        }                
    }

    public IEnumerator OnReload()
    {
        reloading = true;

        // animation

        yield return new WaitForSeconds(gunStats.GetReloadTime()); 

        gunStats.SetCurrentAmmo(gunStats.GetMagSize());

        reloading = false;
    }


    public void OnChangeGun(string btnName)
    {
        holster.transform.GetChild(selectedGun).gameObject.SetActive(false);

        // hard coded
        // need to make changes to allow for remapping
        if (btnName == "1")
        {
            selectedGun = 0;
        }
        else if (btnName == "2")
        {
            selectedGun = 1;
        }
        else if (btnName == "3")
        {
            selectedGun = 2;
        }
        else
        {
            selectedGun += 1;

            if (selectedGun == 3)
            {
                selectedGun = 0;
            }
        }

        holster.transform.GetChild(selectedGun).gameObject.SetActive(true);
        gunStats = holster.transform.GetChild(selectedGun).GetComponent<Gun>();
    }
}
