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
   public ParticleSystem muzzleFlashParticleSystem;
   public AudioSource shootingAudio;
   /*-------------------------------------------------------------
   ----------------------------Aiming-----------------------------
   --------------------------------------------------------------*/
   public Vector3 normalLocalPosition;
   public Vector3 aimingLocalPosition;
   public float aimSmoothing = 10;
   /*-------------------------------------------------------------
   -------------------------Weapon Recoil-------------------------
   --------------------------------------------------------------*/
   public bool randomizeRecoil;
   public Vector2 randomRecoilConstraints;
   public Vector2 recoilPattern;
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
       shootingAudio = shootingAudio.GetComponent<AudioSource>();
       muzzleFlashParticleSystem = muzzleFlashParticleSystem.GetComponent<ParticleSystem>();

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
        if(Input.GetMouseButton(1)) 
        {
            target = aimingLocalPosition;
        }
        //Lerp Function - linearly interpolates between two Vector3 values.
        Vector3 desiredPosition = Vector3.Lerp(transform.localPosition, target, Time.deltaTime * aimSmoothing);
        transform.localPosition = desiredPosition;
   }
   /*-------------------------------------------------------------
   ---------------Functionality for Recoil of weapon--------------
   --------------------------------------------------------------*/
   void DetermineRecoil()
   {
        transform.localPosition -= Vector3.forward * 0.1f;
        if(randomizeRecoil)
        {
            float xRecoil = Random.Range(-randomRecoilConstraints.x, randomRecoilConstraints.x);
            float yRecoil = Random.Range(-randomRecoilConstraints.y, randomRecoilConstraints.y);
            Vector2 recoil = new Vector2(xRecoil, yRecoil);  
        }
   }
   /*-------------------------------------------------------------------
   -----Function for the target objects that are to be shooted at------
   ------------------------------------------------------------------*/
   void RaycastForEnemy()
   {
        RaycastHit hit;
        if(Physics.Raycast(transform.parent.position, transform.parent.forward, out hit, 1 << LayerMask.NameToLayer("Enemy")))
        {
            //All actions are performed in the TRY but if there are any errors, it will jump to the CATCH loop.
            try
            {
                Debug.Log("Hit an enemy");
                Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.None;
                rb.AddForce(transform.parent.transform.forward * 500);
            }
            catch{ }
        }
   }
   /*-------------------------------------------------------------------
   coroutine is a function that can pause its execution and resume it later.
   ------------------------------------------------------------------*/
   IEnumerator ShootGun()
   {
        DetermineRecoil();
        RaycastForEnemy();
        StartCoroutine(muzzleFlash());

        // Create a new instance of the muzzle flash particle system
        GameObject muzzleFlashObject = Instantiate(muzzleFlashParticleSystem.gameObject, transform.position, transform.rotation);
        ParticleSystem muzzle_Flash = muzzleFlashObject.GetComponent<ParticleSystem>();
        muzzleFlashObject.transform.position = muzzleFlashParticleSystem.transform.position;
        muzzleFlashObject.transform.rotation = muzzleFlashParticleSystem.transform.rotation;

        // Play the muzzle flash particle system
        if (muzzle_Flash != null && currentAmmoInClip > 0)
        {
            muzzle_Flash.Play();
        }

        shootingAudio.Play();
        
        yield return new WaitForSeconds(fireRate);

        canShoot =  true;
        // Destroy the muzzle flash particle system after a short delay
        Destroy(muzzleFlashObject, 0.5f);
        yield return null;
   }
   //-------------------------------------------------------------------
   IEnumerator muzzleFlash()
    {
        muzzleFlashEffect.sprite = flashes[Random.Range(0, flashes.Length)];
        muzzleFlashEffect.color = Color.white;
        yield return new WaitForSeconds(0.05f);
        muzzleFlashEffect.sprite = null;
        muzzleFlashEffect.color = new Color(0,0,0,0);
    }
}
