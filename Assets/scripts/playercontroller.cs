using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
[SerializeField] private GameObject squareBoundBox;

    public PlayerInput playerInput;
    public int playerlives;
    public int maxplayerlives;
    public Rigidbody2D rigidBody;
    public Collider2D interactionCollider;
    public float speed;

    InputAction moveAction;
    InputAction interactAction;

    Vector2 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find the references to the "Move" and "Interact" actions
        moveAction = InputSystem.actions.FindAction("Move");
        interactAction = InputSystem.actions.FindAction("Interact");
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        // Movement code
        Vector2 moveValue = moveAction.ReadValue<Vector2>().normalized;
        //Debug.Log(moveValue);
        rigidBody.linearVelocity = moveValue * speed;

        BoundPlayer();

    }
    void BoundPlayer()
    {
        float widthThreshold = squareBoundBox.transform.localScale.x * 1.5f;
        float heightThreshold = squareBoundBox.transform.localScale.y * 1.5f;
        if (transform.position.x < -widthThreshold) transform.position = new Vector3(-widthThreshold, transform.position.y, transform.position.z);
        else if (transform.position.x > widthThreshold) transform.position = new Vector3(widthThreshold, transform.position.y, transform.position.z);
        if (transform.position.y < -heightThreshold) transform.position = new Vector3(transform.position.x, -heightThreshold, transform.position.z);
        else if (transform.position.y > heightThreshold) transform.position = new Vector3(transform.position.x, heightThreshold, transform.position.z);
    }

    public bool isInteractPressed()
    {
        //Debug.Log("Player Controller interactAction.IsPressed is " + interactAction.IsPressed());
        return interactAction.IsPressed();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        soundscripteroo.SoundInstance.Play(soundscripteroo.SoundInstance.screamClip);
        turny_thing.Instance.SetPlayerHealth(turny_thing.Instance.GetPlayerHealth() - 1);
    }
}
