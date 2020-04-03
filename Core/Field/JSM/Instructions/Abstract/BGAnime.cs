namespace OpenVIII.Fields.Scripts.Instructions.Abstract
{
    public abstract class BGAnime : JsmInstruction
    {
        #region Fields

        /// <summary>
        /// First frame of animation
        /// </summary>
        protected readonly IJsmExpression FirstFrame;

        /// <summary>
        /// Last frame of animation
        /// </summary>
        protected readonly IJsmExpression LastFrame;

        #endregion Fields

        #region Constructors

        protected BGAnime(IJsmExpression firstFrame, IJsmExpression lastFrame)
        {
            FirstFrame = firstFrame;
            LastFrame = lastFrame;
        }

        protected BGAnime(int parameter, IStack<IJsmExpression> stack)
            : this(
                lastFrame: stack.Pop(),
                firstFrame: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public abstract override string ToString();

        #endregion Methods
    }
}