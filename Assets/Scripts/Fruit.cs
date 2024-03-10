using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    Rigidbody2D rb;
    public bool dropped = false;
    Transform spawner;
    Transform preview;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        transform.position = preview.position;
    }

    public void Drop()
    {
        transform.SetParent(null);
        rb.isKinematic = false;
    }

    public void Selected(Transform sp)
    {
        spawner = sp;
        transform.position = spawner.position;
        transform.parent = spawner;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (transform.parent == null) dropped = true;
    }
}
