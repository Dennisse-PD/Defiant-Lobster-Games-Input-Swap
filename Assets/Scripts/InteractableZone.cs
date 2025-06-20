using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Scripts.UI;


namespace Game.Scripts.LiveObjects
{
 
    
 
    public class InteractableZone : MonoBehaviour
    {
       
        private enum ZoneType
        {
            Collectable,
            Action,
            HoldAction
        }

        private enum KeyState
        {
            Press,
            PressHold
        }

        [SerializeField]
        private ZoneType _zoneType;
        [SerializeField]
        private int _zoneID;
        [SerializeField]
        private int _requiredID;
        [SerializeField]
        [Tooltip("Press the (---) Key to .....")]
        private string _displayMessage;
        [SerializeField]
        private GameObject[] _zoneItems;
        private bool _inZone = false;
        private bool _itemsCollected = false;
        private bool _actionPerformed = false;
        [SerializeField]
        private Sprite _inventoryIcon;
        [SerializeField]
        private KeyCode _zoneKeyInput;
        [SerializeField]
        private KeyState _keyState;
        [SerializeField]
        private GameObject _marker;

        private bool _inHoldState = false;

        private static int _currentZoneID = 0;
        public static int CurrentZoneID
        { 
            get 
            { 
               return _currentZoneID; 
            }
            set
            {
                _currentZoneID = value; 
                         
            }
        }


        public static event Action<InteractableZone> onZoneInteractionComplete;
        public static event Action<int> onHoldStarted;
        public static event Action<int> onHoldEnded;

        private void OnEnable()
        {
            InteractableZone.onZoneInteractionComplete += SetMarker;
           

        }
    
        private void OnTriggerEnter(Collider other)
        {
           
            Debug.Log($"OnTriggerEnter: player entered zone {_zoneID} | currentID: {_currentZoneID}, requiredID: {_requiredID}, zoneType: {_zoneType}");

    if (other.CompareTag("Player") && _currentZoneID > _requiredID)
    {
                InputManager inputManager = FindObjectOfType<InputManager>();//findins specific obj with classe
                if (inputManager != null)//Best practice check
                    inputManager.SetCurrentInteractableZone(this); // identify self
                Debug.Log("Passed the zone requirement check");          
                switch (_zoneType)
                {
                    case ZoneType.Collectable:
                        if (_itemsCollected == false)
                        {
                            Debug.Log("C4 Zonetype working!");
                            _inZone = true;
                            if (_displayMessage != null)
                            {
                                string message = $"Press the {_zoneKeyInput.ToString()} key to {_displayMessage}.";
                                UIManager.Instance.DisplayInteractableZoneMessage(true, message);
                            }
                            else
                                UIManager.Instance.DisplayInteractableZoneMessage(true, $"Press the {_zoneKeyInput.ToString()} key to collect");
                        }
                        break;
                     //Drone interctable 
                    case ZoneType.Action:
                   
                        if (_actionPerformed == false)
                        {

                            Debug.Log("Action Zonetype working!");
                            _inZone = true;
                            
                            if (_displayMessage != null)
                            {
                                string message = $"Press the {_zoneKeyInput.ToString()} key to {_displayMessage}.";
                                UIManager.Instance.DisplayInteractableZoneMessage(true, message);
                            }
                            else
                                UIManager.Instance.DisplayInteractableZoneMessage(true, $"Press the {_zoneKeyInput.ToString()} key to perform action");
                        }
                        break;

                    case ZoneType.HoldAction:
                        _inZone = true;
                        if (_displayMessage != null)
                        {
                            string message = $"Press the {_zoneKeyInput.ToString()} key to {_displayMessage}.";
                            UIManager.Instance.DisplayInteractableZoneMessage(true, message);
                        }
                        else
                            UIManager.Instance.DisplayInteractableZoneMessage(true, $"Hold the {_zoneKeyInput.ToString()} key to perform action");
                        break;
                }
            }
        }

        private void Update()
        {
          
            //--> The following switch cases can be refactored into public methods to be called from the Input Manager

            /*public method PressAction
            if (_inZone == true) //needs to be pre
            {
                  if (Input.GetKeyDown(_zoneKeyInput) && _keyState != KeyState.PressHold)//we dont need to validate the hold, so this is unnessary 
                {
                    //One-clik Action - Collect Items, enter vehicles 
                    switch (_zoneType)
                    {
                        case ZoneType.Collectable:
                            if (_itemsCollected == false)
                            {
                                CollectItems();
                                _itemsCollected = true;
                                UIManager.Instance.DisplayInteractableZoneMessage(false);
                            }
                            break;

                        case ZoneType.Action:
                            if (_actionPerformed == false)
                            {
                                PerformAction();
                                _actionPerformed = true;
                                UIManager.Instance.DisplayInteractableZoneMessage(false);
                            }
                            break;
                    }
                }
                // Hold Action - Hack Cameras
             
                else if (Input.GetKey(_zoneKeyInput) && _keyState == KeyState.PressHold && _inHoldState == false)
                {
                    _inHoldState = true;

                   

                    switch (_zoneType)
                    {                      
                        case ZoneType.HoldAction:
                            PerformHoldAction();
                            break;           
                    }
                }
                //Cancel action - reset/deplete progress bar
                if (Input.GetKeyUp(_zoneKeyInput) && _keyState == KeyState.PressHold)
                {
                    _inHoldState = false;
                    onHoldEnded?.Invoke(_zoneID);
                }

               
            }*/
        }

        private void Interact_HoldKey_canceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            KeyReleaseAction();
        }

        private void Interact_HoldKey_started(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            KeyHoldAction();
        }

        private void Interact_PressKey_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            KeyPressAction();
        }

        //Switch Action Methods --> Called from the InputManager Script
        public void KeyPressAction()
        {
            //Actions that require a single key press
            Debug.Log("Key Press Method");
            if (_inZone  == true)

            switch (_zoneType)
            {
                case ZoneType.Collectable:
                    if (!_itemsCollected)
                    {
                        CollectItems();
                        _itemsCollected = true;
                        UIManager.Instance.DisplayInteractableZoneMessage(false);
                    }
                    break;

                case ZoneType.Action:
                    if (!_actionPerformed)
                    {
                        PerformAction();
                        _actionPerformed = true;
                        UIManager.Instance.DisplayInteractableZoneMessage(false);
                    }
                    break;
            }
        }
        public void KeyHoldAction()
        {
            //Actions that require the key to be held down
            if (_inZone == true || _keyState == KeyState.PressHold || _inHoldState)

            _inHoldState = true;

            if (_zoneType == ZoneType.HoldAction)
                PerformHoldAction();

        }
        public void KeyReleaseAction()
        {
            //To cancel the Hold Action and reset the progress bar
            if (_keyState == KeyState.PressHold)
            {
                _inHoldState = false;
                onHoldEnded?.Invoke(_zoneID);
            }

        }
      
        public void CollectItems()
        {
            foreach (var item in _zoneItems)
            {
                item.SetActive(false);
            }

            UIManager.Instance.UpdateInventoryDisplay(_inventoryIcon);

            CompleteTask(_zoneID);

            onZoneInteractionComplete?.Invoke(this);

        }

        public void PerformAction()
        {
            foreach (var item in _zoneItems)
            {
                item.SetActive(true);
            }

            if (_inventoryIcon != null)
                UIManager.Instance.UpdateInventoryDisplay(_inventoryIcon);

            onZoneInteractionComplete?.Invoke(this);
        }

        public void PerformHoldAction()
        {
            UIManager.Instance.DisplayInteractableZoneMessage(false);
            onHoldStarted?.Invoke(_zoneID);
        }

        public GameObject[] GetItems()
        {
            return _zoneItems;
        }

        public int GetZoneID()
        {
            return _zoneID;
        }

        public void CompleteTask(int zoneID)
        {
            if (zoneID == _zoneID)
            {
                _currentZoneID++;
                onZoneInteractionComplete?.Invoke(this);
            }
        }

        public void ResetAction(int zoneID)
        {
            if (zoneID == _zoneID)
                _actionPerformed = false;
        }

        public void SetMarker(InteractableZone zone)
        {
            if (_zoneID == _currentZoneID)
                _marker.SetActive(true);
            else
                _marker.SetActive(false);
        }


        private void OnTriggerExit(Collider other)
        {
            /*if (other.CompareTag("Player"))
            {
                //here we should show the UI message instead of the case
                _inZone = false; //this was set to false making the drone unusable 
                UIManager.Instance.DisplayInteractableZoneMessage(false);//let's
               
            }*/
            if (other.CompareTag("Player"))
            {
                _inZone = false;
                UIManager.Instance.DisplayInteractableZoneMessage(false);

                InputManager inputManager = FindObjectOfType<InputManager>();
                if (inputManager != null)
                    inputManager.SetCurrentInteractableZone(null); // reset zone 

            }
        }

        private void OnDisable()
        {
            InteractableZone.onZoneInteractionComplete -= SetMarker;
        }       
        
    }
}


