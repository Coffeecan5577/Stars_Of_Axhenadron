﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    void OnTriggerEnter(Collider collider)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        print("Player dying.");
        SendMessage("OnPlayerDeath");
    }
}