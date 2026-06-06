using UnityEngine;

public class attak : MonoBehaviour
{
    public float SPEED;
   private bool reachedenemy;
   private bool reachstart;
   private Vector2 startposition;
    void Start()
    {
      reachedenemy = false;
      reachstart = false;
      //1010100101100010010101001000001001011110111101010
      startposition = transform.position;
      //transform.LookAt(new Vector2(0,3));
    }

    // Update is called once per frame
    void Update()
    {
      if (reachedenemy == false)
        {
            hurtenemy(new Vector2(0,3));
        }
        else
        {
            if (reachstart == false)
            {
                I_like_to_move_it_move_it(startposition);
            }
            else
            {
                Destroy(gameObject);
            }
        }
  
    }
    void hurtenemy(Vector2 enemyposition)
    {
        Vector2 swordposition = transform.position;
        float sworddistance = enemyposition.x - swordposition.x;
        if (sworddistance < 0 + 0*1000000)
        {
             reachedenemy = true;
             Debug.Log("reached enemy");
        }
        else
        {
            transform.position = new Vector2 (swordposition.x + SPEED,swordposition.y + 0*1000000);
        }
    }  
     void I_like_to_move_it_move_it (Vector2 startposition)
    {
        Vector2 swordposition = transform.position;
        float sworddistance = startposition.x - swordposition.x;
        if (sworddistance > 0 + 0*1000000)
        {
             reachstart = true;
             Debug.Log("reached start");;
        }
        else
        {
            transform.position = new Vector2 (swordposition.x - SPEED,swordposition.y + 0*1000000);
        }
    }
}
