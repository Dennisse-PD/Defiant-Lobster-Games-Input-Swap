using System;
using UnityEngine;
using Cinemachine;

namespace Game.Scripts.LiveObjects
{
    public class Forklift : MonoBehaviour
    {
        [SerializeField]
        private GameObject _lift, _steeringWheel, _leftWheel, _rightWheel, _rearWheels;
        [SerializeField]
        private Vector3 _liftLowerLimit, _liftUpperLimit;
        [SerializeField]
        private float _speed = 5f, _liftSpeed = 1f;
        [SerializeField]
        private CinemachineVirtualCamera _forkliftCam;
        [SerializeField]
        private GameObject _driverModel;
        private bool _inDriveMode = false;
        [SerializeField]
        private InteractableZone _interactableZone;

        public static event Action onDriveModeEntered;
        public static event Action onDriveModeExited;

        //Input manager to enable and disable input maps
        [SerializeField]
        private InputManager _inputManager;

        private void OnEnable()
        {
            InteractableZone.onZoneInteractionComplete += EnterDriveMode;
        }

        private void EnterDriveMode(InteractableZone zone)
        {
            Debug.Log("Drive mode is active");
            if (_inDriveMode !=true && zone.GetZoneID() == 5) //Enter ForkLift
            {
                _inDriveMode = true;
                _forkliftCam.Priority = 11;
                onDriveModeEntered?.Invoke();
                _driverModel.SetActive(true);
                _interactableZone.CompleteTask(5);
                //Initialize forklift here
                _inputManager.InitializeForkliftInput();
            }
        }

       public void ExitDriveMode()
        {
            _inDriveMode = false;
            _forkliftCam.Priority = 9;            
            _driverModel.SetActive(false);
            onDriveModeExited?.Invoke();
           
            
        }

        private void Update()
        {
            if (_inDriveMode == true)//validation not needed since the Action Map being active already tells us this is true
            {
                //LiftControls();
             //   CalcutateMovement();
              // if (Input.GetKeyDown(KeyCode.Escape))//UPGRADE
                // ExitDriveMode();
            }

        }

        public void CalcutateMovement(Vector2 inputValue) //made public so that it can be called from the InputManager
        {
            //float h = Input.GetAxisRaw("Horizontal");
            //float v = Input.GetAxisRaw("Vertical");

            //Rotation will be calculate using the input value we register in the Input Manager
            float h = inputValue.x; 
            float v = inputValue.y;

            var direction = new Vector3(0, 0, v);
            var velocity = direction * _speed;

            transform.Translate(velocity * Time.deltaTime);

            if (Mathf.Abs(v) > 0)
            {
                var tempRot = transform.rotation.eulerAngles;
                tempRot.y += h * _speed / 2;
                transform.rotation = Quaternion.Euler(tempRot);
            }
        }

        /* private void LiftControls() --->Refactored into the LiftRoutine Method
         {
                 if (Input.GetKey(KeyCode.R))
                     LiftUpRoutine();
                 else if (Input.GetKey(KeyCode.T))
                     LiftDownRoutine();


         }*/

        /*public void LiftUpRoutine() ---> Refactured into the LiftRoutine Method
        {
            if (_lift.transform.localPosition.y < _liftUpperLimit.y)
            {
                Vector3 tempPos = _lift.transform.localPosition;
                tempPos.y += Time.deltaTime * _liftSpeed;
                _lift.transform.localPosition = new Vector3(tempPos.x, tempPos.y, tempPos.z);
            }
            else if (_lift.transform.localPosition.y >= _liftUpperLimit.y)
                _lift.transform.localPosition = _liftUpperLimit;
        }

        public void LiftDownRoutine() //
        {
            if (_lift.transform.localPosition.y > _liftLowerLimit.y)
            {
                Vector3 tempPos = _lift.transform.localPosition;
                tempPos.y -= Time.deltaTime * _liftSpeed;
                _lift.transform.localPosition = new Vector3(tempPos.x, tempPos.y, tempPos.z);
            }
            else if (_lift.transform.localPosition.y <= _liftUpperLimit.y)
                _lift.transform.localPosition = _liftLowerLimit;
        }*/
        public void LiftRoutine(float liftInput) //---> Will read float values from 1D Axis Input between -1f-1f
        {
           

            Vector3 tempPos = _lift.transform.localPosition;
            tempPos.y += liftInput * Time.deltaTime * _liftSpeed;
            tempPos.y = Mathf.Clamp(tempPos.y, _liftLowerLimit.y, _liftUpperLimit.y); //Clamp within range
            _lift.transform.localPosition = tempPos;
        }

        private void OnDisable()
        {
            InteractableZone.onZoneInteractionComplete -= EnterDriveMode;
        }

    }
}