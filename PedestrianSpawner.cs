using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestrian : MonoBehaviour
{
    public List<GameObject> pedestrianPrefabs; // List of pedestrian prefabs
    public int numberOfPedestrians;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPedestrians());
    }

    IEnumerator SpawnPedestrians()
    {
        for (int i = 0; i < numberOfPedestrians; i++)
        {
            // Pick a random pedestrian prefab from the list
            GameObject randomPedestrianPrefab = pedestrianPrefabs[Random.Range(0, pedestrianPrefabs.Count)];
            GameObject pedestrian = Instantiate(randomPedestrianPrefab);

            // Pick a random waypoint from the child objects
            Transform child = transform.GetChild(Random.Range(0, transform.childCount - 1));
            pedestrian.GetComponent<WaypointNavigator>().currentWaypoint = child.GetComponent<Waypoint>();
            pedestrian.transform.position = child.position;

            yield return new WaitForEndOfFrame();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
