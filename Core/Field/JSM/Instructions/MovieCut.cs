namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class MovieCut : JsmInstruction
    {
        #region Constructors

        public MovieCut()
        {
        }

        public MovieCut(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(MovieCut)}()";

        #endregion Methods
    }
}