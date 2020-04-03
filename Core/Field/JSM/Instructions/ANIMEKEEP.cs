namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// <para>Play an animation.</para>
    /// <para>Anime, CAnime, RAnime, RCAnime, AnimeKeep, CAnimeKeep, RAnimeKeep, RCAnimeKeep</para>
    /// <para>R - Async (don't wait for the animation)</para>
    /// <para>C - Range (play frame range)</para>
    /// <para>KEEP - Freeze (don't return the base animation, freeze on the last frame)</para>
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/02E_ANIMEKEEP"/>
    public sealed class AnimeKeep : Abstract.Anime
    {
        #region Constructors

        public AnimeKeep(int animationId) : base(animationId)
        {
        }

        public AnimeKeep(int animationId, IStack<IJsmExpression> stack) : base(animationId)
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .Await()
                .Property(nameof(FieldObject.Animation))
                .Method(nameof(FieldObjectAnimation.Play))
                .Argument("animationId", AnimationId)
                .Comment(nameof(AnimeKeep));

        public override IAwaitable TestExecute(IServices services) =>
            // Sync call
            ServiceId.Field[services].Engine.CurrentObject.Animation.Play(AnimationId, freeze: true);

        public override string ToString() => $"{nameof(AnimeKeep)}({nameof(AnimationId)}: {AnimationId})";

        #endregion Methods
    }
}