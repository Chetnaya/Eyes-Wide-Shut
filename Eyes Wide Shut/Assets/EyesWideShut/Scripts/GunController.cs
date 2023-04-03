using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{ 
   /*--------------------------------------------------------------
   -----------------------Static Variables-------------------------
   ---------------------------------------------------------------*/
   [Header("Gun Settings")]
   public float fireRate = 0.1f;
   public int clipSize = 30;    
   public int reservedAmmoCapacity = 270;
   /*-------------------------------------------------------------
   ----------------------Non-Static Variables---------------------
   --------------------------------------------------------------*/
   public bool canShoot;
   public int currentAmmoInClip;
   public int ammoInReserve;
   /*-------------------------------------------------------------
   --------------------------Game Objects-------------------------
   --------------------------------------------------------------*/
   public Image muzzleFlashEffect;
   public Sprite[] flashes;
   /*-------------------------------------------------------------
   ----------------------------Aiming-----------------------------
   --------------------------------------------------------------*/
   public Vector3 normalLocalPosition;
   public Vector3 aimingLocalPosition;
   public float aimSmoothing = 10;
   /*-------------------------------------------------------------
   -----Start is called on the frame when a script is enabled-----
   just before any of the Update methods is called the first time
   ---------------------------------------------------------------*/
   void Start()
   {
       //Assigning variables
       currentAmmoInClip = clipSize;
       ammoInReserve = reservedAmmoCapacity;
       canShoot = true;
   }
   /*-------------------------------------------------------------
   ------------------Update is called every frame-----------------
   ---------------------------------------------------------------*/
   void Update()
   {
        DetermineAim();
        //If holding left mouse button and Can shoot and clip has ammo
        if(Input.GetMouseButton(0) && canShoot && currentAmmoInClip > 0)
        {
            //Can shoot will be false whenever player shoots
            canShoot = false;
            //subtract one ammo from the clip
            currentAmmoInClip--;
            //Function to start the existing coroutine function in the game
            StartCoroutine(ShootGun());
        }
        //Reload Functionality
        else if(Input.GetKeyDown(KeyCode.R)  && currentAmmoInClip < clipSize && ammoInReserve > 0)
        {
            int amountNeededforReload = clipSize - currentAmmoInClip;
            if(amountNeededforReload >= ammoInReserve)
            {
                currentAmmoInClip += ammoInReserve;
                ammoInReserve -= amountNeededforReload;
            }
            else
            {
                currentAmmoInClip = clipSize;
                ammoInReserve -= amountNeededforReload;
            }

        }
   }
   /*-------------------------------------------------------------
   ----------------------Function for Aiming----------------------
   --------------------------------------------------------------*/
   void DetermineAim()
   {
        Vector3 target = normalLocalPosition;
        if(Input.GetMouseButton(1)) target = aimingLocalPosition;

        Vector3 desiredPosition = Vector3.Lerp(transform.localPosition, target, Time.deltaTime * aimSmoothing);

        transform.localPosition = desiredPosition;
   }
   /*-------------------------------------------------------------------
   coroutine is a function that can pause its execution and resume it later.
   ------------------------------------------------------------------*/
   IEnumerator ShootGun()
   {
        StartCoroutine(muzzleFlash());
        yield return new WaitForSeconds(fireRate);
        canShoot =  true;
   }
   IEnumerator muzzleFlash()
    {
        muzzleFlashEffect.sprite = flashes[Random.Range(0, flashes.Length)];
        muzzleFlashEffect.color = Color.white;
        yield return new WaitForSeconds(0.05f);
        muzzleFlashEffect.sprite = null;
        muzzleFlashEffect.color = new Color(0,0,0,0);
    }

}
