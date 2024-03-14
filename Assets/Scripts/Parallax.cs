using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private float relativeMove = .3f;

    void Update()
    {
        transform.position = new Vector2(cam.position.x * relativeMove, transform.position.y);
    }
}
