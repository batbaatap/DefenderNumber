using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { set; get; }
    public Vector3[] SpawnPositions;
    public GameObject EnemyPrefab;
    public List<GameObject> EnemyList = new List<GameObject>();
    public float SpawnTime;
    public float BirthTime;

    int LvlValue = 3;
    public string counti = "counti";

    public GameObject Coin;

    // private GameObject EnemyNumber;

    // Use this for initialization
    void Start()
    {
        Spawn();
        Coin.GetComponent<TextMesh>().text = PlayerPrefs.GetInt(counti).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // EnemyNumber = GameObject.Find("EnemyNumber");

        // int rr = Random.Range(0,180);
        if (Time.time > SpawnTime)
        {
            Spawn();
            SpawnTime = Time.time + BirthTime;
        }

        for (int i = 0; i < EnemyList.Count; i++)
        {
            if (EnemyList[i] == null)
            {
                EnemyList.RemoveAt(i);

                PlayerPrefs.SetInt(counti, PlayerPrefs.GetInt("counti") + 1);

            	Coin.GetComponent<TextMesh>().text = PlayerPrefs.GetInt(counti).ToString();
                PlayerPrefs.Save();

            }
            else if (EnemyList.Count < 2)
            {
                Spawn();
            }
        }
    }

    void Spawn()
    {
        int RandomRange = Random.Range(0, SpawnPositions.Length);
        int EnemiesLength = Random.Range(0, LvlValue);
        
        // EnemyNumber.GetComponent<TextMesh>().text = EnemiesLength.ToString();
        
        GameObject enemyObj = Instantiate(EnemyPrefab, SpawnPositions[RandomRange], transform.rotation);

        EnemyList.Add(enemyObj);
    }

    public void ResetPrefs(){
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void Pause(){
        Time.timeScale = 0;
    }

     public void Resume(){
        Time.timeScale = 1;
    }
}
