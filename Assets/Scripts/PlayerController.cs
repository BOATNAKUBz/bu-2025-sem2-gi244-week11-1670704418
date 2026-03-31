using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public Transform focalPoint;
<<<<<<< Updated upstream
    
=======

>>>>>>> Stashed changes
    private Rigidbody rb;

    private InputAction moveAction;
    private InputAction smashAction;
    private InputAction breakAction;

    public bool hasPowerup = false;
<<<<<<< Updated upstream
    


=======
>>>>>>> Stashed changes
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        moveAction = InputSystem.actions.FindAction("Move");
        smashAction = InputSystem.actions.FindAction("Smash");
        breakAction = InputSystem.actions.FindAction("Break");
    }

    // Update is called once per frame
    void Update()
    {
        var move = moveAction.ReadValue<Vector2>();
<<<<<<< Updated upstream
        rb.AddForce(move.y * speed * focalPoint.forward );
        if(breakAction.IsPressed())
        {
            rb.linearVelocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (hasPowerup == true)
            {
                var rb = collision.gameObject.GetComponent<Rigidbody>();
                var dir =collision.transform.position - transform.position;
               
                rb.AddForce(10 * dir.normalized, ForceMode.Impulse);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);

            if (countdownRoutine != null)
            {
                StopCoroutine(countdownRoutine);
            }
            countdownRoutine = StartCoroutine(PowerUpCountDown());
        }
    }

    private Coroutine countdownRoutine;
    IEnumerator PowerUpCountDown()
    {
        yield return new WaitForSeconds(10f);
        hasPowerup = false;
=======
        rb.AddForce(move.y * speed * focalPoint.forward);
        if (breakAction.IsInProgress())
        {
            rb.linearVelocity = Vector3.zero;
        }
>>>>>>> Stashed changes
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (hasPowerup)
            {
                Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 dir = collision.transform.position - transform.position;


                enemyRb.AddForce(5 * dir.normalized, ForceMode.Impulse);

                Destroy(collision.gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);

            if (coundownRoutine != null)
            {
                StopCoroutine(coundownRoutine);
            }
            coundownRoutine = StartCoroutine(PowerUpCountDown());
        }
    }

    private Coroutine coundownRoutine;
    IEnumerator PowerUpCountDown()
    {
        yield return new WaitForSeconds(5);
        hasPowerup = false;
    }
}