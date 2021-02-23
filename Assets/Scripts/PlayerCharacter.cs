using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private enum State
    {
        NONE,
        IDLE,
        WALKSIDE,
        WALKUP,
        WALKDOWN
    }

    [SerializeField] private SpriteRenderer Playecharactersprite_;
    [SerializeField] private Rigidbody2D Bodyplayer_;
    [SerializeField] private Animator Playeranim_;
    private Transform Playertransform_;
    private State CurrentState_;
    private const float MoveSpeed_ = 2.0f;
    private const float DeadZone_ = 0.1f;
    private bool FacingRight_ = false;
    void Start()
    {
        Playertransform_ = GetComponent <Transform>();
        CurrentState_ = State.IDLE;
    }

    private void FixedUpdate()
    {
        Bodyplayer_.velocity = new Vector2(Input.GetAxis("Horizontal") * MoveSpeed_, Bodyplayer_.velocity.y);
        Bodyplayer_.velocity = new Vector2(Bodyplayer_.velocity.x, Input.GetAxis("Vertical") * MoveSpeed_);

        if(Input.GetAxis("Horizontal") < -DeadZone_ && FacingRight_)
        {
            Flip();
        }

        if (Input.GetAxis("Horizontal") > -DeadZone_ && !FacingRight_)
        {
            Flip();
        }

        switch(CurrentState_)
        {
            case State.IDLE:
                if(Mathf.Abs(Input.GetAxis("Horizontal")) > DeadZone_)
                {
                    ChangeState(State.WALKSIDE);
                
                }
              
                if (Mathf.Abs(Input.GetAxis("Vertical")) < -DeadZone_)
                {
                    ChangeState(State.WALKUP);
                }
                if (Mathf.Abs(Input.GetAxis("Vertical")) > DeadZone_)
                {
                    ChangeState(State.WALKDOWN);
                }
                break;
            case State.WALKUP:
                if (Mathf.Abs(Input.GetAxis("Horizontal")) > DeadZone_)
                {
                    ChangeState(State.WALKSIDE);
                    
                }
               
                if ((Input.GetAxis("Vertical") > -DeadZone_ && Input.GetAxis("Vertical") < DeadZone_)
                   && Input.GetAxis("Horizontal") > -DeadZone_ && Input.GetAxis("Horizontal") < DeadZone_)
                {
                    ChangeState(State.IDLE);
                }
                break;
            case State.WALKDOWN:
                if (Mathf.Abs(Input.GetAxis("Horizontal")) > DeadZone_)
                {
                    ChangeState(State.WALKSIDE);
                    
                }
       
                if (Input.GetAxis("Vertical") > -DeadZone_)
                {
                    ChangeState(State.WALKUP);
                }

                if ((Input.GetAxis("Vertical") > -DeadZone_ && Input.GetAxis("Vertical") < DeadZone_)
                    && Input.GetAxis("Horizontal") > -DeadZone_ && Input.GetAxis("Horizontal") < DeadZone_)
                {
                    ChangeState(State.IDLE);
                }
                break;
            case State.WALKSIDE:
                if (Input.GetAxis("Vertical") > DeadZone_)
                {
                    ChangeState(State.WALKUP);
                }
                if (Input.GetAxis("Vertical") < -DeadZone_)
                {
                    ChangeState(State.WALKDOWN);
                }
                if ((Input.GetAxis("Vertical") > -DeadZone_ && Input.GetAxis("Vertical") < DeadZone_)
                    && Input.GetAxis("Horizontal") > -DeadZone_ && Input.GetAxis("Horizontal") < DeadZone_)
                {
                    ChangeState(State.IDLE);
                }
                break;
        }
    }

    void Update()
    {
        
    }

    void Flip()
    {
        Playecharactersprite_.flipX = !Playecharactersprite_.flipX;
        FacingRight_ = !FacingRight_;
    }

    void ChangeState(State state)
    {
        switch(state)
        {
            case State.IDLE:
                Playeranim_.Play("idle");
                break;
            case State.WALKSIDE:
                Playeranim_.Play("walkside");
                break;
            case State.WALKDOWN:
                Playeranim_.Play("walkdown");
                break;
            case State.WALKUP:
                Playeranim_.Play("walkup");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
        CurrentState_ = state;
    }

}
