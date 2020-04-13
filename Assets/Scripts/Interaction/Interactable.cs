﻿/*
 * This is the base class for all Interactable objects. To create an interactable behavior, follow these steps:
 * 1. Create a new class "<name> : Interactable"
 * 2. Override the virtual methods to implement custom behavior
 * 3. Add the "Interactable"-Tag to the game object
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string displayText;
    public string displaySubtext;
    public bool ignoreTagCheck = false;

    private void Start()
    {
        if (!gameObject.CompareTag("Interactable"))
        {
            Logger.logWarning("Interactable " + gameObject.name + " has no Tag 'Interactable'. This might lead to functionality problems.");
        }
    }

    public abstract void interact();
}