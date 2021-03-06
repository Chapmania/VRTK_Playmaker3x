// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK")]
	[Tooltip("Set Bezier Pointer custom appearance settings.")]

	public class SetUiCanvas : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_UICanvas))]    
		public FsmOwnerDefault gameObject;
		public FsmBool everyFrame;
		public FsmBool clickOnPointerCollision;
		public FsmFloat autoActivateWithinDistance;
	

		VRTK.VRTK_UICanvas theScript;

		public override void Reset()
		{

			autoActivateWithinDistance = null;
			clickOnPointerCollision = false;
			gameObject = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);


			theScript = go.GetComponent<VRTK.VRTK_UICanvas>();

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

			theScript.clickOnPointerCollision = clickOnPointerCollision.Value;
			theScript.autoActivateWithinDistance = autoActivateWithinDistance.Value;
		}

	}
}