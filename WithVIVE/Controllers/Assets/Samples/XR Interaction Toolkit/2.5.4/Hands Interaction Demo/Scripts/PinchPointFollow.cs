using Unity.XR.CoreUtils;
using Unity.XR.CoreUtils.Bindings;
using UnityEngine.XR.Hands;
using UnityEngine.XR.Interaction.Toolkit.Utilities.Tweenables.Primitives;

namespace UnityEngine.XR.Interaction.Toolkit.Samples.Hands
{
    public class PinchPointFollow : MonoBehaviour
    {
        [SerializeField]
        XRHandTrackingEvents m_XRHandTrackingEvents;

        [SerializeField]
        Transform m_TargetRotation;

        [SerializeField]
        XRRayInteractor m_RayInteractor;

        [SerializeField]
        float m_RotationSmoothingSpeed = 12f;

        [SerializeField]
        float m_PinchThreshold = 0.5f; // Adjust as needed

        bool m_HasRayInteractor;
        bool m_HasTargetRotationTransform;

        OneEuroFilterVector3 m_OneEuroFilterVector3;
        readonly QuaternionTweenableVariable m_QuaternionTweenableVariable = new QuaternionTweenableVariable();
        readonly BindingsGroup m_BindingsGroup = new BindingsGroup();

        void OnEnable()
        {
            if (m_XRHandTrackingEvents != null)
                m_XRHandTrackingEvents.jointsUpdated.AddListener(OnJointsUpdated);

            m_OneEuroFilterVector3 = new OneEuroFilterVector3(transform.localPosition);
            m_HasRayInteractor = m_RayInteractor != null;
            m_HasTargetRotationTransform = m_TargetRotation != null;
            m_BindingsGroup.AddBinding(m_QuaternionTweenableVariable.Subscribe(newValue => transform.rotation = newValue));
        }

        void OnDisable()
        {
            m_BindingsGroup.Clear();
            if (m_XRHandTrackingEvents != null)
                m_XRHandTrackingEvents.jointsUpdated.RemoveListener(OnJointsUpdated);
        }

        void OnJointsUpdated(XRHandJointsUpdatedEventArgs args)
        {
            var thumbTip = args.hand.GetJoint(XRHandJointID.ThumbTip);
            if (!thumbTip.TryGetPose(out var thumbTipPose))
                return;

            var indexTip = args.hand.GetJoint(XRHandJointID.IndexTip);
            if (!indexTip.TryGetPose(out var indexTipPose))
                return;

            var distance = Vector3.Distance(thumbTipPose.position, indexTipPose.position);

            if (distance < m_PinchThreshold)
            {
                // Pinch gesture detected
                // You can add your pinch behavior here
                Debug.Log("Pinch gesture detected!");
            }

            var targetPos = Vector3.Lerp(thumbTipPose.position, indexTipPose.position, 0.5f);
            var filteredTargetPos = m_OneEuroFilterVector3.Filter(targetPos, Time.deltaTime);
            
            transform.localPosition = filteredTargetPos;

            if (m_HasTargetRotationTransform && m_HasRayInteractor)
            {
                var targetDir = (m_RayInteractor.rayEndPoint - transform.position).normalized;
                var targetRot = Quaternion.LookRotation(targetDir);
                
                if (Vector3.Dot(m_TargetRotation.forward, targetDir) > 0.5f)
                    m_QuaternionTweenableVariable.target = targetRot;
            }

            var tweenTarget = m_RotationSmoothingSpeed > 0f ? m_RotationSmoothingSpeed * Time.deltaTime : 1f;
            m_QuaternionTweenableVariable.HandleTween(tweenTarget);
        }
    }
}
