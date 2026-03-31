using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody rb;
    private GameObject Player;

<<<<<<< Updated upstream
    void Start()
    {

=======
    private bool isStunned = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Player = GameObject.FindWithTag("Player");
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream

    }
}
=======
        if (isStunned) return;

        if (Player != null)
        {
            Vector3 dir = (Player.transform.position - transform.position).normalized;
            rb.AddForce(dir * speed);
        }
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    public void Stun(float duration)
    {
        StopAllCoroutines(); 
        StartCoroutine(StunCoroutine(duration));
    }

    IEnumerator StunCoroutine(float duration)
    {
        isStunned = true;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        yield return new WaitForSeconds(duration);

        isStunned = false;
    }
}
>>>>>>> Stashed changes
