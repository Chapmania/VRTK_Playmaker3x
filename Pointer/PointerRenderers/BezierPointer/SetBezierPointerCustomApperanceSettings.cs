// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK")]
	[Tooltip("Set Bezier Pointer custom appearance settings.")]

	public class SetBezierPointerCustomApperanceSettings : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_BezierPointerRenderer))]    
		public FsmOwnerDefault gameObject;

		public FsmGameObject customCursor;
		public FsmGameObject customTracer;
		public FsmGameObject validLocationObject;
		public FsmGameObject invalidLocationObject;
		public FsmBool everyFrame;
	

		VRTK.VRTK_BezierPointerRenderer theScript;

		public override void Reset()
		{

			customCursor = null;
			customTracer = null;
			validLocationObject = null;
			invalidLocationObject = null;
			gameObject = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);


			theScript = go.GetComponent<VRTK.VRTK_BezierPointerRenderer>();

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

			theScript.customCursor = customCursor.Value;
			theScript.customTracer = customTracer.Value;
			theScript.validLocationObject = validLocationObject.Value;
			theScript.invalidLocationObject = invalidLocationObject.Value;
		}

	}
}