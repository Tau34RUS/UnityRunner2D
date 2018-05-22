using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swipe : MonoBehaviour {

	// tap + swipe controll
	public bool tap, swipeUp, swipeRight;
	public Vector2 startTouch, swipeDelta;
	public bool Tap { get { return tap; }}
	public Vector2 SwipeDelta {get { return swipeDelta; }}
	public bool SwipeUp {get { return swipeUp; }}
	public bool SwipeRight {get { return swipeRight; }}
	public int minSwipeDistance;
	private bool isDragging = false;



	private void Reset() {

		startTouch = swipeDelta = Vector2.zero;
		isDragging = false;

	}

	private void Update () {

		tap = swipeUp = swipeRight = false;

		//Calculate Distance

		swipeDelta = Vector2.zero;

		if (isDragging) {

			if (Input.touches.Length > 0) {

				swipeDelta = Input.touches [0].position - startTouch;

			}

		}

		//Dead Zone

		if (swipeDelta.magnitude > minSwipeDistance) {

			float x = swipeDelta.x;
			float y = swipeDelta.y;
			if (Mathf.Abs (x) > Mathf.Abs (y)) {
				//Left or Right
				if (x < 0) {

					//Left Swipe Happened

				} else {

					swipeRight = true;

				}
			} else {
				//Up or Down
				if (y < 0) {

					//Swipe Down

				} else {

					swipeUp = true;

				}

			}

			Reset ();

		}

		if (Input.touches.Length > 0) {

			if (Input.touches [0].phase == TouchPhase.Began) {

				isDragging = true;
				tap = true;
				startTouch = Input.touches [0].position;

			} else if (Input.touches [0].phase == TouchPhase.Ended || Input.touches [0].phase == TouchPhase.Canceled) {

				isDragging = false;
				Reset ();

			}
		}

	}

}