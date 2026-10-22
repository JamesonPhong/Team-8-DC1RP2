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
    public TextMeshProUGUI roundText;
    public Image[] Keyicons;
    public Sprite wKey;
    public Sprite aKey;
    public Sprite sKey;
    public Sprite dKey;
    public Sprite wKeyActive;
    public Sprite aKeyActive;
    public Sprite sKeyActive;
    public Sprite dKeyActive;
    public Image flashOverlay;
    public bool completed = false;
    public bool failed = false;
    public bool roundStarting = false;

    public float rounds = 0;
    public float roundIntroTime = 1.5f;
    public float wrongKeyCooldown = 0.5f;
    public float nextAllowedInputTime = 0f;
    public float minigameTimer = 5f;
    private float introTimer;
    private float startingTime;
    public int buttonCount = 9;


    private KeyCode[] buttons = { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };

    private List<KeyCode> buttonOrder = new List<KeyCode>();

    private int currentButtonIndex = 0;

    private void Start()
    {
        startingTime = minigameTimer;
        flashOverlay.color = Color.clear;
        StartRound();
    }
    private void Update()
    {
        flashOverlay.color = Color.Lerp(flashOverlay.color, Color.clear, 10f * Time.deltaTime);

        Restart();

        if (roundStarting)
        {
            introTimer -= Time.deltaTime;

            if (introTimer <= 0f)
            {
                roundStarting = false;
                roundText.gameObject.SetActive(false);
                DisplayButtons();
            }
            return;
        }

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
                minigameTimer = startingTime;
                if (completed) buttonCount = Mathf.Min(buttonCount + 1, Keyicons.Length);
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
                    else
                    {
                        Keyicons[currentButtonIndex].sprite = GetSprite(buttonOrder[currentButtonIndex], true);
                    }
                }
                else
                {
                    nextAllowedInputTime = Time.time + wrongKeyCooldown;//Adds the time for the input delay
                    flashOverlay.color = new Color(1f, 0.2f, 0.2f, 0.5f);
                }

                return;
            }
        }
    }
    void GenerateButtonSequence()
    {
        buttonOrder.Clear();

        for (int i = 0; i < buttonCount; i++)
        {
            int random = Random.Range(0, buttons.Length);
            buttonOrder.Add(buttons[random]);
        }
    }
    void StartRound()
    {
        currentButtonIndex = 0;

        GenerateButtonSequence();

     

        foreach (Image icon in Keyicons)
        {
            icon.gameObject.SetActive(false);
        }

        timerText.text = Mathf.CeilToInt(minigameTimer).ToString();
        roundText.gameObject.SetActive(true);
        roundText.text = "ROUND " + (rounds + 1);
        roundStarting = true;
        introTimer = roundIntroTime;
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
            Keyicons[i].sprite = GetSprite(buttonOrder[i], i == 0);

        }
    }

    Sprite GetSprite(KeyCode key, bool active)
    {
        switch (key)
        {
            case KeyCode.W:
                return
                    active ? wKeyActive : wKey;
            case KeyCode.A:
                return
                    active ? aKeyActive : aKey;
            case KeyCode.S:
                return
                    active ? sKeyActive : sKey;
            case KeyCode.D:
                return
                    active ? dKeyActive : dKey;
        }
        return null;
    }
}
