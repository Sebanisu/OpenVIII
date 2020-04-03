using System;

namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class SetGetA : JsmInstruction
    {
        #region Fields

        private readonly int _arg0;

        #endregion Fields

        #region Constructors

        public SetGetA(int arg0) => _arg0 = arg0;

        public SetGetA(int parameter, IStack<IJsmExpression> stack)
            : this(
                arg0: ((IConstExpression)stack.Pop()).Int32())
        {
        }

        #endregion Constructors

        #region Methods

        public override IAwaitable TestExecute(IServices services)
        {
            // TODO: Field script
            Console.WriteLine($"NotImplemented: {nameof(SetGetA)}({_arg0})");
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(SetGetA)}({nameof(_arg0)}: {_arg0})";

        #endregion Methods
    }
}