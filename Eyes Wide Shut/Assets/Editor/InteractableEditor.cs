using UnityEditor;

[CustomEditor(typeof(Interactable),true)]

public class InteractableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Interactable interactable = (Interactable)target;
        base.OnInspectorGUI();
        if(interactable.useEvents)
        {
            if(interactable.GetComponent<InteractionEvents>()==null)
            {
                interactable.gameObject.AddComponent<InteractionEvents>();
            }
            else
            if(interactable.GetComponent<InteractionEvents>() != null)
            {
                DestroyImmediate(interactable.GetComponent<InteractionEvents>());
            }
            
        }
    }
}

