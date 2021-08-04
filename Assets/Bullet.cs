using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int BulletVal;
    public float speed;
    private Rigidbody2D rigidbody;
    Vector2 _direction;
    bool isReady;

    // public Transform sparkle;
    void Awake()
    {
        isReady = false;
    }

    // Use this for initialization
    void Start()
    {
        // GameObject EnemySpawner = GameObject.Find("EnemySpawner");
        // OenemySpawner = EnemySpawner;
        
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;
        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady)
        {
            //get the bullet's current position
            Vector2 position = transform.position;

            //compute the bullet's new position
            position += _direction * speed * Time.deltaTime;

            //update the bullet's position
            transform.position = position;


            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            if( (transform.position.x < min.x) || (transform.position.x > max.x) || (transform.position.y < min.y) || (transform.position.y > max.y)) 
            {
                Destroy(gameObject);
            }
        }

        // GameObject Gun1 = GameObject.Find("Gun1");
        // string Gun1TextValue = Gun1.GetComponentInChildren<TextMesh>().text;
        // BulletVal = int.Parse(Gun1TextValue);
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponentInChildren<TextMesh>().text != null){
            int Expression = int.Parse(other.gameObject.GetComponentInChildren<TextMesh>().text) - BulletVal;
            other.gameObject.GetComponentInChildren<TextMesh>().text = Expression.ToString();
        }
        Destroy(this.gameObject);
    }

}
