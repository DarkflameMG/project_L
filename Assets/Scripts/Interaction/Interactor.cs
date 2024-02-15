using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadis = 0.5f;
    [SerializeField] private LayerMask interactableMask;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int numfound;
    [SerializeField]private GameObject popupSystem;
    [SerializeField]private LobbyInfo lobbyInfo;

    private void Start() {
        lobbyInfo.Busy = false;
    }
    private void Update() {
        numfound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadis, _colliders,
        interactableMask);

        if(numfound > 0)
        {
            var interactable = _colliders[0].GetComponent<IInteractable>();
            interactable.ShowPopup();

            if(interactable != null && Keyboard.current.eKey.wasPressedThisFrame)
            {
                lobbyInfo.PlayerLocation = transform.position;
                if(interactable.Interact(this))
                {
                    lobbyInfo.Busy = true;
                }
            }
        }
        else if(numfound == 0)
        {
            popupSystem.GetComponent<Popups>().ClosePopup();
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position,interactionPointRadis);
    }
}
