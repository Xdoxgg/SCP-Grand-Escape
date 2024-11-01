using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public Camera mainCamera;
    private float distance = 5f;
    public GameObject interactionUI;
    public TextMeshProUGUI interactionText;

    private void Update()
    {
        InteractionRay();
    }
    
    public void InteractionRay()
    {
        Ray ray = mainCamera.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;

        bool hitSomething = false;
        if (Physics.Raycast(ray, out hit, distance))
        {
            IInteracteble interacteble = hit.collider.GetComponent<IInteracteble>();
            if (interacteble != null)
            {
                hitSomething = true;
                interactionText.text = interacteble.GetDesciption();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interacteble.Interact();
                }
            }
        }
        interactionUI.SetActive(hitSomething);
    }
}