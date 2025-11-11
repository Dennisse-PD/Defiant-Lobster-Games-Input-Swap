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
        //Added to validate in Break function 
        private bool _isSet;

        private List<Rigidbody> _brakeOff = new List<Rigidbody>();

        private void OnEnable()
        {
            InteractableZone.onZoneInteractionComplete += InteractableZone_onZoneInteractionComplete;
        }

        private void InteractableZone_onZoneInteractionComplete(InteractableZone zone)
        { 
            //I need the conditions in this to validate for the input manager, if not it happens outside of the zone
            if (_isReadyToBreak == false && _brakeOff.Count > 0)
            {
                _wholeCrate.SetActive(false);
                _brokenCrate.SetActive(true);
                _isReadyToBreak = true;
            }

            if (_isReadyToBreak && zone.GetZoneID() == 6) //Crate zone            
            {
                if (_brakeOff.Count > 0)
                {
                    _isSet = true; //added to validate directly in break function
                    BreakPart(1f);
                    StartCoroutine(PunchDelay());
                    //we could start a routine for the hold break here if neccessary 
                }
                else if (_brakeOff.Count == 0)
                {
                    Debug.Log("Count should be 0");
;                    crateBroken();
                }
            }
        }
        private void crateBroken()
        {

            _isReadyToBreak = false;
            _crateCollider.enabled = false;
            _interactableZone.CompleteTask(6);
            Debug.Log("Completely Busted");
        }

        private void Start()
        {
            _brakeOff.AddRange(_pieces);

        }

        public void BreakPart(float forceMult, int piecesToBreak = 1)
        {
            if (_isSet != true) return;

            // clamp to available pieces
            int breakCount = Mathf.Min(piecesToBreak, _brakeOff.Count);

            for (int i = 0; i < breakCount; i++)
            {
                if (_brakeOff.Count == 0) break;

                int rng = Random.Range(0, _brakeOff.Count);
                Rigidbody piece = _brakeOff[rng];

                piece.constraints = RigidbodyConstraints.None;
                piece.AddForce(Random.insideUnitSphere * forceMult, ForceMode.Impulse);

                _brakeOff.RemoveAt(rng);
            }
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
