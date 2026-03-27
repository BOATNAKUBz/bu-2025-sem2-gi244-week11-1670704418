using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemyPrefab;

    //public Rigidbody box;


    void Start()
    {
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
    }
}
