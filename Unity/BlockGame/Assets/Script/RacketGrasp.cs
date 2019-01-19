using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketGrasp : MonoBehaviour
{
    private Vector3 racketScreenPosition;
    private Vector3 offset;
    
	
    void OnMouseDown()
    {
        racketScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, racketScreenPosition.z));
    }

    void OnMouseDrag()
    {

        Vector3 racketPosition //offsetを一定に保つイメージ
            = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, racketScreenPosition.z))+ this.offset ;

        transform.position = new Vector3(racketPosition.x,transform.position.y,transform.position.z);
        //y座標とz座標はInspectorで設定した値に固定したままx座標を変更

        ClampX();
    }

    void ClampX()//xの範囲を制限
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -6.3f, 6.3f);
        transform.position = pos;
    }
}
