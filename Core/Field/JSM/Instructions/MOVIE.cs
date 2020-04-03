namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class Movie : JsmInstruction
    {
        #region Constructors

        public Movie()
        {
        }

        public Movie(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .StaticType(nameof(IMovieService))
                .Method(nameof(IMovieService.Play))
                .Comment(nameof(Movie));

        public override IAwaitable TestExecute(IServices services)
        {
            ServiceId.Movie[services].Play();
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(Movie)}()";

        #endregion Methods
    }
}