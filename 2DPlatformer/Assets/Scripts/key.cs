using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    public DoorScript door;

    private void OnTriggerEnter2D(Collider2D col)
    {
        door.Open();
    }
}
