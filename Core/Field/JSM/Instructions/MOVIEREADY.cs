using System;

namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class MovieReady : JsmInstruction
    {
        #region Fields

        private readonly IJsmExpression _flag;
        private readonly IJsmExpression _movieId;

        #endregion Fields

        #region Constructors

        public MovieReady(IJsmExpression movieId, IJsmExpression flag)
        {
            _movieId = movieId;
            _flag = flag;
        }

        public MovieReady(int parameter, IStack<IJsmExpression> stack)
            : this(
                flag: stack.Pop(),
                movieId: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services)
        {
            var formatter = sw.Format(formatterContext, services);

            //foreach (String name in MovieName.PossibleNames(_movieId))
            //    formatter.CommentLine(name);

            formatter
                .StaticType(nameof(IMovieService))
                .Method(nameof(IMovieService.PrepareToPlay))
                .Argument("movieId", _movieId)
                .Argument("flag", _flag)
                .Comment(nameof(MovieReady));
        }

        public override IAwaitable TestExecute(IServices services)
        {
            throw new NotImplementedException("was getting InvalidCastExceptions So need correct cast to movieid and flag");
            //ServiceId.Movie[services].PrepareToPlay(_movieId, _flag);
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(MovieReady)}({nameof(_movieId)}: {_movieId}, {nameof(_flag)}: {_flag})";

        #endregion Methods
    }
}