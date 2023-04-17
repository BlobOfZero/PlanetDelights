using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public TextMeshProUGUI killsText;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI fuelText;
    public GameObject winPanel, losePanel;

    public int killCoins;

    private PlayerController controller;
    private BulletController bulletController;

    public int winObjects;

    public int easyEnemy;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Chef");
        controller = player.GetComponent<PlayerController>();
        killsText.text = "" + killCoins;
        killCoins = 0;
        ammoText.text = "" + controller.currentAmmo;
        fuelText.text = "" + controller.currentFuel;
        winPanel.gameObject.SetActive(false);
        losePanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        killsText.text = "" + killCoins;
        ammoText.text = "" + controller.currentAmmo;
        fuelText.text = "" + controller.currentFuel;

        if(controller.loseState == true)
        {
            losePanel.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
        if(winObjects == 3)
        {
            
        }
    }

    public void AddCoins(int amount)
    {
        killCoins += amount;
    }

    public void SubtractCoinsAmmo(int amount)
    {
        if(killCoins > 0)
        {
           killCoins -= 5;
           controller.AddAmmo(5);
        }
        else
        {
            return;
        }
    }

       public void SubtractCoinsHealth(int amount)
    {
        if(killCoins > 0)
        {
           killCoins -= 5;
           controller.AddHealth(5);
        }
        else
        {
            return;
        }
    }

    public void SubtractJetFuel(int amount)
    {
        if(killCoins > 0)
        {
           killCoins -= 5;
           controller.AddJetpackFuel(5);
        }
        else
        {
            return;
        }
    }

    public void SubtractWeaponUpgrade1(int amount)
    {
        if(killCoins >= 10)
        {
           killCoins -= 10;
        }
        else
        {
            return;
        }
    }

    public void AddLevelWin(int amount)
    {
        winObjects += amount;
    }

    public void EnemyKIlled(int amount)
    {
        easyEnemy += amount;
    }

    public void levelBeat(int amount)
    {
        if(winObjects >= 3)
        {
            Debug.Log("You win");
        }
    }
}
