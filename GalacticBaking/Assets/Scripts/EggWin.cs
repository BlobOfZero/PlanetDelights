using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EggWin : MonoBehaviour
{
    public TextMeshProUGUI winTXT;

    public PlayerInventory inventory;
    
    // Start is called before the first frame update
    void Start()
    {
        winTXT.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && inventory.easyEnemy == 3)
        {
            //SceneManager.LoadScene("GameHub");
            inventory.AddLevelWin(1);
        }
    }
}