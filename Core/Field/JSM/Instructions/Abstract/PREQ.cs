namespace OpenVIII.Fields.Scripts.Instructions.Abstract
{
    public abstract class PREQ : REQ
    {
        #region Constructors

        protected PREQ(int objectIndex, IStack<IJsmExpression> stack) : base(objectIndex, stack)
        {
        }

        protected PREQ(int objectIndex, int priority, int scriptId) : base(objectIndex, priority, scriptId)
        {
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The ID of the current party member Entity (0, 1 or 2).
        /// </summary>
        protected int PartyID => checked((byte)ObjectIndex);

        #endregion Properties
    }
}