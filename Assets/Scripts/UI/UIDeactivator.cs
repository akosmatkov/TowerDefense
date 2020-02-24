using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TowerDefense.UI
{
    public class UIDeactivator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private bool isPointerEnter = false;

        public void OnPointerEnter(PointerEventData eventData)
        {
            isPointerEnter = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            isPointerEnter = false;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (isPointerEnter == false)
                {
                    gameObject.SetActive(false);
                }
                else return;
            }
        }

        public void SetIsPointerEnter()
        {
            isPointerEnter = false;
        }
    }
}
