using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLook : MonoBehaviour
{
    [SerializeField] private SpriteRenderer renderer;

    [SerializeField] private List<Sprite> sprites = new List<Sprite>();

    // Start is called before the first frame update
    void Start()
    {
        renderer.sprite = sprites[(int)Random.Range(0, sprites.Count)];
    }
}
