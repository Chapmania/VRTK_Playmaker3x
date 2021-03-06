// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK")]
	[Tooltip("Gets which gameobject (usually a controller) is grabbing an interactable object.")]

	public class  GetGrabbedObjectsGameobject : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_InteractableObject))]    
		public FsmOwnerDefault gameObject;

		[Tooltip("Gets which gameobject is doing the grabbing")]
		[ArrayEditor(VariableType.GameObject)]
		public FsmGameObject gameobjectBeingGrabbed;

		public FsmBool everyFrame;

		VRTK.VRTK_InteractableObject theScript;

		public override void Reset()
		{

			gameobjectBeingGrabbed = null;
			gameObject = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);


			theScript = go.GetComponent<VRTK.VRTK_InteractableObject>();

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

			gameobjectBeingGrabbed.Value = theScript.GetGrabbingObject();

		}

	}
}