using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

public class BackgroundManager : MonoBehaviour
{
		public float camMoveBgOffset = 6;
		private List<Transform> bgListHorizontal;
		private List<Transform> bgListVertical;

		void Start ()
		{
				bgListHorizontal = new List<Transform> ();
			
				for (int i = 0; i < transform.childCount; i++) {
						Transform child = transform.GetChild (i);
				
						// Add only the visible children
						if (child.renderer != null) {
								bgListHorizontal.Add (child);
						}
				}
			
				bgListHorizontal = bgListHorizontal.OrderBy (t => t.position.x).ToList ();
				bgListVertical = bgListHorizontal.OrderBy (t => t.position.y).ToList ();
		}
	
		void Update ()
		{

				// Get the first object.
				// The list is ordered from left (x position) to right.
				Transform HChild1 = bgListHorizontal.FirstOrDefault ();
				Transform HChildLast = bgListHorizontal.LastOrDefault ();
				Transform VChild1 = bgListVertical.FirstOrDefault ();
				Transform VChildLast = bgListVertical.LastOrDefault ();
				Vector3 lastSize = (HChildLast.renderer.bounds.max - HChildLast.renderer.bounds.min);
				float camSize = Camera.main.orthographicSize;
				

				if (HChildLast.position.x + lastSize.x / (camMoveBgOffset * camSize / 5) < Camera.main.transform.position.x) {
						Transform HChild2 = bgListHorizontal [1];
						Vector3 lastPosition = HChildLast.transform.position;

						HChild1.position = new Vector3 (lastPosition.x + lastSize.x, HChild1.position.y, HChild1.position.z);
						HChild2.position = new Vector3 (lastPosition.x + lastSize.x, HChild2.position.y, HChild1.position.z);

						bgListHorizontal.Remove (HChild1);
						bgListHorizontal.Remove (HChild2);
						bgListHorizontal.Add (HChild1);
						bgListHorizontal.Add (HChild2);
				} else if (HChild1.position.x - lastSize.x / (camMoveBgOffset * camSize / 5) > Camera.main.transform.position.x) {
						Transform HChild2 = bgListHorizontal [1];
						Vector3 lastPosition = HChildLast.transform.position;
				
						HChild1.position = new Vector3 (lastPosition.x - lastSize.x, HChild1.position.y, HChild1.position.z);
						HChild2.position = new Vector3 (lastPosition.x - lastSize.x, HChild2.position.y, HChild1.position.z);
				
						bgListHorizontal.Remove (HChild1);
						bgListHorizontal.Remove (HChild2);
						bgListHorizontal.Add (HChild1);
						bgListHorizontal.Add (HChild2);

				}

				if (VChildLast.position.y + lastSize.y / (camMoveBgOffset * camSize / 5) < Camera.main.transform.position.y) {
						Transform VChild2 = bgListVertical [1];
						Vector3 lastPosition = VChildLast.transform.position;
			
						VChild1.position = new Vector3 (VChild1.position.x, lastPosition.y + lastSize.y, VChild1.position.z);
						VChild2.position = new Vector3 (VChild2.position.x, lastPosition.y + lastSize.y, VChild1.position.z);

						bgListVertical.Remove (VChild1);
						bgListVertical.Remove (VChild2);
						bgListVertical.Add (VChild1);
						bgListVertical.Add (VChild2);

				} else if (VChild1.position.y - lastSize.y / (camMoveBgOffset * camSize / 5) > Camera.main.transform.position.y) {
						Transform VChild2 = bgListVertical [1];
						Vector3 lastPosition = VChildLast.transform.position;

						VChild1.position = new Vector3 (VChild1.position.x, lastPosition.y - lastSize.y, VChild1.position.z);
						VChild2.position = new Vector3 (VChild2.position.x, lastPosition.y - lastSize.y, VChild1.position.z);

						bgListVertical.Remove (VChild1);
						bgListVertical.Remove (VChild2);
						bgListVertical.Add (VChild1);
						bgListVertical.Add (VChild2);
			
				}

				
		}
}

