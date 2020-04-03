namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// <para>Has item (or Get Item Count?)</para>
    /// <para>If the party has the item with the given ID, pushes 1 to temporary variable 0. Otherwise, pushes 0.</para>
    /// <para>It's possible this just returns the number of the item the party has.</para>
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/170_UNKNOWN5"/>
    public sealed class HasItem : JsmInstruction
    {
        #region Fields

        /// <summary>
        /// Item ID
        /// </summary>
        private readonly IJsmExpression _itemID;

        #endregion Fields

        #region Constructors

        public HasItem(IJsmExpression itemID) => _itemID = itemID;

        public HasItem(int parameter, IStack<IJsmExpression> stack)
            : this(
                itemID: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(HasItem)}({nameof(_itemID)}: {_itemID})";

        #endregion Methods
    }
}