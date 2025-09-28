using UnityEngine;

namespace AfterRefactor
{
    internal interface ISelectionResponse
    {
        void OnSelect(Transform selection);
        void OnDeselect(Transform selection);
    }
}