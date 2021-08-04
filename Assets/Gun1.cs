using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun1 : MonoBehaviour
{
    public GameObject CloneBullet;
    public GameObject DamageNumber;
    private Rigidbody2D rigidbody;
    float SpawnTime;
    public float TimeToSpeed;
    // public GameObject OenemySpawner;
    private GameObject EnemyObject;

    public GameObject TotalCoin;
    public GameObject GunCoin;

    internal int CoinValueInt;
    private GameObject EnemySpawner;

    int tcVal,  countVal,  c, Rand;

    internal string GunDamage1 = "GunDamage1";
    internal string gcVal1 = "gcVal1";

    internal GameObject bullet1;
   
    void Awake()
    {
        if(PlayerPrefs.GetInt(GunDamage1) == 0 && PlayerPrefs.GetInt(gcVal1) == 0){
            PlayerPrefs.SetInt(GunDamage1, 1);
            PlayerPrefs.SetInt(gcVal1, 10);
        } else {
            PlayerPrefs.SetInt(GunDamage1, PlayerPrefs.GetInt(GunDamage1));
            PlayerPrefs.SetInt(gcVal1, PlayerPrefs.GetInt(gcVal1));
        }

        CloneBullet.GetComponent<Bullet>().BulletVal = PlayerPrefs.GetInt(GunDamage1);
    }

    // Use this for initialization
    void Start()
    {
        EnemySpawner = GameObject.Find("EnemySpawner");
        
        rigidbody = GetComponent<Rigidbody2D>();
        // InvokeRepeating("FireEnemyBullet", 0, 1);
        
        DamageNumber.GetComponent<TextMesh>().text = PlayerPrefs.GetInt(GunDamage1).ToString();

        GunCoin.GetComponent<TextMesh>().text = PlayerPrefs.GetInt(gcVal1).ToString();
    }

    // Update is called once per frame
    void Update()
    {

        CloneBullet.GetComponent<Bullet>().BulletVal = PlayerPrefs.GetInt(GunDamage1);
        

        if (PlayerPrefs.GetInt("counti") > int.Parse(GunCoin.GetComponent<TextMesh>().text))
        {
            GunCoin.GetComponent<TextMesh>().color = Color.red;
        } else {
            GunCoin.GetComponent<TextMesh>().color = Color.black;
        }

        if(bullet1 == null)
        {
            FireEnemyBullet();
        }
        
        Rand = Random.Range(0, 2);
        // Vector2 dir = nearestEnemy.transform.position - this.transform.position;

        

        // int Rand = Random.Range(0, 2);
        // Vector3 direction2 = EnemySpawner.GetComponent<EnemySpawner>().EnemyList[0].transform.position - this.transform.position;
        // print("direction2" + direction2);

        
        
        // Quaternion lookRok = Quaternion.LookRotation(direction2);
        // print("lookrok" + lookRok);



        // this.transform.rotation = Quaternion.Euler(0, 0, lookRok.z);



        // Vector3 relativePos = EnemySpawner.GetComponent<EnemySpawner>().EnemyList[0].transform.position - transform.position;
        // Quaternion rotation = Quaternion.LookRotation(relativePos);
        // transform.rotation =  rotation;

        //    var newRotation = Quaternion.LookRotation(transform.position - EnemySpawner.GetComponent<EnemySpawner>().EnemyList[0].transform.position, Vector3.forward);
        // newRotation.x = 0.0f;
        // newRotation.y = 0.0f;
        // transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 8);

    }

    void FireEnemyBullet()
    {
        if (EnemySpawner.GetComponent<EnemySpawner>().EnemyList[0] != null )
        {
            bullet1 = (GameObject)Instantiate(CloneBullet);
            bullet1.transform.position = transform.position;

            Vector2 direction = EnemySpawner.GetComponent<EnemySpawner>().EnemyList[Rand].transform.position 
                                                                        - bullet1.transform.position;

            bullet1.GetComponent<Bullet>().SetDirection(direction);
        }
    }

    void OnMouseDown()
    {
        if (PlayerPrefs.GetInt("counti") > int.Parse(GunCoin.GetComponent<TextMesh>().text))
        {
            PlayerPrefs.SetInt(GunDamage1, int.Parse(DamageNumber.GetComponent<TextMesh>().text)+1);
            // GunDamage = int.Parse(DamageNumber.GetComponent<TextMesh>().text);
            // GunDamage += 1;
            DamageNumber.GetComponent<TextMesh>().text = PlayerPrefs.GetInt(GunDamage1).ToString();




            c = PlayerPrefs.GetInt("counti") - int.Parse(GunCoin.GetComponent<TextMesh>().text);   
            PlayerPrefs.SetInt("counti", c);




            PlayerPrefs.SetInt(gcVal1, int.Parse(GunCoin.GetComponent<TextMesh>().text) + 10);
            PlayerPrefs.Save();
            GunCoin.GetComponent<TextMesh>().text = PlayerPrefs.GetInt(gcVal1).ToString();
        }
    }

}
