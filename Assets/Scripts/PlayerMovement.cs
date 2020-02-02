using UnityEngine;

// RESPONSIBILITY
// Handles the player movement

// USED BY:
// Player GameObject
// PlayerInput scirpt

public class PlayerMovement : MonoBehaviour
{
    #region Cached References

    private Rigidbody rb;

    #endregion

    [SerializeField] float speed = 100f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();   
    }

    public void Move(Vector3 position)
    {
        rb.MovePosition(position * speed * Time.fixedDeltaTime);
    }

}
