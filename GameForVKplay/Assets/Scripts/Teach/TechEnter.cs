using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TechEnter : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    private Animator canvasAnimator;
    [SerializeField] private TMP_Text textForMessage;
    [SerializeField] private string message;

    private void Start()
    {
        canvasAnimator = canvas.GetComponent<Animator>();
    }

    private bool isPlayerDetected = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && isPlayerDetected)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            textForMessage.text = message;
            canvasAnimator.SetBool("Show", true);
            isPlayerDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canvasAnimator.SetBool("Show", false);
            isPlayerDetected = false;
        }
    }
}
