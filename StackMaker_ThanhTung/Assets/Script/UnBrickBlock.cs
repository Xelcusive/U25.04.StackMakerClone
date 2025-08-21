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
                if (playerBrick.RemoveBrick(transform.position))
                {
                    isFilled = true;
                }
                else
                {
                    // Hết gạch thì Player không đi qua được
                    Debug.Log("Player out of block, player can not move right now.");
                }
            }
        }
    
}
