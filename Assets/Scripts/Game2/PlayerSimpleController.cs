using UnityEngine;

public class PlayerSimpleController : MonoBehaviour
{
    public float _speed = 5.0f;

    void Update()
    {
        float _moveHorizontal = Input.GetAxis("Horizontal");
        float _moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(_moveHorizontal, 0.0f, _moveVertical);

        transform.Translate(movement * _speed * Time.deltaTime, Space.World);
    }
}
