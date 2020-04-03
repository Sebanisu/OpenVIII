using System.Diagnostics.CodeAnalysis;

namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Key Signature Change, only used on test, on test only set to 1
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/150_KEYSIGHNCHANGE&action=edit&redlink=1"/>
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    public sealed class KeySighnChange : JsmInstruction
    {
        #region Fields

        private readonly IJsmExpression _arg0;

        #endregion Fields

        #region Constructors

        public KeySighnChange(IJsmExpression arg0) => _arg0 = arg0;

        public KeySighnChange(int parameter, IStack<IJsmExpression> stack)
            : this(
                arg0: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(KeySighnChange)}({nameof(_arg0)}: {_arg0})";

        #endregion Methods
    }
}