using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    private void Awake() {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Palyer.Enable();
    }

    /* return vector 2 dimention when press key*/
    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Palyer.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        
        return inputVector;
    }
}
