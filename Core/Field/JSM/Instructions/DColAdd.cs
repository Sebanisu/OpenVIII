using Microsoft.Xna.Framework;

namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class DColAdd : JsmInstruction
    {
        #region Fields

        private readonly IJsmExpression _b;
        private readonly IJsmExpression _g;
        private readonly IJsmExpression _r;

        #endregion Fields

        #region Constructors

        public DColAdd(IJsmExpression r, IJsmExpression g, IJsmExpression b)
        {
            _r = r;
            _g = g;
            _b = b;
        }

        public DColAdd(int parameter, IStack<IJsmExpression> stack)
            : this(
                b: stack.Pop(),
                g: stack.Pop(),
                r: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .StaticType(nameof(IRenderingService))
                .Method(nameof(IRenderingService.AddScreenColor))
                .Argument("r", _r)
                .Argument("g", _g)
                .Argument("b", _b)
                .Comment(nameof(DColAdd));

        public override IAwaitable TestExecute(IServices services)
        {
            ServiceId.Rendering[services].AddScreenColor(
                new Color(
                    _r.Int32(services),
                    _g.Int32(services),
                    _b.Int32(services)));
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(DColAdd)}({nameof(_r)}: {_r}, {nameof(_g)}: {_g}, {nameof(_b)}: {_b})";

        #endregion Methods
    }
}