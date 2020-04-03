﻿namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// <para>Set Draw Point hidden</para>
    /// <para>If isHidden is bigger or equal to 1, then hides draw point. If not, the draw point is visible.</para>
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/155_SETDRAWPOINT"/>
    public sealed class SetDrawPoint : JsmInstruction
    {
        #region Fields

        private readonly bool _isHidden;

        #endregion Fields

        #region Constructors

        public SetDrawPoint(bool isHidden) => _isHidden = isHidden;

        public SetDrawPoint(int parameter, IStack<IJsmExpression> stack)
            : this(
                isHidden: ((IConstExpression)stack.Pop()).Boolean())
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(SetDrawPoint)}({nameof(_isHidden)}: {_isHidden})";

        #endregion Methods
    }
}