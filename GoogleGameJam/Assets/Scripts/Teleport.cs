using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;         // Hedef nokta
    public float teleportCooldown = 5f;      // Bekleme s�resi

    private float lastTeleportTime = -Mathf.Infinity;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Time.time >= lastTeleportTime + teleportCooldown)
        {
            // E�er player bir karakter controller'a sahipse
            CharacterController controller = other.GetComponent<CharacterController>();
            if (controller != null)
            {
                Debug.Log("de�di");

                // I��nlama i�lemi
                controller.enabled = false;
                controller.transform.position = teleportTarget.position;  // Hedef noktaya ���nla
                Vector3 currentRotation = controller.transform.rotation.eulerAngles;
                currentRotation.y += 180f; // Y ekseninde 180 derece d�nd�r
                controller.transform.rotation = Quaternion.Euler(currentRotation);
                controller.enabled = true;

                // Son ���nlanma zaman�n� g�ncelle
                lastTeleportTime = Time.time;
            }
        }
    }
}
