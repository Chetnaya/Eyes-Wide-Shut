using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
   }
   /*-------------------------------------------------------------------
   coroutine is a function that can pause its execution and resume it later.
   ------------------------------------------------------------------*/
   IEnumerator ShootGun()
   {
        yield return new WaitForSeconds(fireRate);
        canShoot =  true;
   }

}
