namespace OpenVIII.Fields.Scripts.Instructions.Abstract
{
    public abstract class Anime : JsmInstruction
    {
        #region Fields

        /// <summary>
        /// Model Animation ID
        /// </summary>
        protected readonly int AnimationId;

        #endregion Fields

        #region Constructors

        protected Anime(int animationId) => AnimationId = animationId;

        #endregion Constructors

        #region Methods

        public abstract override string ToString();

        #endregion Methods
    }
}