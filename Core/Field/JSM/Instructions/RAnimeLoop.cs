namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Resume script, Play looping animation
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/035_RANIMELOOP"/>
    public sealed class RAnimeLoop : Abstract.Anime
    {
        #region Constructors

        public RAnimeLoop(int animationId) : base(animationId)
        {
        }

        public RAnimeLoop(int animationId, IStack<IJsmExpression> stack) : base(animationId)
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(RAnimeLoop)}({nameof(AnimationId)}: {AnimationId})";

        #endregion Methods
    }
}