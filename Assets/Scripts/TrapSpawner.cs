using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    public static TrapSpawner Instance;
    public GameObject[] Traps;
    public Vector2[] TrapsPosition;
    public int randomTrapIndex;
    public float minSpawnTime = 2f;
    public float maxSpawnTime = 5f;

    

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(RandomSpawnTraps());
    }

    private IEnumerator RandomSpawnTraps()
    {
        while (Application.isPlaying)
        {
            if (GameManager.Instance.isGameActive == true)
            {
                int randomTrapIndex = Random.Range(0, Traps.Length);
                Vector2 randomTrapPosition = GetRandomVector();
                var trap = Instantiate(Traps[randomTrapIndex]).transform;
                trap.position = randomTrapPosition;

                yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime + 1));
            }
            else
            {
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Z));
            }
        }
    }

    Vector2 GetRandomVector()
    {
        int randomIndex = Random.Range(0, TrapsPosition.Length);

        return TrapsPosition[randomIndex];
    }
}
