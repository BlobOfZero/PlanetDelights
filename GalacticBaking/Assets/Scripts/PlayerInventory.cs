using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public TextMeshProUGUI killsText;
    public TextMeshProUGUI ammoText;
    public GameObject LevelWinPanel, losePanel, gameWin;

    public int killCoins;

    private PlayerController controller;
    private BulletController bulletController;

    public static int winObjects;

    public int Enemy;

    public static bool eggCollected;
    public static bool mushroomCollected;
    public static bool fishCollected;
    public static bool upgradeBought;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Chef");
        controller = player.GetComponent<PlayerController>();
        killsText.text = "" + killCoins;
        killCoins = 0;
        ammoText.text = "" + controller.currentAmmo;
        LevelWinPanel.gameObject.SetActive(false);
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
        
        if(fishCollected == true && eggCollected == true && mushroomCollected == true)
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
        if(killCoins >= 5)
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
        if(killCoins >= 5)
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
        if(killCoins >= 20)
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
           WeaponUpgraded();
        }
        else
        {
            return;
        }
    }

    public void WeaponUpgraded()
    {
        upgradeBought = true;
    }

    public void AddEgg()
    {
        eggCollected = true;
        LevelWinPanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("egg collected");
    }

    public void AddMushroom()
    {
        mushroomCollected = true;
        LevelWinPanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("mushroom collected");
    }

    public void AddFish()
    {
        fishCollected = true;
        LevelWinPanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("fish collected");
    }

    public void EnemyKIlled(int amount)
    {
        Enemy += amount;
    }
}
