namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Loops the given frames of an animation. Resume script, Play controlled looping animation
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/036_RCANIMELOOP"/>
    public sealed class RCAnimeLoop : Abstract.AnimeLoop
    {
        #region Constructors

        public RCAnimeLoop(int parameter, IStack<IJsmExpression> stack) : base(parameter, stack)
        {
        }

        public RCAnimeLoop(int animationId, int firstFrame, int lastFrame) : base(animationId, firstFrame, lastFrame)
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(RCAnimeLoop)}({nameof(AnimationId)}: {AnimationId}, {nameof(FirstFrame)}: {FirstFrame}, {nameof(LastFrame)}: {LastFrame})";

        #endregion Methods
    }
}