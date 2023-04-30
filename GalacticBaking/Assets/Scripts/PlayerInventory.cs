using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public TextMeshProUGUI killsText;
    public TextMeshProUGUI ammoText;
    public GameObject winPanel, losePanel, gameWin;

    public int killCoins;

    private PlayerController controller;
    private BulletController bulletController;

    public static int winObjects;

    public int Enemy;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Chef");
        controller = player.GetComponent<PlayerController>();
        killsText.text = "" + killCoins;
        killCoins = 0;
        ammoText.text = "" + controller.currentAmmo;
        winPanel.gameObject.SetActive(false);
        losePanel.gameObject.SetActive(false);
        gameWin.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        killsText.text = "" + killCoins;
        ammoText.text = "" + controller.currentAmmo;

        if(controller.loseState == true)
        {
            losePanel.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
        if(winObjects == 3)
        {
            gameWin.gameObject.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void AddCoins(int amount)
    {
        killCoins += amount;
    }

    public void SubtractCoinsAmmo(int amount)
    {
        if(killCoins > 5)
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
        if(killCoins > 5)
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
        if(killCoins > 20)
        {
           killCoins -= 20;
           controller.AddJetpackFuel(5);
        }
        else
        {
            return;
        }
    }

    public void SubtractWeaponUpgrade1(int amount)
    {
        if(killCoins >= 25)
        {
           killCoins -= 25;
        }
        else
        {
            return;
        }
    }

    public void AddLevelWin(int amount)
    {
        winObjects += amount;
        winPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log ("current win objects collected: " + winObjects);
    }

    public void EnemyKIlled(int amount)
    {
        Enemy += amount;
    }

    public void GameWin(int amount)
    {
        if(winObjects >= 3)
        {
            Debug.Log("You win");
        }
    }
}
