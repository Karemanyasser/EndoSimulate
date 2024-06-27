//======= Copyright (c) Valve Corporation, All rights reserved. ===============

using UnityEngine;
using System.Collections;
using Valve.VR.InteractionSystem;
using System.Collections.Generic;


namespace Valve.VR.InteractionSystem.Sample
{
    public class ButtonClick : MonoBehaviour
    {
        [SerializeField]
        private GameObject door;
        private bool doorOpen;

        public void Interact()
        {
        doorOpen = !doorOpen;
        door.GetComponent<Animator>().SetBool("IsOpen", doorOpen);
        // Debug.Log("Interacted with" + gameObject.name);
        // base.Interact();
        }

        public void AnimateHandWithController()
        {
            for (int handIndex = 0; handIndex < Player.instance.hands.Length; handIndex++)
            {
                Hand hand = Player.instance.hands[handIndex];
                if (hand != null)
                {
                    hand.SetSkeletonRangeOfMotion(Valve.VR.EVRSkeletalMotionRange.WithController);
                }
            }
        }

        public void AnimateHandWithoutController()
        {
            for (int handIndex = 0; handIndex < Player.instance.hands.Length; handIndex++)
            {
                Hand hand = Player.instance.hands[handIndex];
                if (hand != null)
                {
                    hand.SetSkeletonRangeOfMotion(Valve.VR.EVRSkeletalMotionRange.WithoutController);
                }
            }
        }

        public void ShowController()
        {
            for (int handIndex = 0; handIndex < Player.instance.hands.Length; handIndex++)
            {
                Hand hand = Player.instance.hands[handIndex];
                if (hand != null)
                {
                    hand.ShowController(true);
                }
            }
        }

        public void SetRenderModel(RenderModelChangerUI prefabs)
        {
            for (int handIndex = 0; handIndex < Player.instance.hands.Length; handIndex++)
            {
                Hand hand = Player.instance.hands[handIndex];
                if (hand != null)
                {
                    if (hand.handType == SteamVR_Input_Sources.RightHand)
                        hand.SetRenderModel(prefabs.rightPrefab);
                    if (hand.handType == SteamVR_Input_Sources.LeftHand)
                        hand.SetRenderModel(prefabs.leftPrefab);
                }
            }
        }

        public void HideController()
        {
            for (int handIndex = 0; handIndex < Player.instance.hands.Length; handIndex++)
            {
                Hand hand = Player.instance.hands[handIndex];
                if (hand != null)
                {
                    hand.HideController(true);
                }
            }
        }
    }
}