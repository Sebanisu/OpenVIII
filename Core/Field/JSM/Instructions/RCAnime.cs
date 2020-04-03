namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// <para>Play an animation.</para>
    /// <para>Anime, CAnime, RAnime, RCAnime, AnimeKeep, CAnimeKeep, RAnimeKeep, RCAnimeKeep</para>
    /// <para>R - Async (don't wait for the animation)</para>
    /// <para>C - Range (play frame range)</para>
    /// <para>KEEP - Freeze (don't return the base animation, freeze on the last frame)</para>
    /// </summary>
    public sealed class RCAnime : Abstract.AnimeLoop
    {
        #region Constructors

        public RCAnime(int animationId, int firstFrame, int lastFrame) : base(animationId, firstFrame, lastFrame)
        {
        }

        public RCAnime(int animationId, IStack<IJsmExpression> stack) : base(animationId, stack)
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .Property(nameof(FieldObject.Animation))
                .Method(nameof(FieldObjectAnimation.Play))
                .Argument("animationId", AnimationId)
                .Argument("firstFrame", FirstFrame)
                .Argument("lastFrame", LastFrame)
                .Comment(nameof(RCAnime));

        public override IAwaitable TestExecute(IServices services)
        {
            ServiceId.Field[services].Engine.CurrentObject.Animation.Play(AnimationId, FirstFrame, LastFrame, freeze: false);

            // Async call
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(RCAnime)}({nameof(AnimationId)}: {AnimationId}, {nameof(LastFrame)}: {LastFrame}, {nameof(FirstFrame)}: {FirstFrame})";

        #endregion Methods
    }
}