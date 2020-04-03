namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// BGanime with R and LOOP unsure the structure copied from BGanime assuming they are related.
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/097_RBGANIMELOOP&action=edit&redlink=1"/>
    public sealed class RBGAnimeLoop : Abstract.BGAnime
    {
        #region Constructors

        public RBGAnimeLoop(IJsmExpression firstFrame, IJsmExpression lastFrame) : base(firstFrame, lastFrame)
        {
        }

        public RBGAnimeLoop(int parameter, IStack<IJsmExpression> stack) : base(parameter, stack)
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(RBGAnimeLoop)}({nameof(FirstFrame)}: {FirstFrame}, {nameof(LastFrame)}: {LastFrame})";

        #endregion Methods
    }
}