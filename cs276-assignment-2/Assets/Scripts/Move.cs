using System;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEditor.Tilemaps;

public class Move : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    public bool win = false;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] float immunityTime = .5f;
    public float currSpeed = 5f;
    [SerializeField] float jump = 10f;
    [SerializeField] GameObject SlotMachine;
    bool damageTaken = false;
    private Rigidbody2D rb;
    private bool isGrounded;
    bool jumped;
    public int hearts = 1;
    public float score = 20f;
    public float strength = 16, delay = 0.15f;
    [SerializeField] ParticleSystem damageEffectPrefab;
    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject youWin;
    public Animator anim;
    [SerializeField] AudioSource deathSound;
    private bool isFacingRight = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Score());
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(delay);
        rb.linearVelocity = Vector3.zero;
    }

    IEnumerator Score()
    {
        while (score > 0 && win == false)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            score -= .02f;
            if (score < 0) { score = 0; }
            scoreText.text = "Score: " + Math.Round(score, 2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -2 && hearts != 0 && score != 0)
        {
            hearts = 0;
            score = 0;
            deathSound.Play();
        }
        if (win || hearts <= 0 || score <= 0)
        {
            restartButton.SetActive(true);
            if (win)
            {
                youWin.SetActive(true);
            }
        }

        float move = 0f;

        if (Keyboard.current.aKey.isPressed)
        {
            move = -1f;
        }

        if (Keyboard.current.dKey.isPressed)
        {
            move = 1f;
        }

        float jumpAmount = rb.linearVelocity.y;

        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            jumpAmount = jump;
            jumped = false;
        }
        else if (Keyboard.current.spaceKey.wasReleasedThisFrame && rb.linearVelocity.y > 0f && jumped == false)
        {
            jumpAmount = jump * .5f;
            jumped = true;
        }

        if (move > .1 || move < -.1)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (isGrounded)
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }

        if (move > .1 && !isFacingRight)
        {
            Flip();
        }
        else if (move < -.1 && isFacingRight)
        {
            Flip();
        }


        float moveAmount = move * currSpeed;

        rb.linearVelocity = new Vector2(moveAmount, jumpAmount);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Vector3 normal = other.GetContact(0).normal;
            if (normal == Vector3.up)
            {
                isGrounded = true;
            }
        }

        else if (other.gameObject.CompareTag("Damager"))
        {

            Vector2 direction = (transform.position - other.transform.position).normalized;
            rb.AddForce(direction * strength, ForceMode2D.Impulse);

            Vector2 contactPoint = other.GetContact(0).point;
            GameObject damageEffect = Instantiate(damageEffectPrefab.gameObject, contactPoint, Quaternion.identity);

            // Destroy the effect after 1 second
            Destroy(damageEffect, 1f);
        }
        else if (other.gameObject.CompareTag("DiceSurface"))
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>(), true);
        }
        if (hearts <= 0 || score <= 0)
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>(), true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("flag"))
        {
            win = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Slot Off") && Keyboard.current.fKey.isPressed)
        {
            float x = other.transform.position.x;
            float y = other.transform.position.y;
            Destroy(other.gameObject);
            Instantiate(SlotMachine, new Vector3(x, y, 0), Quaternion.identity);
        }
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Damager"))
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        if (damageTaken == false)
        {
            hearts -= 1;
            score -= 1;
            damageTaken = true;
            StartCoroutine(Immunity());
        }
    }

    IEnumerator Immunity()
    {
        yield return new WaitForSecondsRealtime(immunityTime);
        damageTaken = false;
    }
}
