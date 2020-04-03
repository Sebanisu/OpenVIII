﻿namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class FadeSync : JsmInstruction
    {
        #region Constructors

        public FadeSync()
        {
        }

        public FadeSync(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(FadeSync)}()";

        #endregion Methods
    }
}