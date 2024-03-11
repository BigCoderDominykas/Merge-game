using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float delay;
    float delayCopy;
    public Transform preview;

    public List<Fruit> fruits;

    int fruitIndex;
    int timesCalled = 0;
    int prevInd = -1;

    GameObject currentFruit;
    GameObject nextFruit;

    private void Start()
    {
        UpdatePreview();
        PickNextFruit();
        UpdatePreview();

        delayCopy = delay;
    }

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, transform.position.y);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            currentFruit.GetComponent<Fruit>().Drop();
        }

        if (currentFruit == null || currentFruit.transform.parent == null)
        {
            delayCopy -= Time.deltaTime;

            if (delayCopy <= 0)
            {
                delayCopy = delay;
                PickNextFruit();
                UpdatePreview();
            }
        }
    }

    void PickNextFruit()
    {
        currentFruit = nextFruit;
        currentFruit.GetComponent<Fruit>().Selected(transform, fruitIndex, false);
    }

    void UpdatePreview()
    {
        fruitIndex = Random.Range(0, fruits.Count);
        nextFruit = Instantiate (fruits[fruitIndex].gameObject, preview.position, Quaternion.identity);
        if (fruitIndex == fruits.Count - 1) fruitIndex = -1;
    }

    public void SpawnMergedFruit(int ind)
    {
        timesCalled++;
        if (timesCalled == 2)
        {
            timesCalled = 0;
            var mergedFruit = Instantiate(fruits[ind + 1].gameObject, Vector3.zero, Quaternion.identity);
            mergedFruit.GetComponent<Fruit>().Selected(transform, ind + 1, true);
            mergedFruit.GetComponent<Fruit>().Drop();
            return;
        }
    }
}
