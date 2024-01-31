using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePoolController : MonoBehaviour
{
    public GameObject objectToPool;
    [SerializeField] public int amountToPool = 30;
    private List<GameObject> objects;

    // Start is called before the first frame update
    void Start()
    {
        // List of objects
        objects = new List<GameObject>();

        GameObject temporary = null;
        for (int i = 0; i < amountToPool; i++)
        {
            // Instantiate new object
            temporary = Instantiate(objectToPool);
            temporary.SetActive(false);
            objects.Add(temporary);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            GameObject go = GetPooledObject();
            if (go != null)
            {
                // Generate random position
                float x = Random.Range(-20, 20);
                float y = Random.Range(10, 20);
                float z = Random.Range(-20, 20);
                go.transform.position = new Vector3(x, y, z);

                // Genrate random scale
                float s = Random.Range(0.2f, 2.0f);
                go.transform.localScale = new Vector3(s, s, s);

                // Generate random rotation
                float rx = Random.Range(-45.0f, 45.0f);
                float ry = Random.Range(-45.0f, 45.0f);
                float rz = Random.Range(-45.0f, 45.0f);
                go.transform.rotation = Quaternion.Euler(rx, ry, rz);

                // Activate object
                go.SetActive(true);
            }
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            // Check if object is active
            if (objects[i].activeInHierarchy == false) return objects[i];
        }

        return null;
    }
}
