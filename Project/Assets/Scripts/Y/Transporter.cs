using UnityEngine;

public class Transporter : MonoBehaviour
{
    PlayerController player;
    [SerializeField] float speed;
    bool n = false;



    private void Awake()
    {

        Invoke("ReferencePlayer", 0.01f);
    }
    private void ReferencePlayer() => player = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            n = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            n = false;
        }
    }
    private void Update()
    {
        if (n)
            player.GetComponent<Rigidbody2D>().AddForce(Vector2.left * speed);
       
    }



}
