using Game.Scripts.LiveObjects;
using Game.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    //Player
    [SerializeField]
    private Player _player; 

    //Input Actions
    private PlayerInputActions _input;

    //Interactable zones
     [SerializeField] private InteractableZone _interactable;
    //[SerializeField] GameObject[] _interactableZone;
    private InteractableZone _currentInteractable;

    //Drone 
    [SerializeField]
    private Drone _drone; //reference to drone object

    //Forklift
    [SerializeField]
    private Forklift _forklift; //reference to forklift object

    //This script handles the input. i.e Performed actions and such.
    // Start is called before the first frame update
    void Start()
    {
        InitializePlayerInput();
      
    }
    void Update()
    {
        //Player Movement
        var move = _input.Player.Move.ReadValue<Vector2>(); //Using the context value from our vector2 input, we can register direction
        _player.CalcutateMovement(move); //uses the parameter variable which is of type vector 2

        //Interactables(Player interactions)
        _input.Player.Interact_PressKey.performed += Interact_PressKey_performed;
        _input.Player.Interact_HoldKey.started += Interact_HoldKey_started;
        _input.Player.Interact_HoldKey.canceled += Interact_HoldKey_canceled;

        //Drone Tilt
        var tilt = _input.Drone.Tilt.ReadValue<Vector2>();
        _drone.CalculateTilt(tilt);

        //Drone Rotation
        var rotInput = _input.Drone.Rotate.ReadValue<float>();
        _drone.CalculateMovementUpdate(rotInput);

        //Forklift Movement
        var forkliftMove = _input.Forklift.Move.ReadValue<Vector2>();//context variable is used to calculate based on input
        //forlift method here
        _forklift.CalcutateMovement(forkliftMove);

    }


    private void Interact_HoldKey_canceled(InputAction.CallbackContext context)
    {
        if (_currentInteractable != null)
        {
            Debug.Log("Canceled Key Hold");
            _currentInteractable.KeyReleaseAction();
        }
    }

    private void Interact_HoldKey_started(InputAction.CallbackContext context)
    {
        if (_currentInteractable != null)
        {
            Debug.Log("Key Hold Started");
            _currentInteractable.KeyHoldAction();
        }
    }
    

    //Interactable Action Events
    private void Interact_PressKey_performed(InputAction.CallbackContext context)
    {
        if (_currentInteractable != null) //checking that there is an active zone
        {
            Debug.Log("Press Key Action");
            _currentInteractable.KeyPressAction();
        }

    }

    // Update is called once per frame
    
    private void FixedUpdate()
    {
        //Drone Up and Down
        var direction = _input.Drone.Vertical.ReadValue<float>();
        if (direction != 0) // 1D Axis gives us a value of 1 or -1 depending on cardinal direction so this is always true if there is input
            _drone.CalculateMovementFixedUpdate(-direction); //-direction to invert direction
    }
    private void InitializePlayerInput()
    {
        _input = new PlayerInputActions();
        _input.Player.Enable(); 
        
    }
   
    public void InitializeDroneInput()
    {
        //This method is called from within the Drone Script when flight is enabled
        _input.Player.Disable(); //Player controls won't be accesssible during this
        _input.Drone.Enable();
        _input.Drone.Exit.performed += Exit_performed;//Placed in the Initialize method because we are only subcribing to this once(when drone is active)
    }
    public void InitializeForkliftInput()
    {
        _input.Player.Disable();
        _input.Forklift.Enable();
       // _input.Forklift.ExitVehicle.performed += ExitVehicle_performed;
    }

    //private void ExitVehicle_performed(InputAction.CallbackContext context)
    //{
      //  Debug.Log("Exit Forklift!");
      //  _forklift.ExitDriveMode();
   // }

    //Exit Drone
    private void Exit_performed(InputAction.CallbackContext context)
    {
        Debug.Log("Exit Drone!");
        _drone.ExitFlightMode();
    
    }
    //Disabling Inputs
    public void DisableDroneControls()
    {
        //This method is called from within the Drone Srcipt when flight is disabled
        _input.Drone.Disable();
        _input.Player.Enable();  //Return control to the Player
       
    }
   
    public void DisableForkliftControls()
    {
        _input.Forklift.Disable();
        _input.Player.Enable();
    }
   
    //Needed to check which interactable zone is currently active
    public void SetCurrentInteractableZone(InteractableZone zone)
    {
        _currentInteractable = zone;
    }
    //Forklif Controls to add:
    //1. Movement
    //2. Lift up and Lift Down(seperate keys)
    //3. Exit 
    

}
