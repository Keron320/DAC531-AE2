﻿using UnityEngine;
using Rewired;

/*
* Statistics for player character.
*/
[System.Serializable]
    public struct PlayerStats
    {
        public int health, sanity;
        public int strength, agility, inteligence, willpower, perception, charisma;
    };

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public GameObject pauseMenuUi, inventoryMenuUi;

    public uint playerId = 0;
    public PlayerStats playerStats;
    public float speed = 3;
    public float gravity = 30f;
    public float clampAngle = 80.0f;
    public float mouseSensitivity = 100.0f;
    public float interactionRayLength = 2.0f;
    public AudioClip[] footstepSounds;

    public GameObject flashlightSource;

    private float _onwardsInput, _sidewaysInput, _mouseHorizontal, _mouseVertical;
    private bool _isInteracting = false, _hasInteracted = false, _inventoryButton = false, _hasInventory = false, _pauseButton = false, _hasPause = false;
    private bool _useFlaslight = false;
    private CharacterController _characterController;
    private Vector3 _moveDirection, _mouseDirection = Vector3.zero;
    private Animator anim;

    Player _player;

    void Start()
    {
        anim = transform.GetChild(1).GetComponent<Animator>();
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
            Destroy(gameObject);

        _player = ReInput.players.GetPlayer((int)playerId);
        _characterController = GetComponent<CharacterController>();

        transform.position = GameObject.Find("SpawnPosition").transform.position;
    }

    public void UpdatePosition()    
        => transform.position = GameObject.Find("LevelChangePoint").transform.position;
    

    // Update is called once per frame
    void Update()
    {
        CheckRewired();
        ProcessInput();
    }

    private void PlayFootStepAudio()
    {
        if (!_characterController.isGrounded) return;

        // pick & play a random footstep sound from the array,
        // excluding sound at index 0
        var audioSource = GetComponent<AudioSource>();

        if(audioSource.isPlaying) return;

        int n = Random.Range(1, footstepSounds.Length);
        audioSource.clip = footstepSounds[n];
        audioSource.PlayOneShot(audioSource.clip);
        // move picked sound to index 0 so it's not picked next time
        footstepSounds[n] = footstepSounds[0];
        footstepSounds[0] = audioSource.clip;
    }

    private void CheckRewired()
    {
        // KEYBOARD VALUES
        _onwardsInput    =  _player.GetAxis("Move_Onwards");
        _sidewaysInput   =  _player.GetAxis("Move_Sideways");

        // MOUSE VALUES
        _mouseVertical   =  _player.GetAxis("Mouse Horizontal");
        _mouseHorizontal =  _player.GetAxis("Mouse Vertical");

        // MISC
        _isInteracting   =  _player.GetButton("Interact");
        _pauseButton     =  _player.GetButtonDown("Pause");
        _inventoryButton =  _player.GetButtonDown("Inventory");
        _useFlaslight    =  _player.GetButtonDown("Flashlight");

    }

    private void ProcessInput()
    {
        if (_characterController.isGrounded)
        {
            _moveDirection = new Vector3(_sidewaysInput, 0.0f, _onwardsInput);
            _moveDirection = transform.TransformDirection(_moveDirection);
            _moveDirection *= speed;
            anim.SetFloat("speed", 0);

            if (_moveDirection.x != 0.0f && _moveDirection.z != 0.0f)
                anim.SetFloat("speed", speed);

            if (_moveDirection.x != 0.0f || _moveDirection.y != 0.0f)
                PlayFootStepAudio();
        }

        _moveDirection.y -= gravity * Time.deltaTime;


        _characterController.Move(_moveDirection * Time.deltaTime);

        // MOUSE ROTATION
        _mouseDirection.x += _mouseHorizontal * mouseSensitivity * Time.deltaTime;
        _mouseDirection.y += _mouseVertical * mouseSensitivity * Time.deltaTime;
        _mouseDirection.x = Mathf.Clamp(_mouseDirection.x, -clampAngle, clampAngle);
        var localRotation = Quaternion.Euler(_mouseDirection.x, _mouseDirection.y, 0.0f);
        Camera.main.transform.rotation = localRotation;
        transform.rotation = Quaternion.Euler(0.0f, _mouseDirection.y, 0.0f);

        // PROCESS INTERACTION
        if (_isInteracting && !_hasInteracted)
            ProcessInteraction();
        else if (!_isInteracting && _hasInteracted)
            _hasInteracted = false;

        // PROCESS UI TRIGGERS
        if(_pauseButton)
        {
            if(pauseMenuUi.activeSelf) UnPauseGame();
            else PauseGame();
        }

        if(_inventoryButton)
        {
            if(inventoryMenuUi.activeSelf) UnPauseGame();
            else PauseGame();
        }

        if(_useFlaslight)
        {
            flashlightSource.SetActive(!flashlightSource.activeSelf);
        }
    }

    private void ProcessInteraction()
    {
        _hasInteracted = true;
        var dir = Camera.main.transform.forward;
        Debug.DrawRay(Camera.main.transform.position, dir * interactionRayLength, Color.green);
        if (Physics.Raycast(Camera.main.transform.position, dir, out var hit, interactionRayLength))
        {
            if (hit.collider.gameObject.GetComponent<InteractiveObject>() == null) return;
            var interactObject = hit.collider.gameObject.GetComponent<InteractiveObject>();
            if(!interactObject.canInteract) return;
            interactObject.UseItem();
        }
    }

    public void PauseGame(bool turnPanelOn = true)
    {
        Time.timeScale = 0;
        if(turnPanelOn)
            pauseMenuUi.SetActive(true);
    }

    public void UnPauseGame(bool turnPanelOff = true)
    {
        Time.timeScale = 1;
        if(turnPanelOff)
            pauseMenuUi.SetActive(false);
    }



    public void ChangeHealth(int amount)    
        => playerStats.health += amount;
    

    public void ChangeSanity(int amount)    
        => playerStats.sanity += amount;
}
