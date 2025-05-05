using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;         // Hedef nokta
    public float teleportCooldown = 5f;      // Bekleme süresi

    private float lastTeleportTime = -Mathf.Infinity;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Time.time >= lastTeleportTime + teleportCooldown)
        {
            // Eðer player bir karakter controller'a sahipse
            CharacterController controller = other.GetComponent<CharacterController>();
            if (controller != null)
            {
                Debug.Log("deðdi");

                // Iþýnlama iþlemi
                controller.enabled = false;
                controller.transform.position = teleportTarget.position;  // Hedef noktaya ýþýnla
                Vector3 currentRotation = controller.transform.rotation.eulerAngles;
                currentRotation.y += 180f; // Y ekseninde 180 derece döndür
                controller.transform.rotation = Quaternion.Euler(currentRotation);
                controller.enabled = true;

                // Son ýþýnlanma zamanýný güncelle
                lastTeleportTime = Time.time;
            }
        }
    }
}
