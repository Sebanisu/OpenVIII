using System;

namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Request remote execution (synchronous, guaranteed)
    /// Go to the method Label in the group Argument with a specified Priority.
    /// Requests that a remote entity executes one of its member functions at a specified priority. The request will block until remote execution has finished before returning.
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/016_REQEW"/>
    public sealed class REQEW : Abstract.REQ
    {
        #region Constructors

        public REQEW(int objectIndex, int priority, int scriptId) : base(objectIndex, priority, scriptId)
        {
        }

        public REQEW(int objectIndex, IStack<IJsmExpression> stack) : base(objectIndex, stack)
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services)
        {
            formatterContext.GetObjectScriptNamesById(ScriptID, out var typeName, out var methodName);

            sw.AppendLine($"{nameof(REQEW)}(priority: {Priority}, GetObject<{typeName}>().{methodName}());");
        }

        public override IAwaitable TestExecute(IServices services)
        {
            var engine = ServiceId.Field[services].Engine;

            var targetObject = engine.GetObject(ObjectIndex);
            if (!targetObject.IsActive)
                throw new NotSupportedException($"Unknown expected behavior when trying to call a method of the inactive object (Id: {ObjectIndex}).");

            return targetObject.Scripts.Execute(ScriptID, Priority);
        }

        public override string ToString() => $"{nameof(REQEW)}({nameof(ObjectIndex)}: {ObjectIndex}, {nameof(Priority)}: {Priority}, {nameof(ScriptID)}: {ScriptID})";

        #endregion Methods
    }
}