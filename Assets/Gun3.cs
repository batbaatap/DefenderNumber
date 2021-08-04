using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun3 : MonoBehaviour
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

    internal string GunDamage3 = "GunDamage3";
    internal string gcVal3 = "gcVal3";

    internal GameObject bullet3;

    void Awake()
    {
        if(PlayerPrefs.GetInt(GunDamage3) == 0 && PlayerPrefs.GetInt(gcVal3) == 0){
            PlayerPrefs.SetInt(GunDamage3, 1);
            PlayerPrefs.SetInt(gcVal3, 10);
        } else {
            PlayerPrefs.SetInt(GunDamage3, PlayerPrefs.GetInt(GunDamage3));
            PlayerPrefs.SetInt(gcVal3, PlayerPrefs.GetInt(gcVal3));
        }   

        CloneBullet.GetComponent<Bullet>().BulletVal = PlayerPrefs.GetInt(GunDamage3);       
    }
    // Use this for initialization
    void Start()
    {
        EnemySpawner = GameObject.Find("EnemySpawner");
        
        rigidbody = GetComponent<Rigidbody2D>();
        // InvokeRepeating("FireEnemyBullet", 0, 1);

        DamageNumber.GetComponent<TextMesh>().text = PlayerPrefs.GetInt(GunDamage3).ToString();

        GunCoin.GetComponent<TextMesh>().text = PlayerPrefs.GetInt(gcVal3).ToString();
    }

    // Update is called once per frame
    void Update()
    {

        CloneBullet.GetComponent<Bullet>().BulletVal = PlayerPrefs.GetInt(GunDamage3);

        if (PlayerPrefs.GetInt("counti") > int.Parse(GunCoin.GetComponent<TextMesh>().text))
        {
            GunCoin.GetComponent<TextMesh>().color = Color.red;
        } else {
            GunCoin.GetComponent<TextMesh>().color = Color.black;
        }

        if(bullet3 == null)
        {
            FireEnemyBullet();
        } 

        Rand = Random.Range(0, 2);


        //  var newRotation = Quaternion.LookRotation(transform.position - EnemySpawner.GetComponent<EnemySpawner>().EnemyList[0].transform.position, Vector3.forward);
        // newRotation.x = 0.0f;
        // newRotation.y = 0.0f;
        // transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 8); 
    }

    void FireEnemyBullet()
    {
        if (EnemySpawner.GetComponent<EnemySpawner>().EnemyList[0] != null)
        {
            bullet3 = (GameObject)Instantiate(CloneBullet);
            bullet3.transform.position = transform.position;

            Vector2 direction = EnemySpawner.GetComponent<EnemySpawner>().EnemyList[Rand].transform.position - bullet3.transform.position;

            bullet3.GetComponent<Bullet>().SetDirection(direction);
        }
    }

    void OnMouseDown()
    {
        if (PlayerPrefs.GetInt("counti") > int.Parse(GunCoin.GetComponent<TextMesh>().text))
        {
            PlayerPrefs.SetInt(GunDamage3, int.Parse(DamageNumber.GetComponent<TextMesh>().text)+1);
            // GunDamage = int.Parse(DamageNumber.GetComponent<TextMesh>().text);
            // GunDamage += 1;
            DamageNumber.GetComponent<TextMesh>().text = PlayerPrefs.GetInt(GunDamage3).ToString();



            
            c = PlayerPrefs.GetInt("counti") - int.Parse(GunCoin.GetComponent<TextMesh>().text);   
            PlayerPrefs.SetInt("counti", c);




            PlayerPrefs.SetInt(gcVal3, int.Parse(GunCoin.GetComponent<TextMesh>().text) + 10);
            PlayerPrefs.Save();
            GunCoin.GetComponent<TextMesh>().text = PlayerPrefs.GetInt(gcVal3).ToString();
        }
    }

}
