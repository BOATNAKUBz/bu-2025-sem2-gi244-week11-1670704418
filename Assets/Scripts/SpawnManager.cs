using System.Collections;
<<<<<<< Updated upstream
=======
using System.Collections.Generic;
>>>>>>> Stashed changes
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;

    public Transform[] spawnPoints;

    public Wave[] waves;

    //public Rigidbody box;


    void Start()
    {
<<<<<<< Updated upstream
        StartCoroutine(Spawnroutine());
        //InvokeRepeating(nameof (RandomSpaawm),0 , 5 );

        //StartCoroutine(Hello());

        //StartCoroutine(MoveBox());

        //goodByeRoutine = StartCoroutine(Goodbye());
    }

    IEnumerator Spawnroutine()
    {
        while (true)
        {
            RandomSpawn();
            yield return new WaitForSeconds(3);
        }

        void RandomSpawn()
        {
            var index = Random.Range(0, spawnPoints.Length);
            var spawnPoin = spawnPoints[index];
            Instantiate(enemyPrefab, spawnPoin);
        }

        // private void Update()
        //  {
        // if (Time.time > 5)
        // {
        //     StopCoroutine(goodByeRoutine);s

        //   }
        // }
        // IEnumerator Goodbye()
        // {
        //   while (true)
        //   {
        // Debug.Log("GoodBye" + Time.frameCount + " " + Time.time);
        //       yield return null;

        //}
        //}
        /*IEnumerator MoveBox()
        {
            box.linearVelocity = 10 * Vector3.up;
            yield return null; new WaitForSeconds(3);
            box.linearVelocity = 10 * Vector3.right;
            yield return null; new WaitForSeconds(3);
            box.linearVelocity = 10 * Vector3.down;
            yield return null; new WaitForSeconds(3);
            box.linearVelocity = 10 * Vector3.left;
            yield return null; new WaitForSeconds(3);

        }


        IEnumerator Hello()
        {
            Debug.Log("Hello" + Time.frameCount);
            yield return null;
        }*/
=======
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waves.Length; i++)
        {
            Wave w = waves[i];

            Debug.Log("Wave " + (i + 1));

            // spawn powerup ก่อน
            for (int j = 0; j < w.numberOfPowerUp; j++)
            {
                Transform p = spawnPoints[Random.Range(0, spawnPoints.Length)];

                Instantiate(powerUpPrefab, p.position, Quaternion.identity);

            }

            // รอก่อนเริ่ม spawn
            yield return new WaitForSeconds(w.delayStart);

            // สุ่ม spawn point
            List<Transform> usePoints = new List<Transform>();

            while (usePoints.Count < w.numberOfRandomSpawnPoint)
            {
                Transform p = spawnPoints[Random.Range(0, spawnPoints.Length)];

                if (!usePoints.Contains(p))
                {
                    usePoints.Add(p);
                }
            }

            // spawn enemy ทีละตัว
            for (int j = 0; j < w.totalSpawnEnemies; j++)
            {
                Transform spawn = usePoints[Random.Range(0, usePoints.Count)];

                Instantiate(enemyPrefab, spawn.position, Quaternion.identity);

                yield return new WaitForSeconds(w.spawnInterval);
            }

            // รอให้ enemy หมดก่อน wave ต่อไป
            yield return new WaitUntil(() =>
                GameObject.FindGameObjectsWithTag("Enemy").Length == 0
            );
        }

        Debug.Log("Finish All Waves");
>>>>>>> Stashed changes
    }
}
