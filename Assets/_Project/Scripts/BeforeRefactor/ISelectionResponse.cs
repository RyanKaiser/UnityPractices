using UnityEngine;

namespace BeforRefactor
{
    internal interface ISelectionResponse
    {
        void OnDeselected(Transform selection);
        void OnSelected(Transform selection);
    }
}