using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerIntarection : MonoBehaviour
{
    public Camera mainCamera;
    public float intaractionDistance = 10f;

    public GameObject interactionUI;
    public TextMeshProUGUI interactionText;

    void Update()
    {
        
    }
    void InteractionRay()
    {
        Ray ray = mainCamera.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;
       // bool hitSomething = false;
        if(Physics.Raycast(ray, out hit, intaractionDistance))
        {
            IIntereractable intereractable = hit.collider.GetComponent<IIntereractable>();
            interactionText.text = intereractable.GetDesciption();
            if (Input.GetKey(KeyCode.E))
            {
                intereractable.Interact();
            }
		}
    }
}
