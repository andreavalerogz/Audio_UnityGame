using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    [SerializeField] Vector2 speedMovement;
    Vector2 offset;
    Material backgroundMaterial;

    private void Awake()
    {
        backgroundMaterial = GetComponent<SpriteRenderer>().material;
    }
    void Update()
    {
        offset = speedMovement * Time.deltaTime;
        backgroundMaterial.mainTextureOffset += offset;
    }
}
