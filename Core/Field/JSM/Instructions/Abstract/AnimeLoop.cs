namespace OpenVIII.Fields.Scripts.Instructions.Abstract
{
    public abstract class AnimeLoop : Anime
    {
        #region Fields

        /// <summary>
        /// First frame of animation
        /// </summary>
        protected readonly int FirstFrame;

        /// <summary>
        /// Last frame of animation
        /// </summary>
        protected readonly int LastFrame;

        #endregion Fields

        #region Constructors

        protected AnimeLoop(int animationId, int firstFrame, int lastFrame) : base(animationId)
        {
            FirstFrame = firstFrame;
            LastFrame = lastFrame;
        }

        protected AnimeLoop(int animationId, IStack<IJsmExpression> stack)
            : this(animationId,
                lastFrame: ((IConstExpression)stack.Pop()).Int32(),
                firstFrame: ((IConstExpression)stack.Pop()).Int32())
        {
        }

        #endregion Constructors
    }
}