﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slime : MonoBehaviour
{

    public string message = "";
    public Text slimeText;
    public GameObject slimeDimmer;

    private Animator slimeAnimator;

    void Start()
    {
        slimeAnimator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            slimeDimmer.SetActive(true);
            slimeText.text = message;
            StartTalking();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            slimeDimmer.SetActive(false);
            slimeText.text = "";
            StopTalking();
        }
    }

    public void StartTalking()
    {
        slimeAnimator.SetBool("Talking", true);
    }

    public void StopTalking()
    {
        slimeAnimator.SetBool("Talking", false);
    }

    public void FinishLevel()
    {
        StopTalking();
        slimeAnimator.SetTrigger("Dance");
    }

    public void PlayerDied()
    {
        StopTalking();
        slimeAnimator.SetTrigger("SenseSomething");
    }
}
