using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private float speed = 2.5f;
    string textNumberString;
    int EnemyNumber, RandomValue;
    public GameObject sparkle;

    // public GameObject Particle;
    int lvlVal;

    // GameObject ff;
    // string ss;
    void Awake()
    {
        while (true)
        {
            if (Time.time > 3)
            {
                lvlVal = 2;
                print(Time.time);
            }
            if (Time.time > 10)
            {
                lvlVal = 3;
                print(Time.time);
            }
            if (Time.time > 20)
            {
                lvlVal = 4;
                print(Time.time);
            }
            if (Time.time > 30)
            {
                lvlVal = 5;
                print(Time.time);
            }
            if (Time.time > 40)
            {
                lvlVal = 6;
                print(Time.time);
            }
            if (Time.time > 50)
            {
                lvlVal = 7;
                print(Time.time);
            }
            if (Time.time > 60)
            {
                lvlVal = 8;
                print(Time.time);
            }
            if (Time.time > 70)
            {
                lvlVal = 9;
                print(Time.time);
            }
            if (Time.time > 80)
            {
                lvlVal = 10;
                print(Time.time);
            }
            break;
        }
    }
	
    // Use this for initialization
    void Start()
    {
        RandomValue = Random.Range(1, lvlVal);
        GetComponentInChildren<TextMesh>().text = RandomValue.ToString();
		// GetComponent<ParticleSystem>().enableEmission = false;
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, -speed * Time.deltaTime, 0);

        EnemyNumber = int.Parse(GetComponentInChildren<TextMesh>().text);

        if (EnemyNumber < 1)
        {

            Destroy(this.gameObject);
            Instantiate(sparkle, transform.position, Quaternion.identity);
                        
            // ParticleSystem ps = GetComponent<ParticleSystem>();
            // var em = ps.emission;
            // em.enabled = true;

            // StartCoroutine(stopSparkles());

			// Particle  = (GameObject)Instantiate(Particle);
            // Particle.transform.position = transform.position; 
        }
    }

    // IEnumerator stopSparkles()
    // {
    //     yield return new WaitForSeconds(.3f);
    //     // GetComponent<ParticleSystem>().enableEmission = false;
    //     ParticleSystem ps = GetComponent<ParticleSystem>();
    //         var em = ps.emission;
    //         em.enabled = false;

    // }

    void OnMouseDown()
    {
        EnemyNumber = EnemyNumber - 1;
        GetComponentInChildren<TextMesh>().text = EnemyNumber.ToString();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "destroyer")
        {
            // Destroy(this.gameObject);
            // print("Game Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
