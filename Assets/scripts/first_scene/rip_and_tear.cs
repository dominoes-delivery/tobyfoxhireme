using UnityEngine;
using UnityEngine.SceneManagement;
public class rip_and_tear : MonoBehaviour
{
    
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        battlestats.Enemy = other.gameObject.name;
        SceneManager.LoadScene("fight",LoadSceneMode.Single);
    }
}
public static class battlestats
{
public static string Enemy = "";
public static int playerhealth = 50;
public static int maxhealth = 50;
}