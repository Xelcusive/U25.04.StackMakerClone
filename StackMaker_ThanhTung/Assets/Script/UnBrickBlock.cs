using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnBrickBlock : MonoBehaviour
{
    private bool isFilled = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isFilled) return;

        if (other.CompareTag("Player"))
        {
            PlayerBrick playerBrick = other.GetComponent<PlayerBrick>();

            // Nếu Player còn gạch thì đặt xuống
            if (playerBrick.RemoveBrick(transform.position, transform))
            {
                isFilled = true;
                Debug.Log("Đã đặt gạch tại: " + transform.position);
            }
            else
            {
                Debug.Log("Player hết gạch, không đi qua được!");
            }
        }
    }
}
