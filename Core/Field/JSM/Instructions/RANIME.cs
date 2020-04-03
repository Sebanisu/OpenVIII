namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// <para>Play an animation.</para>
    /// <para>Anime, CAnime, RAnime, RCAnime, AnimeKeep, CAnimeKeep, RAnimeKeep, RCAnimeKeep</para>
    /// <para>R - Async (don't wait for the animation)</para>
    /// <para>C - Range (play frame range)</para>
    /// <para>KEEP - Freeze (don't return the base animation, freeze on the last frame)</para>
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/031_RANIME"/>
    public sealed class RAnime : Abstract.Anime
    {
        #region Constructors

        public RAnime(int animationId) : base(animationId)
        {
        }

        public RAnime(int animationId, IStack<IJsmExpression> stack) : base(animationId)
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .Property(nameof(FieldObject.Animation))
                .Method(nameof(FieldObjectAnimation.Play))
                .Argument("animationId", AnimationId)
                .Comment(nameof(RAnime));

        public override IAwaitable TestExecute(IServices services)
        {
            ServiceId.Field[services].Engine.CurrentObject.Animation.Play(AnimationId, freeze: false);

            // Async call
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(RAnime)}({nameof(AnimationId)}: {AnimationId})";

        #endregion Methods
    }
}