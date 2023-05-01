using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    // player movement
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float rotationSpeed = 5f;

    // jump variables
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float jumpHeight = 6.0f;
    private bool jumpPressed = false;
    private float gravityValue = -9.81f;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform barrelTransform;
    [SerializeField] private Transform bulletParent;
    [SerializeField] private float bulletHitMissDistance = 25f;
    private CharacterController controller;
    private PlayerInput playerInput;
    private AudioSource playerAudio;
    [SerializeField] private Transform playerObjTransform;

    private Transform cameraTransform;

    // player actions
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction shootAction;
    private InputAction jetpackAction;
    private InputAction pauseAction;

    // Ammo var
    private int maxAmmo = 10;
    public int currentAmmo;

    // health var
     private int maxHealth = 100;
     public int currentHealth;
     public HealthBar healthbarUI;

    // jetpack var
    public float currentFuel;
    private float maxFuel = 10f;
    public FuelBar fuelBarUI;

    // shop vars
    public Canvas shopCanvas;
    bool shopOpen = false;

    // pause var
    PauseMenu pauseScript;
    public GameObject gameManager;
    public bool iisPaused = false;

    // win lose or level complete
    public bool isDead = false;
    public bool loseState = false;

    // audio
    public AudioClip shootGunAudio;

    PlayerInventory inventory;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        playerAudio = GetComponent<AudioSource>();
        cameraTransform = Camera.main.transform;
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        shootAction = playerInput.actions["Shoot"];
        jetpackAction = playerInput.actions["Jetpack"];
        pauseAction = playerInput.actions["Pause"];

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        currentAmmo = maxAmmo;
        currentHealth = maxHealth;
        healthbarUI.SetMaxHealth(maxHealth);
        currentFuel = maxFuel;
        fuelBarUI.SetMaxFuel(maxFuel);

        shopCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;

        GameObject gameManager = GameObject.Find("GameManager");
        inventory = gameManager.GetComponent<PlayerInventory>();
    }

    private void OnEnable()
    {
        shootAction.performed += ShootGun;
    }

    private void OnDisable()
    {
        shootAction.performed -= ShootGun;
    }

    private void ShootGun(InputAction.CallbackContext ctx)
    {
        // shooting gun functionality
        if(iisPaused == false && currentAmmo > 0 && shopOpen == false)
        {
        currentAmmo --; 
        RaycastHit hit;
        GameObject bullet = GameObject.Instantiate(bulletPrefab, barrelTransform.position, Quaternion.identity, bulletParent);
        BulletController bulletController = bullet.GetComponent<BulletController>();
        GunAudio();
        if(Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, Mathf.Infinity))
        {
            bulletController.target = hit.point;
            bulletController.hit = true;
        }
        else
        {
            bulletController.target = cameraTransform.position + cameraTransform.forward *bulletHitMissDistance;
            bulletController.hit = false;
        }
        }
        else
        {
            return;
        }
    }

    void Update()
    {
        // ground movement
        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        move = move.x * cameraTransform.right.normalized + move.z * cameraTransform.forward.normalized;

        controller.Move(move * Time.deltaTime * playerSpeed);
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // jumping
        MovementJump();
        
        // Jetpack hover input gravity
        if(Input.GetKey(KeyCode.Q) && currentFuel > 1)
        {
            playerVelocity.y = 1.1f;
            currentFuel -= Time.deltaTime;
        }

        // recharge fuel
        if(currentFuel < maxFuel && controller.isGrounded)
        {
            currentFuel += Time.deltaTime;
        }

        // Fuel UI Update
        fuelBarUI.SetFuel(currentFuel);

        // Rotating the player object
    Quaternion targetRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

         // killing the player
    if(currentHealth <= 0)
    {
        loseState = true;
        Destroy(gameObject);
    }

    // pausing the game
    if(pauseAction.triggered)
    {
        gameManager.GetComponent<PauseMenu>().PauseGame();
        iisPaused = true;
        Time.timeScale = 0;
    }
    }

    public void PlayerTakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbarUI.SetHealth(currentHealth);
    }

    private void MovementJump()
    {
        groundedPlayer = controller.isGrounded;

        // if on ground stop vertical movement
        if(groundedPlayer)
        {
            playerVelocity.y = 0.0f;
        }

        // if on ground and jump pressed jump player
        if(jumpPressed && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -1.0f * gravityValue);
            jumpPressed = false;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void OnJump()
    {
        Debug.Log("Jump pressed");

        // check if no vertical movement
        if(controller.velocity.y == 0)
        {
            jumpPressed = true;
        }
    }

    private void GunAudio()
    {
        playerAudio.PlayOneShot(shootGunAudio, 0.8f);
    }

    // shop functions
    public void OpenShop()
    {
        shopCanvas.gameObject.SetActive(true);
        shopOpen = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void CloseShop()
    {
        shopCanvas.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        shopOpen = false;
    }

    public void AddAmmo(int amount)
    {
        if(inventory.killCoins < 5)
        {
        currentAmmo += amount;
        }

    }

        public void AddHealth(int amount)
    {
        currentHealth += amount;
    }

    public void AddJetpackFuel(int amount)
    {
        maxFuel += amount;
    }
}