using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 2.0f;
    [SerializeField] float jumpHeight = 1.0f;
    [SerializeField] float gravityValue = -9.81f;



    CharacterController controller;
    Vector3 playerVelocity;
    [SerializeField] bool groundedPlayer;
    Transform camra;
    float rotSpeed = 4f;

    private void Start()
    {
        camra = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        float HoriInput = Input.GetAxisRaw("Horizontal");
        float VertiInput = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(HoriInput, VertiInput);
        Vector3 move = new Vector3(movement.x, 0f, movement.y).normalized;

        move = camra.forward * move.z + camra.right * move.x;
        move.y = 0;

        controller.Move(move * Time.deltaTime * playerSpeed);

        // Changes the height position of the player..
        if (Input.GetKeyDown(KeyCode.Space) && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (movement != Vector2.zero)
        {
            float target = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + camra.eulerAngles.y;
            Quaternion rot = Quaternion.Euler(0f, target, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * rotSpeed);
        }
    }

}