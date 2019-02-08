﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Teleport TeleportToMoveTo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = TeleportToMoveTo.transform.position;
    }
}
