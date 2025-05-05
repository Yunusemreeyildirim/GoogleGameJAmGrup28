using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerNesne : MonoBehaviour
{
    [SerializeField] private Transform transformPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") )
        {
            CharacterController controller = other.GetComponent<CharacterController>();
            if (controller != null)
            {
                Debug.Log("de�di");

                // I��nlama i�lemi
                controller.enabled = false;
                controller.transform.position = transformPoint.position;  // Hedef noktaya ���nla
                controller.enabled = true;
            }
            
        }
        
    }
}
