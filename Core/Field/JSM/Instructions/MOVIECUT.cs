﻿using System;


namespace OpenVIII
{
    internal sealed class MOVIECUT : JsmInstruction
    {
        public MOVIECUT()
        {
        }

        public MOVIECUT(Int32 parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        public override String ToString()
        {
            return $"{nameof(MOVIECUT)}()";
        }
    }
}