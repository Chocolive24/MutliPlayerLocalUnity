using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private Vector2 _roadDimensions;

    private SpriteRenderer _spriteRenderer;

    public Vector2 RoadDimensions => _roadDimensions;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _spriteRenderer.size = _roadDimensions;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
