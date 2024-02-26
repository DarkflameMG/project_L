using UnityEngine;
public class DamagePopup : MonoBehaviour
{

    [SerializeField] private GameObject pfDamagePopup;

    [SerializeField] private Vector2 InitialVelocity;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] float liftTime;

    private void Start() {
        rb.velocity = InitialVelocity;
        Destroy(gameObject, liftTime);
    }

}
