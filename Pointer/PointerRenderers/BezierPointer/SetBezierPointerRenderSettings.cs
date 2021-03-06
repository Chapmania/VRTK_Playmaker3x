// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK")]
	[Tooltip("Set Bezier Pointer render settings.")]

	public class SetBezierPointerRenderSettings : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_BezierPointerRenderer))]    
		public FsmOwnerDefault gameObject;

		public FsmFloat heightLimitAngle;
		public FsmFloat curveOffset;
		public FsmBool rescaleTracer;
		public FsmBool cursorMatchTargetRotation;
		public FsmInt collisionCheckFrequency;

		public FsmBool everyFrame;

		VRTK.VRTK_BezierPointerRenderer theScript;

		public override void Reset()
		{

			heightLimitAngle = null;
			curveOffset = null;
			rescaleTracer = false;
			cursorMatchTargetRotation = false;
			collisionCheckFrequency = null;
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

			theScript.heightLimitAngle = heightLimitAngle.Value;
			theScript.curveOffset = curveOffset.Value;
			theScript.rescaleTracer = rescaleTracer.Value;
			theScript.cursorMatchTargetRotation = cursorMatchTargetRotation.Value;
			theScript.collisionCheckFrequency = collisionCheckFrequency.Value;
		}

	}
}