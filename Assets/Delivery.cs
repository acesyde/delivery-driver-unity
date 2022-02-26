using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Delivery : MonoBehaviour
{
    [SerializeField] private Color32 hasPackageColor = new Color32(1,1,1,1);
    [SerializeField] private Color32 hasNoPackageColor = new Color32(1,1,1,1);
    [SerializeField] private float destroyDelay = 0.5f;
    private bool hasPackage = false;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Outch !");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Package") && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            _spriteRenderer.color = hasPackageColor;
            Destroy(col.gameObject, destroyDelay);
        }

        if (col.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("Package delivered");
            hasPackage = false;
            _spriteRenderer.color = hasNoPackageColor;
        }
    }
}