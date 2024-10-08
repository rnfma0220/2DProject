using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundControll : MonoBehaviour
{
    private BoxCollider2D ground;
    private CameraManger _Camera;
    
    // Start is called before the first frame update
    private void Start()
    {
        TryGetComponent(out ground);
        _Camera = FindObjectOfType<CameraManger>();
        _Camera.Setbound(ground);
    }
}
