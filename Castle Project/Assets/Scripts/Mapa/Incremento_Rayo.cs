using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incremento_Rayo : MonoBehaviour
{
    private CapsuleCollider2D capsuleCollider2D;

    private void Start()
    {
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }
    public void Increment()
    {
        capsuleCollider2D.size = new Vector2(capsuleCollider2D.size.x, capsuleCollider2D.size.y + 1);
    }

    public void Reset()
    {
        capsuleCollider2D.size = new Vector2(0.28f, 0);
    }
}
