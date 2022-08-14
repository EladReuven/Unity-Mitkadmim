using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Controllers.States
{
    public class PlayerStateController : MonoBehaviour
    {
        const string INPUT_FIRE_1 = "Fire1";
        const string INPUT_FIRE_2 = "Fire2";
        const string INPUT_FIRE_3 = "Fire3";
        const string INPUT_FIRE_4 = "Fire4";
        const string VERTICAL_AXIS = "Vertical";
        const string HORIZONTAL_AXIS = "Horizontal";

        public UnityEvent<PlayerState> OnStateChange;
        public PlayerState state;
        public string currentStae;

        private void Awake()
        {
            SetState(new IdleState());
        }


        private void Update()
        {
            HandleInput();
            HandleState();
        }

        void SetState(PlayerState state)
        {
            this.state = state;
            currentStae = state.ToString();
        }


        public void HandleInput()
        {

            if (Input.GetButtonDown(INPUT_FIRE_1))
            {
                SetState(new AttackHoldState());
                return;
            }

            if ((Input.GetButtonUp(INPUT_FIRE_1)))
            {
                var tempState = state as AttackHoldState;
                if (tempState == null) return;
                SetState(new AttackReleaseState(tempState.holdTime));
                return;
            }

            var movement = new Vector2(Input.GetAxis(VERTICAL_AXIS), Input.GetAxis(HORIZONTAL_AXIS));
            if (movement.magnitude > 0)
            {
                SetState(new MoveState(movement));
                return;
            }
        }
        public void HandleState()
        {
            state.Update();
        }

    }

}

