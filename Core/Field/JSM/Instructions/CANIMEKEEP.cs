namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// <para>Play an animation.</para>
    /// <para>Anime, CAnime, RAnime, RCAnime, AnimeKeep, CAnimeKeep, RAnimeKeep, RCAnimeKeep</para>
    /// <para>R - Async (don't wait for the animation)</para>
    /// <para>C - Range (play frame range)</para>
    /// <para>KEEP - Freeze (don't return the base animation, freeze on the last frame)</para>
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/030_CANIMEKEEP"/>
    public sealed class CAnimeKeep : Abstract.AnimeLoop
    {
        #region Constructors

        public CAnimeKeep(int animationId, int firstFrame, int lastFrame) : base(animationId, firstFrame, lastFrame)
        {
        }

        public CAnimeKeep(int animationId, IStack<IJsmExpression> stack) : base(animationId, stack)
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .Await()
                .Property(nameof(FieldObject.Animation))
                .Method(nameof(FieldObjectAnimation.Play))
                .Argument("animationId", AnimationId)
                .Argument("firstFrame", FirstFrame)
                .Argument("lastFrame", LastFrame)
                .Comment(nameof(CAnimeKeep));

        public override IAwaitable TestExecute(IServices services) =>
            // Sync call
            ServiceId.Field[services].Engine.CurrentObject.Animation.Play(AnimationId, FirstFrame, LastFrame, freeze: true);

        public override string ToString() => $"{nameof(RCAnimeKeep)}({nameof(AnimationId)}: {AnimationId}, {nameof(LastFrame)}: {LastFrame}, {nameof(FirstFrame)}: {FirstFrame})";

        #endregion Methods
    }
}