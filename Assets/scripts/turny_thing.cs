using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class turny_thing : MonoBehaviour
{
    public static turny_thing Instance
    {
        get { return instance; }
    }
    private static turny_thing instance;

    public bool isWin;

    [SerializeField] private Slider enemyHealthBar;
    public Image enemyHealthBarImage;
    [SerializeField] private TMP_Text enemyHealthText;
    private int enemyHealthStart = 10;
    private int enemyHealth;

    [SerializeField] private Slider playerHealthBar;
    public Image playerHealthBarImage;
    [SerializeField] private TMP_Text playerHealthText;
    private int playerHealthStart = 3;
    private int playerHealth;

    private int eggsPerTurn = 10;
    private int currentEggs = 0;

    private float timer = 0;
    private float spawnTimeThreshold = 0.5f;

    public GameObject player;

    public static bool PlayerTurn = false;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);

        if (enemyHealthStart <= 0) enemyHealthStart = 1;
        if (playerHealthStart <= 0) playerHealthStart = 1;
        enemyHealth = enemyHealthStart;
        playerHealth = playerHealthStart;
        enemyHealthBar.maxValue = enemyHealthStart;
        playerHealthBar.maxValue = playerHealthStart;

        SetEnemyHealth(enemyHealth);
        SetPlayerHealth(playerHealth);
    }

    void Update()
    {
        if (currentEggs >= eggsPerTurn)
        {
            currentEggs = 0;
            PlayerTurn = true;
        }

        if (!PlayerTurn)
        {
            timer += Time.deltaTime;
            if (timer > spawnTimeThreshold) {
                EggSpawner.Instance.SpawnEgg();
                currentEggs++;
                timer = 0.0f;
            }
        }

        // Bar color
        if (enemyHealth > enemyHealthStart)
        {
            enemyHealthBarImage.color = Color.yellow;
        }
        else
        {
            enemyHealthBarImage.color = Color.red;
        }
        if (playerHealth > playerHealthStart)
        {
            playerHealthBarImage.color = Color.yellow;
        }
        else
        {
            playerHealthBarImage.color = Color.green;
        }


        // Win condition
        if (enemyHealth <= 0)
        {
            // Win
            isWin = true;
            SceneManager.LoadScene("end",LoadSceneMode.Single);
        }
        else if (playerHealth <= 0)
        {
            // Lose
            isWin = false;
            SceneManager.LoadScene("end",LoadSceneMode.Single);
        }
    }

    public int GetEnemyHealth()
    {
        return enemyHealth;
    }
    public void SetEnemyHealth(int health)
    {
        enemyHealth = health;
        enemyHealthBar.value = enemyHealth;
        enemyHealthText.text = enemyHealth.ToString();
    }

    public int GetPlayerHealth()
    {
        return playerHealth;
    }
    public void SetPlayerHealth(int health)
    {
        playerHealth = health;
        playerHealthBar.value = health;
        playerHealthText.text = playerHealth.ToString();
    }
}