using UnityEngine;

// RESPONSIBILITY
// Handles the player movement

// USED BY:
// Player GameObject
// PlayerInput scirpt

public class PlayerMovement : MonoBehaviour
{
    #region Cached References

    #endregion

    [SerializeField] float speed = 10f;

    public void Move(Vector3 position)
    {
        transform.position += position * speed * Time.deltaTime;
    }

}
