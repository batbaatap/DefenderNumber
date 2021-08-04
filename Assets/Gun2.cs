using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun2 : MonoBehaviour
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

    internal string GunDamage2 = "GunDamage2";
    internal string gcVal2 = "gcVal2";
    
    internal GameObject bullet2;
    
    void Awake()
    {
        if(PlayerPrefs.GetInt(GunDamage2) == 0 && PlayerPrefs.GetInt(gcVal2) == 0){
            PlayerPrefs.SetInt(GunDamage2, 1);
            PlayerPrefs.SetInt(gcVal2, 10);
        } else {
            PlayerPrefs.SetInt(GunDamage2, PlayerPrefs.GetInt(GunDamage2));
            PlayerPrefs.SetInt(gcVal2, PlayerPrefs.GetInt(gcVal2));
        }    

        CloneBullet.GetComponent<Bullet>().BulletVal = PlayerPrefs.GetInt(GunDamage2);
    }
    // Use this for initialization
    void Start()
    {
        EnemySpawner = GameObject.Find("EnemySpawner");
        
        rigidbody = GetComponent<Rigidbody2D>();
        // InvokeRepeating("FireEnemyBullet", 0, 1);

        DamageNumber.GetComponent<TextMesh>().text = PlayerPrefs.GetInt(GunDamage2).ToString();

        GunCoin.GetComponent<TextMesh>().text = PlayerPrefs.GetInt(gcVal2).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        CloneBullet.GetComponent<Bullet>().BulletVal = PlayerPrefs.GetInt(GunDamage2);

        if (PlayerPrefs.GetInt("counti") > int.Parse(GunCoin.GetComponent<TextMesh>().text))
        {
            GunCoin.GetComponent<TextMesh>().color = Color.red;
        } else {
            GunCoin.GetComponent<TextMesh>().color = Color.black;
        }

        if(bullet2 == null)
        {
            FireEnemyBullet();
        }  

        Rand = Random.Range(0, 2);

        // var newRotation = Quaternion.LookRotation(transform.position - EnemySpawner.GetComponent<EnemySpawner>().EnemyList[0].transform.position, Vector3.forward);
        // newRotation.x = 0.0f;
        // newRotation.y = 0.0f;
        // transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 8);
    }

    void FireEnemyBullet()
    {
        if (EnemySpawner.GetComponent<EnemySpawner>().EnemyList[0] != null)
        {
            bullet2 = (GameObject)Instantiate(CloneBullet);
            bullet2.transform.position = transform.position;

            Vector2 direction = EnemySpawner.GetComponent<EnemySpawner>().EnemyList[Rand].transform.position - bullet2.transform.position;

            bullet2.GetComponent<Bullet>().SetDirection(direction);
        }
    }

    void OnMouseDown()
    {
        if (PlayerPrefs.GetInt("counti") > int.Parse(GunCoin.GetComponent<TextMesh>().text))
        {
            PlayerPrefs.SetInt(GunDamage2, int.Parse(DamageNumber.GetComponent<TextMesh>().text)+1);
            // GunDamage = int.Parse(DamageNumber.GetComponent<TextMesh>().text);
            // GunDamage += 1;
            DamageNumber.GetComponent<TextMesh>().text = PlayerPrefs.GetInt(GunDamage2).ToString();



            
            c = PlayerPrefs.GetInt("counti") - int.Parse(GunCoin.GetComponent<TextMesh>().text);   
            PlayerPrefs.SetInt("counti", c);




            PlayerPrefs.SetInt(gcVal2, int.Parse(GunCoin.GetComponent<TextMesh>().text) + 10);
            PlayerPrefs.Save();
            GunCoin.GetComponent<TextMesh>().text = PlayerPrefs.GetInt(gcVal2).ToString();
        }
    }

}
