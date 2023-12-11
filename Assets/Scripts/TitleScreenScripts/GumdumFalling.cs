using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumdumFalling : MonoBehaviour
{
    [SerializeField] private Transform gumdumTitle;
    [SerializeField] private Transform endPosition;

    [SerializeField] private float fallSpeed;
    [SerializeField] private float rotateSpeed;

    [SerializeField] SpriteRenderer gumdumSprite;
    [SerializeField] Sprite fallSprite;

    [SerializeField] ParticleSystem gumParticles;

    [SerializeField] bool playSystem = true;
    void Start()
    {
        gumParticles.Stop();
    }


    void Update()
    {
        Falling();
    }

    void Falling()
    {
        gumdumTitle.position -= new Vector3(0f, fallSpeed * Time.deltaTime);
        gumdumTitle.transform.rotation = Quaternion.Euler(0f, 0f, rotateSpeed);

        rotateSpeed += 500f * Time.deltaTime;

        if (gumdumTitle.position.y <= endPosition.position.y)
        {
            rotateSpeed = 0f;
            fallSpeed = 0f;
            gumdumSprite.sprite = fallSprite;

            if (playSystem == true)
            {
                gumParticles.Play();
                playSystem = false;
            }

        }
    }
}
