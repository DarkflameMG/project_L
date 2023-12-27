using UnityEngine;
using TMPro;
public class DamagePopup : MonoBehaviour
{

    // public static DamagePopup Create(){
    //     Transform damagePopupTransform = Instantiate(pfDamagePopup, Vector3.zero, Quaternion.identity);
    //     DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
    //     damagePopup.Setup(350);
    // }

    private TextMeshPro textMesh;

    private void Awake() {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    public void Setup(int damageAmount){
        textMesh.SetText(damageAmount.ToString());
    }
}
