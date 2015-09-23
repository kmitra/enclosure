using UnityEngine;
using System.Collections;
using DG.Tweening;

public class ColorStreamController : MonoBehaviour {

	private ColorStream colorStreamData;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetColorStreamData(ColorStream data) {

		this.colorStreamData = data;
	}

	public void StartMoving() {
	
		float startPosX = 0;
		float startPosY = 0;
		bool isHorizontal = this.colorStreamData.IsDirectionHorizontal();

		if(isHorizontal) {

			Vector3 vecEnd = Vector3.zero;

			if(this.colorStreamData.direction == MOVE_DIRECTION.MOVE_RIGHT) {
			
				startPosX = GameConstants.EDGE_LEFT;
				startPosY = IngameUtils.GetInstance().GetStreamStartPositionFromLine(this.colorStreamData.startingLine, isHorizontal);

				vecEnd = new Vector3(GameConstants.EDGE_RIGHT, startPosY, 0);
			}
			else if(this.colorStreamData.direction == MOVE_DIRECTION.MOVE_LEFT) {

				startPosX = GameConstants.EDGE_RIGHT;
				startPosY = IngameUtils.GetInstance().GetStreamStartPositionFromLine(this.colorStreamData.startingLine, isHorizontal);

				vecEnd = new Vector3(GameConstants.EDGE_LEFT, startPosY, 0);
			}

			this.gameObject.transform.localPosition = new Vector3(startPosX, startPosY, 0);
			Tweener tmpTweener = this.gameObject.transform.DOLocalMove(vecEnd, IngameUtils.GetInstance().speedHoriz);
			tmpTweener.SetLoops(-1);
			tmpTweener.SetEase(Ease.Linear);
		}
	}
}
