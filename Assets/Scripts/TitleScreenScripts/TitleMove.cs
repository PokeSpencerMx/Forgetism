using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMove : MonoBehaviour
{
    [SerializeField] private RectTransform endMove;
    [SerializeField] private RectTransform titlePos;

    void Start()
    {
        //titlePos.DOMove(endMove.position, 0.65f).SetEase(Ease.OutBounce);
        titlePos.DOMoveY(850, 2f);
    }

    void Update()
    {

    }
}
