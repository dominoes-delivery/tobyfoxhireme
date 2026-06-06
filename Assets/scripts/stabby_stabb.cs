//10101101010010100101010110101010010010011101001010101011101100101010101010101010101
using UnityEngine;
using UnityEngine.UI;
public class stabby_stab : MonoBehaviour
{
    // Does all the button stuff

    public GameObject sword;
    public Button fightButton;
    
    public Button mercyButton;

    public Button actButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        actButton.onClick.AddListener(onclick_act);
        fightButton.onClick.AddListener(onclick_fight);
        mercyButton.onClick.AddListener(onclick_mercy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void onclick_act()
    {
        if (turny_thing.PlayerTurn)
        {
            // Random damage
            System.Random random = new System.Random();
            int chance = random.Next(0, 10);
            if (chance < 5)
            {
                soundscripteroo.SoundInstance.Play(soundscripteroo.SoundInstance.bossHurtClip);
                turny_thing.Instance.SetEnemyHealth(turny_thing.Instance.GetEnemyHealth() - 3);
            }
            else
            {
                soundscripteroo.SoundInstance.Play(soundscripteroo.SoundInstance.screamClip);
                turny_thing.Instance.SetPlayerHealth(turny_thing.Instance.GetPlayerHealth() - 1);
            }
            turny_thing.PlayerTurn = false;
        }
    }
    public void onclick_mercy()
    {
        if (turny_thing.PlayerTurn)
        {
            // Random Health
            System.Random random = new System.Random();
            int chance = random.Next(0, 10);
            if (chance < 5) turny_thing.Instance.SetEnemyHealth(turny_thing.Instance.GetEnemyHealth() + 3);
            else turny_thing.Instance.SetPlayerHealth(turny_thing.Instance.GetPlayerHealth() + 1);
            soundscripteroo.SoundInstance.Play(soundscripteroo.SoundInstance.healthClip);
            turny_thing.PlayerTurn = false;
        }
    }
    public void onclick_fight()
    {
        if (turny_thing.PlayerTurn)
        {
            Instantiate(sword, new Vector2(-15, 5), Quaternion.Euler(0, 0, -50));
            soundscripteroo.SoundInstance.Play(soundscripteroo.SoundInstance.bossHurtClip);
            turny_thing.Instance.SetEnemyHealth(turny_thing.Instance.GetEnemyHealth() - 1);
            turny_thing.PlayerTurn = false;
        }
    }
}