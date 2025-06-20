using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Game.Scripts.UI;
using UnityEditor.Experimental.GraphView;
using System.CodeDom.Compiler;

namespace Game.Scripts.LiveObjects
{
    public class Drone : MonoBehaviour
    {
        private enum Tilt
        {
            NoTilt, Forward, Back, Left, Right
        }

        [SerializeField]
        private Rigidbody _rigidbody;
        [SerializeField]
        private float _speed = 5f;
        private bool _inFlightMode = false;
        [SerializeField]
        private Animator _propAnim;
        [SerializeField]
        private CinemachineVirtualCamera _droneCam;
        [SerializeField]
        private InteractableZone _interactableZone;

        //Input Manager 
        [SerializeField]
        private InputManager _inputManager;

        //Drone Starting Position
        Vector3 startPos;


        public static event Action OnEnterFlightMode;
        public static event Action onExitFlightmode;

        private void OnEnable()
        {
            InteractableZone.onZoneInteractionComplete += EnterFlightMode;
            
        }

        private void EnterFlightMode(InteractableZone zone)//WILL NEED THIS TO SWAP ACTION WITHIN INTERACTABLE ZONE
        {
            if (_inFlightMode != true && zone.GetZoneID() == 4) // drone Scene
            {
                _propAnim.SetTrigger("StartProps");
                _droneCam.Priority = 11;
                _inFlightMode = true;
                OnEnterFlightMode?.Invoke();
                UIManager.Instance.DroneView(true);
                _interactableZone.CompleteTask(4);
                //enable drone controls
                _inputManager.InitializeDroneInput();
                
               
            }
        }

        public void ExitFlightMode()//--> Made public to access via the InputManager
        {
            //Need to make it so the drone stops moving for good, no animations or anything
            if (_inFlightMode == true) //added from the update
            {
                _inputManager.DisableDroneControls();//disable drone controls
                _droneCam.Priority = 9;
                _inFlightMode = false;
                onExitFlightmode?.Invoke(); //Added from the update
                UIManager.Instance.DroneView(false);
                this.transform.position = startPos; //Return drone to start position

            }

        }

        private void Update()
        {
            /*if (_inFlightMode) -->  Moved to exit flight method
            {
                //I can call these two methods from the Player Manager 
               // CalculateTilt(); --> Moved to InputManager Script
              //  CalculateMovementUpdate();  --> Moved to InputManager Script
            */
            /*    if (Input.GetKeyDown(KeyCode.Escape))//ESC CHANGE TO NEW INPUT. Could move all this to the disable?
                {
                    _inFlightMode = false;
                    onExitFlightmode?.Invoke();
                    ExitFlightMode();
                }*/
            
        }

        private void Start()
        {
            startPos = this.transform.position;
        }
        private void FixedUpdate() 
        {
            //rigidbody --> moved to calculate method
           _rigidbody.AddForce(transform.up * (9.81f), ForceMode.Acceleration); //Seems to be adding "positive" gravity 9.81 as an upward force 
             //CalculateMovementFixedUpdate(); --> Moved to InputManager Script
        }

        public  void CalculateMovementUpdate(float rotInput)
        { 
            var tempRot = transform.localRotation.eulerAngles;
            tempRot.y += rotInput * (_speed / 3); //same speed value but now we add rotational awareness 
            transform.localRotation = Quaternion.Euler(tempRot);

        }
        /* private void CalculateMovementUpdate()//METHOD HAS BEEN REWORKED ABOVE
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                var tempRot = transform.localRotation.eulerAngles; --> Keeping this for the reworked method
                tempRot.y -= _speed / 3; --> Same speed value will be used 
                transform.localRotation = Quaternion.Euler(tempRot);--> Keeping this for the reworked method
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                var tempRot = transform.localRotation.eulerAngles;
                tempRot.y += _speed / 3;
                transform.localRotation = Quaternion.Euler(tempRot);
            }
        }*/
        public void CalculateMovementFixedUpdate(float direction)  //New update to handle physics-based movement
        {
           
            _rigidbody.AddForce(transform.up * direction * _speed, ForceMode.Acceleration);
            
        }
        /*priviate void CalculateMovementFixedUpdate() //METHOD HAS BEEN REWORKED ABOVE ^
        {
            _rigidbody.AddForce(transform.up * direction * _speed, ForceMode.Acceleration);
            /*    if (Input.GetKey(KeyCode.Space))
            {
           _rigidbody.AddForce(transform.up * direction * _speed, ForceMode.Acceleration);
            }
            if (Input.GetKey(KeyCode.V))
            {
            //    _rigidbody.AddForce(-transform.up * direction * _speed, ForceMode.Acceleration);
        }
           */

        public void CalculateTilt(Vector2 tilt) 
        //The new parameter variable handles the direction of the tilt. We can determine that in the InputManager accordingly 
            
        {

            float xRotation = 0;
            float zRotation = 0;

            if (tilt.x < 0) // A
                zRotation = 30;
            else if (tilt.x > 0) // D
                zRotation = -30;

            if (tilt.y > 0) // W
                xRotation = 30;
            else if (tilt.y < 0) // S
                xRotation = -30;

            transform.rotation = Quaternion.Euler(xRotation, transform.localRotation.eulerAngles.y, zRotation);
        }

        //private void CalculateTilt() //THIS METHOD HAS BEEN REWORKED ABOVE
       
        // {

        /* if (Input.GetKey(KeyCode.A)) //we can use the value in the PlayerManager to handle this
             transform.rotation = Quaternion.Euler(00,transform.localRotation.eulerAngles.y, 30);
           else if (Input.GetKey(KeyCode.D))
             transform.rotation = Quaternion.Euler(0, transform.localRotation.eulerAngles.y, -30);
          else if (Input.GetKey(KeyCode.W))
             transform.rotation = Quaternion.Euler(30, transform.localRotation.eulerAngles.y, 0);
          else if (Input.GetKey(KeyCode.S))
             transform.rotation = Quaternion.Euler(-30, transform.localRotation.eulerAngles.y, 0);
          else 
             transform.rotation = Quaternion.Euler(0, transform.localRotation.eulerAngles.y, 0);
        */
        // }

        private void OnDisable()
        {
            InteractableZone.onZoneInteractionComplete -= EnterFlightMode;
        }
    }
}
