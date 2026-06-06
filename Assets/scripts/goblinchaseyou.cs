using UnityEngine;

public class goblinchaseyou : MonoBehaviour
{

    public float speed;
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            Vector3 player_position = player.transform.position;
       Vector3 goblin_position = transform.position;
       Vector3 attack_direction = (player_position - goblin_position).normalized * speed * Time.deltaTime;
       transform.position = attack_direction + transform.position;
        }
    }
}
