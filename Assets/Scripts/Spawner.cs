using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject nextFruit;
    public List<Fruit> fruits;
    Fruit fruit;

    private void Start()
    {
        fruit = fruits[Random.Range(0, fruits.Count)];
        Instantiate(fruit.gameObject);
        fruit.Selected(transform);

        // Pick random next fruit
        UpdatePreview();
    }

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, transform.position.y);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            fruit.Drop();
            PickNextFruit();

        }
    }

    void PickNextFruit()
    {
        fruit = nextFruit.GetComponentInChildren<Fruit>();
        nextFruit.transform.DetachChildren();
        fruit.Selected(transform);
    }

    void UpdatePreview()
    {
        // Pick random fruit
        // Instantiate
    }
}
