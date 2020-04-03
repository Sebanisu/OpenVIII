using System.Diagnostics.CodeAnalysis;
using OpenVIII.IGMDataItem;

namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// I think this sets the outfit you use in battle.
    /// <para>Squall, Selphie, and Zell, have normal and Seed uniforms</para>
    /// <para>Laguna, Kiros, and Ward, have normal and Galbadia uniforms</para>
    /// <para>Everyone else has 1 uniform in battle.</para>
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/0FB_SETDRESS&action=edit&redlink=1"/>
    public sealed class SetDress : JsmInstruction
    {
        #region Fields

        private readonly IJsmExpression _arg0;
        private readonly IJsmExpression _arg1;

        #endregion Fields

        public Characters Character => ((IConstExpression)_arg0).Characters();
        public int Costume => ((IConstExpression)_arg1).Int32();
        #region Constructors

        public SetDress(IJsmExpression arg0, IJsmExpression arg1)
        {
            _arg0 = arg0;
            _arg1 = arg1;
        }

        public SetDress(IStack<IJsmExpression> stack)
            : this(
                arg1: stack.Pop(),
                arg0: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(SetDress)}({nameof(_arg0)}: {_arg0}, {nameof(_arg1)}: {_arg1})";

        #endregion Methods
    }
}