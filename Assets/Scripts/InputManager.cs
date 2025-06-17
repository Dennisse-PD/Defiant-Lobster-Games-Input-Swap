using Game.Scripts.LiveObjects;
using Game.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //Player
    [SerializeField]
    private Player _player; 

    //Input Actions
    private PlayerInputActions _input;

    //Drone 
    [SerializeField]
    private Drone _drone; //reference to drone object

    //This script handles the input. i.e Performed actions and such.
    // Start is called before the first frame update
    void Start()
    {
        InitializePlayerInput();
    }

    // Update is called once per frame
    void Update()
    {
        //Player Movement
        var move = _input.Player.Move.ReadValue<Vector2>(); //Using the context value from our vector2 input, we can register direction
        _player.CalcutateMovement(move); //uses the parameter variable which is of type vector 2

        //Drone Tilt
        var tilt = _input.Drone.Tilt.ReadValue<Vector2>();
        _drone.CalculateTilt(tilt);
    }
    private void FixedUpdate()
    {
        //fixed logic here for drone
    }
    private void InitializePlayerInput()
    {
        _input = new PlayerInputActions();
        _input.Player.Enable();
        //generate peform callback here
        
    }
    //create method to initialize drone input
    private void InitializeDroneInput()
    {
        //this method will be called when the ENTER DRONE key is pressed withint he interactable zone
        _input.Player.Disable(); //This will be re-enabled when the key to exit the drone is pressed 
        _input.Drone.Enable();
    }

   
}
