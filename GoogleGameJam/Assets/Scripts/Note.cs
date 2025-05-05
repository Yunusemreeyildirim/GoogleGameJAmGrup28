using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    public float rayDistance = 3f;
    public LayerMask noteLayer;
    public LayerMask keyLayer;
    public LayerMask keyLayer1;
    public GameObject notePanel;
    public GameObject InteractPanel;
    public GameObject keyPadPanel;
    public GameObject keyPadPanel1;
    public Text noteTextUI;

    private bool isReading = false;
    private bool isUsingKeypad = false;
    private bool isUsingKeypad1 = false;

    private Camera playerCam;

    void Start()
    {
        playerCam = Camera.main;
    }

    void Update()
    {
        if (!isReading && (!isUsingKeypad ||!isUsingKeypad1))
        {
            Ray ray = new Ray(playerCam.transform.position, playerCam.transform.forward);
            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);

            if (Physics.Raycast(ray, out hit, rayDistance, noteLayer))
            {
                InteractPanel.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    InteractPanel.SetActive(false);
                    NoteData data = hit.collider.GetComponent<NoteData>();
                    if (data != null)
                    {
                        ShowNote(data.noteText);
                    }
                }
            }
            else if (Physics.Raycast(ray, out hit, rayDistance, keyLayer))
            {
                InteractPanel.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    InteractPanel.SetActive(false);
                    ShowKeypad();

                }
            }
            else if (Physics.Raycast(ray, out hit, rayDistance, keyLayer1))
            {
                InteractPanel.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    InteractPanel.SetActive(false);
                    ShowKeypad1();

                }
            }
            else
            {
                InteractPanel.SetActive(false);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (isReading)
                {
                    CloseNote();
                }
                if (isUsingKeypad)
                {
                    CloseKeypad();
                }
                if (isUsingKeypad1)
                {
                    CloseKeypad1();
                }
                // Keypad için çýkýþ ESC gibi ayrý tuþla yapýlmalý istersen
            }
        }
    }

    void ShowNote(string text)
    {
        notePanel.SetActive(true);
        noteTextUI.text = text;
        PauseGame();
        isReading = true;
    }

    void CloseNote()
    {
        notePanel.SetActive(false);
        ResumeGame();
        isReading = false;
    }

    void ShowKeypad()
    {
        keyPadPanel.SetActive(true);
        PauseGame();
        isUsingKeypad = true;
    }
    void ShowKeypad1()
    {
        keyPadPanel1.SetActive(true);
        PauseGame();
        isUsingKeypad1 = true;
    }

    public void CloseKeypad()
    {
        keyPadPanel.SetActive(false);
        ResumeGame();
        isUsingKeypad = false;
    }
    public void CloseKeypad1()
    {
        keyPadPanel1.SetActive(false);
        ResumeGame();
        isUsingKeypad1 = false;
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}