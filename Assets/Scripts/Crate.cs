using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.LiveObjects
{
    public class Crate : MonoBehaviour
    {
        [SerializeField] private float _punchDelay;
        [SerializeField] private GameObject _wholeCrate, _brokenCrate;
        [SerializeField] private Rigidbody[] _pieces;
        [SerializeField] private BoxCollider _crateCollider;
        [SerializeField] private InteractableZone _interactableZone;
        private bool _isReadyToBreak = false;
        //Force variables for varying in
        [SerializeField] private float _tapForce = 1f; // normal press force
        [SerializeField] private float _maxHoldForce = 5f; // maximum force when held
        [SerializeField] private float _holdChargeRate = 2f; // how fast force increases while holding
        private float _currentHoldForce;
        private bool _isHolding;



        private List<Rigidbody> _brakeOff = new List<Rigidbody>();

        private void OnEnable()
        {
            InteractableZone.onZoneInteractionComplete += InteractableZone_onZoneInteractionComplete;
        }

        private void InteractableZone_onZoneInteractionComplete(InteractableZone zone)
        {
            
            if (_isReadyToBreak == false && _brakeOff.Count >0)
            {
                _wholeCrate.SetActive(false);
                _brokenCrate.SetActive(true);
                _isReadyToBreak = true;
            }

            if (_isReadyToBreak && zone.GetZoneID() == 6) //Crate zone            
            {
                if (_brakeOff.Count > 0)
                {
                    BreakPart(_tapForce);//default to tap force if zone completes without hold
                    StartCoroutine(PunchDelay());
                }
                else if(_brakeOff.Count == 0)
                {
                    _isReadyToBreak = false;
                    _crateCollider.enabled = false;
                    _interactableZone.CompleteTask(6);
                    Debug.Log("Completely Busted");
                }
            }
        }

        private void Start()
        {
            _brakeOff.AddRange(_pieces);
            
        }

        private void Update()//added to actively add force when the codition is met
        {
            // Charges up while holding
            if (_isHolding)
            {
                _currentHoldForce += _holdChargeRate * Time.deltaTime;
                //current force will always be determined by the following values
                _currentHoldForce = Mathf.Clamp(_currentHoldForce, _tapForce, _maxHoldForce);
            }
        }

        public void BreakPart(float forceMult) //parameter added to control how much force is added
        {
            //if (_brakeOff.Count == 0) return; will chekc its usefulness first 
            int rng = Random.Range(0, _brakeOff.Count);
            _brakeOff[rng].constraints = RigidbodyConstraints.None;
            _brakeOff[rng].AddForce(new Vector3(1f, 1f, 1f) * forceMult, ForceMode.Force);
            _brakeOff.Remove(_brakeOff[rng]);            
        }
        // Tap
        public void TapBreak() 
        {
            if (_isReadyToBreak)
                BreakPart(_tapForce);
        }

        // Called when hold starts
        public void StartHoldBreak()
        {
            _isHolding = true;
            _currentHoldForce = _tapForce; // start from default force
        }
        // Called when hold is released
        public void ReleaseHoldBreak()
        {
            if (_isHolding && _isReadyToBreak)
            {
                BreakPart(_currentHoldForce);
                Debug.Log($"Hold Released with force {_currentHoldForce}");
            }

            _isHolding = false;
            _currentHoldForce = 0f;
        }

        IEnumerator PunchDelay()
        {
            float delayTimer = 0;
            while (delayTimer < _punchDelay)
            {
                yield return new WaitForEndOfFrame();
                delayTimer += Time.deltaTime;
            }

            _interactableZone.ResetAction(6);
        }

        private void OnDisable()
        {
            InteractableZone.onZoneInteractionComplete -= InteractableZone_onZoneInteractionComplete;
        }
    }
}
