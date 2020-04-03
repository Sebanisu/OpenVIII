namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Sets this entity's model to loop the given frames of this animation while it's idle.
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/02C_BASEANIME"/>
    public sealed class BaseAnime : Abstract.AnimeLoop
    {
        #region Constructors

        public BaseAnime(int animationId, int firstFrame, int lastFrame) : base(animationId, firstFrame, lastFrame)
        {
        }

        public BaseAnime(int animationId, IStack<IJsmExpression> stack) : base(animationId, stack)
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .Property(nameof(FieldObject.Animation))
                .Method(nameof(FieldObjectAnimation.ChangeBaseAnimation))
                .Argument("animationId", AnimationId)
                .Argument("firstFrame", FirstFrame)
                .Argument("lastFrame", LastFrame)
                .Comment(nameof(BaseAnime));

        public override IAwaitable TestExecute(IServices services)
        {
            var currentObject = ServiceId.Field[services].Engine.CurrentObject;
            currentObject.Animation.ChangeBaseAnimation(AnimationId, FirstFrame, LastFrame);
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(BaseAnime)}({nameof(AnimationId)}: {AnimationId}, {nameof(LastFrame)}: {LastFrame}, {nameof(FirstFrame)}: {FirstFrame})";

        #endregion Methods
    }
}