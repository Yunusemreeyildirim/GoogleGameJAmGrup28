using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    [SerializeField] private Text Ans;
    [SerializeField] private string correctPassword = "123456"; // Do�ru �ifre
    
    [SerializeField] private GameObject keypadPanel;
    [SerializeField] private GameObject doorToOpen;
    public Animator doorAnimator;


    public void Number(int number)
    {
        if (Ans.text.Length < 6)
        {
            Ans.text += number.ToString();
        }
    }
    void Start()
    {
        if (doorToOpen != null)
        {
            doorAnimator = doorToOpen.GetComponent<Animator>();
        }
    }

    void Update()
    {
        // E�er bir �ekilde animator null olursa tekrar al
        if (doorAnimator == null && doorToOpen != null)
        {
            doorAnimator = doorToOpen.GetComponent<Animator>();
        }
    }

    public void Clear()
    {
        Ans.text = "";
    }

    public void Enter()
    {
        if (Ans.text == correctPassword)
        {
            Debug.Log("Do�ru �ifre!");
            OpenDoor(); // Burada kap� a��labilir
            keypadPanel.SetActive(false);
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Debug.Log("Yanl�� �ifre");
            StartCoroutine(ShowWrongCode());
        }
    }

    void OpenDoor()
    {
        if (doorAnimator != null)
        {
            if (correctPassword=="847540")
            {
                doorAnimator.SetTrigger("doorOpen"); // Animator'daki "Open" trigger'�n� tetikle
            }
            if (correctPassword == "13698")
            {
                doorAnimator.SetTrigger("isRock");
            }
             // Animator'daki "Open" trigger'�n� tetikle
        }

    }
    private IEnumerator ShowWrongCode()
    {
        Ans.text = "Hatal� �ifre";
        yield return new WaitForSecondsRealtime(1f);
        Clear();
    }
    public void ExitKeypad()
    {
        keypadPanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}