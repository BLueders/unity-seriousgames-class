using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator2D : MonoBehaviour
{
    public enum AnimationState
    {
        Idle,
        Walk,
        Jump
    }

    public float animationFPS;
    public Sprite[] idleAnimation;
    public Sprite[] walkAnimation;
    public Sprite[] jumpAnimation;

    private Rigidbody2D rb2d;
    private PlatformerController2D controller;
    private SpriteRenderer sRenderer;

    private float frameTimer = 0;
    private int frameIndex = 0;
    private AnimationState state = AnimationState.Idle;
    private Dictionary<AnimationState, Sprite[]> animationAtlas;

    void Start()
    {
        animationAtlas = new Dictionary<AnimationState, Sprite[]>();
        animationAtlas.Add(AnimationState.Idle, idleAnimation);
        animationAtlas.Add(AnimationState.Walk, walkAnimation);
        animationAtlas.Add(AnimationState.Jump, jumpAnimation);

        rb2d = GetComponent<Rigidbody2D>();
        sRenderer = GetComponent<SpriteRenderer>();
        controller = GetComponent<PlatformerController2D>();
    }

    void Update()
    {
        AnimationState newState = GetAnimationState();
        if(state != newState) {
            TransitionToState(newState);
        }

        frameTimer -= Time.deltaTime;
        if(frameTimer <= 0.0f) {
            frameTimer = 1 / animationFPS;
            Sprite[] anim = animationAtlas[state];
            frameIndex %= anim.Length;
            sRenderer.sprite = anim[frameIndex];
            frameIndex++;
        }

        if(rb2d.velocity.x < -0.01f) {
            sRenderer.flipX = true;
        }

        if(rb2d.velocity.x > 0.01f) {
            sRenderer.flipX = false;
        }
    }

    void TransitionToState(AnimationState newState)
    {
        frameTimer = 0.0f;
        frameIndex = 0;
        state = newState;
    }

    AnimationState GetAnimationState()
    {
        if (!controller.grounded) {
            return AnimationState.Jump;
        }
        if(Mathf.Abs(rb2d.velocity.x) > 0.1f) {
            return AnimationState.Walk;
        }
        return AnimationState.Idle;
    }
}
