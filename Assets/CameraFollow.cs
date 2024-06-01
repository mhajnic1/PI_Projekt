using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f); //pomak kamere u odnosu na target
    private float smoothTime = 0.25f; //vrijeme potrebno da kamera dode do targeta
    private Vector3 velocity = Vector3.zero; //brzina kamere

    //target koji kamera prati, postavlja se u inspectoru
    [SerializeField] private Transform target;

    private void Update()
    {
        //izracunavanje pozicije cilja s dodanim pomakom
        Vector3 targetPosition = target.position + offset;

        //glatko pomicanje kamere prema ciljanoj poziciji
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }


    //FixedUpdate metoda se poziva u pravilnim intervalima fizicke simulacije
    private void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    //LateUpdate metoda se poziva jednom po frame-u, nakon Update metode
    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}