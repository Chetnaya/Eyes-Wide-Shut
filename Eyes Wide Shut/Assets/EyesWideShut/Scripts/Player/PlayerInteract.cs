using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Camera cam;

    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;

    private PlayerUI playerUI;

    private InputManager inputManager;


    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        //Creates a ray at the centre of the camera , shooting outwards.
        //new Ray(First part is the origin, and the Direction)
        Ray ray = new Ray(cam.transform.position, cam.transform.forward );
        Debug.DrawRay(ray.origin, ray.direction * distance);

        //Variable to store our RayCast hit or our collision info
        RaycastHit hitInfo ;
        //To check if we have actually hit anything
        //RayCasting to the centre of the screen
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            //Checking to see if out game component has an interactable component
            if(hitInfo.collider.GetComponent<Interactable>()!= null)
            {
                //If it does, storing that interactable in a variable
                Interactable interactable= hitInfo.collider.GetComponent<Interactable>();
                //Updating OnScreen Text
                playerUI.UpdateText(interactable.promtMessage);
                if(inputManager.onFoot.Interact.triggered)
                {
                    interactable.baseInteract();

                }
            }
        }
    }
}
