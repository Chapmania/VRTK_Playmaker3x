// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTKController")]
	[Tooltip("Is used to turn on or off the controller model by enabling or disabling the renderers on the object. It will also work for any custom controllers. It should also not disable any objects being held by the controller if they are a child of the controller object.")]

	public class  toggleControllerVisbility : FsmStateAction

	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_ControllerActions))]    
		public FsmOwnerDefault gameObject;

		[Tooltip("Set controller visibility")]
		public FsmBool toggleController;

		[Title("Held Item")]
		[Tooltip("If an object is being held by the controller then this can be passed through to prevent hiding the grabbed game object as well.")]
		public FsmGameObject controllerGameObject;

		public FsmBool everyFrame;

		VRTK.VRTK_ControllerActions theScript;

		public override void Reset()
		{

			toggleController = false;
			controllerGameObject = null;
			gameObject = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<VRTK.VRTK_ControllerActions>();

			if (!everyFrame.Value)
			{
				MakeItSo();
				Finish();
			}

		}

		public override void OnUpdate()
		{
			if (everyFrame.Value)
			{
				MakeItSo();
			}
		}


		void MakeItSo()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}

			theScript.ToggleControllerModel(toggleController.Value, controllerGameObject.Value);
		}

	}
}