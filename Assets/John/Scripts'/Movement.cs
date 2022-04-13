using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    //For Animator
    [HideInInspector] public bool Grounded;
    [HideInInspector] public bool Jumping;
    [HideInInspector] public float VerticalVelocity;
    [HideInInspector] public float HorizontalVelocity;

    public float Speed = 8;
    public float JumpSpeed = 15f;

    CapsuleCollider2D _capsule;
    Rigidbody2D _rb;
    LayerMask _collisionLayers = ~(1 << 8);

    const float _groundCheckDist = 0.1f;
    const float _groundCheckSizeMulti = 0.9f;

    void Start()
    {
        _capsule = GetComponent<CapsuleCollider2D>();
        _rb = GetComponent<Rigidbody2D>();
    }
    public void Jump()
    {
        if (Grounded)
        {
            Jumping = true;
            Grounded = false;
        }
    }
    public void Move(float input)
    {
        HorizontalVelocity = input * Speed;
    }
    void FixedUpdate()
    {
        Grounded = CheckGrounded();

        if (Jumping)
        {
            VerticalVelocity = JumpSpeed;
            Jumping = false;
        }
        else
        {
            VerticalVelocity = _rb.velocity.y;
        }

        _rb.velocity = new Vector2(HorizontalVelocity, VerticalVelocity);
    }
    bool CheckGrounded()
    {
        Vector2 pos = (Vector2)transform.position + _capsule.offset;
        Vector2 direction = new Vector2(0, -_groundCheckDist);
        Vector2 size = _capsule.size * _groundCheckSizeMulti;
        RaycastHit2D hit = Physics2D.CapsuleCast(pos, size, _capsule.direction, 0, direction, direction.magnitude, _collisionLayers);
        return hit.collider != null;
    }
}