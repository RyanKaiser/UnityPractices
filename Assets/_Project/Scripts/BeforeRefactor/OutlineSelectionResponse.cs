using UnityEngine;

namespace BeforRefactor
{
    internal class OutlineSelectionResponse : MonoBehaviour, ISelectionResponse
    {
        public void OnDeselected(Transform selection)
        {
            var outline = selection.GetComponent<Outline>();
            if (outline != null) outline.OutlineWidth = 0;
        }

        public void OnSelected(Transform selection)
        {
            var outline = selection.GetComponent<Outline>();
            if (outline != null) outline.OutlineWidth = 10;
        }
    }
}