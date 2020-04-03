namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Pauses execution of this script until the current FMV movie is finished playing.
    /// </summary>
    internal sealed class MovieSync : JsmInstruction
    {
        #region Constructors

        public MovieSync()
        {
        }

        public MovieSync(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .StaticType(nameof(IMovieService))
                .Method(nameof(IMovieService.Wait))
                .Comment(nameof(Movie));

        public override IAwaitable TestExecute(IServices services)
        {
            ServiceId.Movie[services].Wait();
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(MovieSync)}()";

        #endregion Methods
    }
}