using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZoneUI : MonoBehaviour
{
    [SerializeField] private GameObject DeadZoneUi;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("DeadZone"))
        {
            DeadZoneUi.SetActive(true);

            Debug.Log("deadzone");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("DeadZone"))
        {
            DeadZoneUi.SetActive(false);
        }
    }
}
