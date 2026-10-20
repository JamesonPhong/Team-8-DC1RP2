using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Phase1Minigame : MonoBehaviour
{
    public GameObject playAgain;
    public TextMeshProUGUI timerText;
    public Image[] Keyicons;
    public Sprite wKey;
    public Sprite aKey;
    public Sprite sKey;
    public Sprite dKey;
    public bool completed = false;
    public bool failed = false;

    public float rounds = 0;
    public float wrongKeyCooldown = 0.5f;
    public float nextAllowedInputTime = 0f;
    public float minigameTimer = 5f;
    private float startingTime;

    private KeyCode[] buttons = { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };

    private List<KeyCode> buttonOrder = new List<KeyCode>();

    private int currentButtonIndex = 0;

    private void Start()
    {
        startingTime = minigameTimer;
        StartRound();
    }
    private void Update()
    {

        Restart();

        if (completed || failed)
        {
            return;
        }


        Timer();


        if (failed)
        {
            return;
        }
        if (Time.time < nextAllowedInputTime)
        {
            return;
        }
        CheckInput();
     
    }
    void Restart()
    {
        if (completed || failed)
        {

            playAgain.SetActive(true);

            if (Input.anyKeyDown)
            {
                minigameTimer = 5f;
                completed = false;
                failed = false;
                playAgain.SetActive (false);
                nextAllowedInputTime = 0f;
                StartRound();

            }
        }
    }

    void Timer()
    {
        minigameTimer -= Time.deltaTime;

        if (minigameTimer <= 0f)
        {
            minigameTimer = 0f;
            failed = true;
            timerText.text = "0";
            Debug.Log("Minigame Failed! Time ran out.");
            return;
        }

        timerText.text = Mathf.CeilToInt(minigameTimer).ToString();
    }

    void CheckInput()
    {
        foreach (KeyCode button in buttons)
        {
            if (Input.GetKeyDown(button))
            {
                if (button == buttonOrder[currentButtonIndex])
                {
                    Debug.Log("Correct");

                    Keyicons[currentButtonIndex].gameObject.SetActive(false);

                    currentButtonIndex++;

                    if (currentButtonIndex >= buttonOrder.Count)
                    {
                        completed = true;
                        Debug.Log("Minigame Completed!");
                        Debug.Log(minigameTimer);
                        rounds++;
                    }
                }
                else
                {
                    nextAllowedInputTime = Time.time + wrongKeyCooldown;//Adds the time for the input delay
                }

                return;
            }
        }
    }
    void GenerateButtonSequence()
    {
        buttonOrder.Clear();

        for (int i = 0; i < 9; i++)
        {
            int random = Random.Range(0, buttons.Length);
            buttonOrder.Add(buttons[random]);
        }
    }
    void StartRound()
    {
        currentButtonIndex = 0;

        GenerateButtonSequence();

        DisplayButtons();
    }
    void DisplayButtons()
    {
        for (int i = 0; i < Keyicons.Length; i++)
        {
            if (i >= buttonOrder.Count)
            {
                Keyicons[i].gameObject.SetActive(false);
                continue;
            }

            Keyicons[i].gameObject.SetActive(true);

            KeyCode currentButton = buttonOrder[i];
            Sprite selectedSprite = null;

            switch (currentButton)
            {
                case KeyCode.W:
                    selectedSprite = wKey;
                    break;

                case KeyCode.A:
                    selectedSprite = aKey;
                    break;

                case KeyCode.S:
                    selectedSprite = sKey;
                    break;

                case KeyCode.D:
                    selectedSprite = dKey;
                    break;
            }

            Keyicons[i].sprite = selectedSprite;
        }
    }
}
