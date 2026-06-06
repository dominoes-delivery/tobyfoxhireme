using UnityEngine;

public class squarify : MonoBehaviour
{
    public float targetwidth;
    public RectTransform t;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       makesquare(); 
    }
    void makesquare()
    {
        //Debug.Log((t.sizeDelta.x - targetwidth));
        if(t.sizeDelta.x - targetwidth <= 0)
        {
            return;
        }
        t.sizeDelta = new Vector2(t.sizeDelta.x - (targetwidth/(speed*Time.deltaTime)), t.sizeDelta.y);
    }
}
