using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EularAngle : MonoBehaviour
{
    [SerializeField] float sensitivity;

    float pi = 3.14159265359f;

    Vector3 DegreeToRadians(Vector3 eular)
    {
        return new Vector3(eular.x * (Mathf.PI / 180.0f), eular.y * (Mathf.PI / 180.0f), eular.z * (Mathf.PI / 180.0f));
    }

    Vector3 EularAngleToVector(Vector3 EularAngle)
    {
        Vector3 rv = new Vector3();

        rv.z = Mathf.Cos(EularAngle.x) * Mathf.Cos(EularAngle.y);
        rv.y = -Mathf.Sin(EularAngle.x);
        rv.x = Mathf.Cos(EularAngle.x) * Mathf.Sin(EularAngle.y);

        return rv;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler((Input.mousePosition.y - Screen.height / 2) * sensitivity, (-Input.mousePosition.x + Screen.width / 2) * sensitivity, 0);
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += EularAngleToVector(DegreeToRadians(new Vector3 (transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z))) * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            transform.position -= EularAngleToVector(DegreeToRadians(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z))) * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position -= EularAngleToVector(DegreeToRadians(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 90.0f, transform.rotation.eulerAngles.z))) * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += EularAngleToVector(DegreeToRadians(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 90.0f, transform.rotation.eulerAngles.z))) * Time.deltaTime;
        }
    }
}
