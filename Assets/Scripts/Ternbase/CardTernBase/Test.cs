using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Transform pfDamagePopup;
    private void Start()
    {
        Transform damagePopupTransform = Instantiate(pfDamagePopup, Vector3.zero, Quaternion.identity);
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(300);
    }

}
