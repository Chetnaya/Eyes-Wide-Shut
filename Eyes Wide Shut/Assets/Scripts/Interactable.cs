using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

//This script follows the "template method pattern"
public abstract class Interactable : MonoBehaviour
{
    //Add or remove an interaction event component to this game object.
    public bool useEvents;

    //Message displayed to the player while looking at an interactable.
    public string promtMessage;

    public virtual string Onlook()
    {
        return promtMessage;
    }

    public void baseInteract()
    {
        if(useEvents)
        {
            GetComponent<InteractionEvents>().OnInteract.Invoke();
        }
        Interact();
    }

    // Unity Event to trigger when the object is interacted with
    // public UnityEvent onInteract;
    public UnityEvent OnInteract = new UnityEvent();

    protected virtual void Interact()
    {
        // Invoke the Unity Event
        OnInteract.Invoke();
    }
    // protected virtual void Interact()
    // {
    //     // A template function  to be overridden by our subclasses.
    // }

}
