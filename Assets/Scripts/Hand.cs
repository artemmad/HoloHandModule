using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class Hand : MonoBehaviour
{
    private Vector3 userHandPos;
    private Quaternion userHandRot;

    private void Awake()
    {
        InteractionManager.InteractionSourceUpdated += HandPosition;
    }

    private void HandPosition(InteractionSourceUpdatedEventArgs interactionSourceUpdatedEventArgs)
    {
        interactionSourceUpdatedEventArgs.state.sourcePose.TryGetPosition(out userHandPos);
        interactionSourceUpdatedEventArgs.state.sourcePose.TryGetRotation(out userHandRot);
    }

    private void Update()
    {
        transform.position = userHandPos;
        transform.rotation = userHandRot;
    }

}
