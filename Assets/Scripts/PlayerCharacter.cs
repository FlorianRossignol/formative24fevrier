using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private SpriteRenderer Playecharactersprite_;
    [SerializeField] private Rigidbody2D Bodyplayer_;
    private Transform Playertransform_;
    private const float MoveSpeed = 2.0f;
    void Start()
    {
        Playertransform_ = GetComponent < Transform>(); 
    }

    private void FixedUpdate()
    {
        Bodyplayer_.velocity = new Vector2(Input.GetAxis("Horizontal") * MoveSpeed, Bodyplayer_.velocity.y);
        Bodyplayer_.velocity = new Vector2(Bodyplayer_.velocity.x, Input.GetAxis("Vertical") * MoveSpeed);
    }

    void Update()
    {
        
    }
}
