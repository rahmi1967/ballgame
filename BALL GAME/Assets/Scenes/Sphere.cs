using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    private Renderer sphereRenderer;
    private bool isGrowing = false;
    private bool isChangingColor = false;
    private bool isScheduledForDestruction = false;
    public float speed = 10f;
    private void Start()
    {
        sphereRenderer = GetComponent<Renderer>();
    }
    public Transform target; // Hedef nesne (örneðin takip edilecek karakter)

    public Vector3 offset;   // Kameranýn hedef nesneye göre konumu

    public float smoothSpeed = 0.125f; // Takip yumuþaklýðý

    private void Update()
    {
        if (isGrowing)
        {
            transform.localScale += new Vector3(0.1f, 0.1f, 0.1f) * Time.deltaTime;
        }

        if (isChangingColor)
        {
            sphereRenderer.material.color = new Color(Random.value, Random.value, Random.value);
        }

        if (isScheduledForDestruction)
        {
            Destroy(gameObject, 5f);
        }
        float xHorizontal = Input.GetAxis("Horizontal");
        float zVertical = Input.GetAxis("Vertical");
        Vector3 moveSystem = new Vector3(xHorizontal, 0.0f, zVertical);
        transform.position += moveSystem * speed * Time.deltaTime;
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GrowTrigger"))
        {
            isGrowing = true;
        }
        else if (other.CompareTag("ColorChangeTrigger"))
        {
            isChangingColor = true;
        }
        else if (other.CompareTag("DestroyTrigger"))
        {
            isScheduledForDestruction = true;
            Destroy(gameObject, 5f); // Hemen yok etmek yerine 5 saniye sonra yok et
        }
    }
}
