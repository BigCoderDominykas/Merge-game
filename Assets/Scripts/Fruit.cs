using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public float scale;
    public int index;
    public bool dropped = false;

    Spawner spawner;
    Rigidbody2D rb;

    private void Start()
    {
        this.tag = "Fruit";
        rb = GetComponent<Rigidbody2D>();
        //rb.isKinematic = true;
        //rb.gravityScale = 0;
        rb.simulated = false;

        transform.localScale = Vector3.one;
    }

    public void Drop()
    {
        transform.SetParent(null);
        //rb.isKinematic = false;
        //rb.gravityScale = 1;
        rb.simulated = true;
    }

    public void Selected(Transform sp, int ind, bool spawnedFromMerge)
    {
        transform.localScale = Vector3.one * scale;

        if (!spawnedFromMerge)
        {
            transform.position = sp.position;
            transform.SetParent(sp);
            //spawner = GetComponentInParent<Spawner>();
        }
        spawner = sp.gameObject.GetComponent<Spawner>();

        index = ind;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (transform.parent == null) dropped = true;

        if (!collision.gameObject.CompareTag("Fruit")) return;
        if (index == -1) return;

        if (collision.gameObject.GetComponent<Fruit>().index == index)
        {
            spawner.SpawnMergedFruit(index);
            //Destroy(gameObject);
        }
    }
}
