using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float phase;
    public GameObject explosion;
    private GameControllerScript gameController;

    // Start is called before the first frame update
    void Start()
    {
        phase = Random.Range(0f, Mathf.PI * 2);
        gameController = GameObject.FindWithTag("GameController")
            .GetComponent<GameControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(
            Mathf.Cos(Time.frameCount*0.005f+phase)*0.005f,
            -2f * Time.deltaTime,
            0f

         );
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            gameController.AddScore(10);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            gameController.GameOver();
            Instantiate(explosion, transform.position, transform.rotation);
            Instantiate(explosion, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
