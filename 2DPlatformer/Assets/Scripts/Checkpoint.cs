using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public static Vector3 keyPosition;
    public HeroController heroController;

    public Transform key;
    public bool keyCheckpoint = false;

    void Start()
    {
        keyPosition = key.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Hero")
        {
            keyCheckpoint = heroController.checkpoint;
        }
    }

    private void Respawn()
    {
        if (keyCheckpoint)
        {
            StartCoroutine("NewKey", keyPosition);
        }
    }

    IEnumerator NewKey(Vector3 pos)
    {
        yield return new WaitForSeconds(1);
        gameObject.transform.position = pos;
    }
}
