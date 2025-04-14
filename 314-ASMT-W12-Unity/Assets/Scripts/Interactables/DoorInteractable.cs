using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class DoorInteractable : SimpleHingeInteractable
{
    [SerializeField] Transform doorObject;
    [SerializeField] CombinationLock combolock;

    [SerializeField] float minAngle;
    [SerializeField] float maxAngle;

    // Start is called before the first frame update
    void Start()
    {

    }

    protected override void Update()
    {
        base.Update();

        transform.localEulerAngles = new Vector3(0, Mathf.Clamp(transform.localRotation.eulerAngles.y, minAngle, maxAngle), 0);
    }
}
