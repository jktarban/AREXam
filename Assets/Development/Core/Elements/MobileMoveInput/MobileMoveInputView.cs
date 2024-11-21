using System;
using Development.Public.Mvp;
using UnityEngine;

namespace Development.Core.Elements.MobileMoveInput
{
    [Serializable]
    public class MobileMoveInputView : BaseView<MobileMoveInputViewReferences>
    {
        public Camera Camera => ViewReferences.Camera;

        public void ShowInputText(string text)
        {
            ViewReferences.InputText.text = text;
        }
    }
}