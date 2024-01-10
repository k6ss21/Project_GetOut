using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

		public bool mouseLock = false;
		public bool moveLock = false;

#if ENABLE_INPUT_SYSTEM
		public void OnMove(InputValue value)
		{
			if (!moveLock)
			{
				MoveInput(value.Get<Vector2>());
			}
		}

		public void OnLook(InputValue value)
		{
			if (!mouseLock)
			{
				if (cursorInputForLook)
				{
					LookInput(value.Get<Vector2>());
				}
			}
		}

		public void OnJump(InputValue value)
		{
			if (!moveLock)
			{
				JumpInput(value.isPressed);
			}
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}
#endif


		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		}

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}

		public void LockMovement(bool value)
		{
			moveLock = value;
			move = Vector2.zero;
		}
		public void LockMouse(bool value)
		{
			mouseLock = value;
			look = Vector2.zero;
		}
		public void LockCursor(bool value)
		{
			cursorLocked = value;
			SetCursorState(cursorLocked);
		}

	}
}
