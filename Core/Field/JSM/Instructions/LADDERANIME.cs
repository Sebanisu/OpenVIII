namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// ladder climbing animation?
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/037_LADDERANIME"/>
    public sealed class LadderAnime : JsmInstruction
    {
        #region Fields

        private readonly IJsmExpression _arg0;
        private readonly IJsmExpression _arg1;
        private readonly int _parameter;

        #endregion Fields

        #region Constructors

        public LadderAnime(int parameter, IJsmExpression arg0, IJsmExpression arg1)
        {
            _parameter = parameter;
            _arg0 = arg0;
            _arg1 = arg1;
        }

        public LadderAnime(int parameter, IStack<IJsmExpression> stack)
            : this(parameter,
                arg1: stack.Pop(),
                arg0: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(LadderAnime)}({nameof(_parameter)}: {_parameter}, {nameof(_arg0)}: {_arg0}, {nameof(_arg1)}: {_arg1})";

        #endregion Methods
    }
}