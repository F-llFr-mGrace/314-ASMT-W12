using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class SimpleHingeInteractable : XRSimpleInteractable
{
    public UnityEvent<SimpleHingeInteractable> OnHingeSelected;
    [SerializeField] AudioClip hingeMoveClip;
    public AudioClip GetHingeMoveClip => hingeMoveClip;

    protected Transform grabHand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (grabHand != null)
        {
            transform.LookAt(grabHand, transform.forward);
        }
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        grabHand = args.interactorObject.transform;
        OnHingeSelected?.Invoke(this);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        grabHand = null;
    }
}
