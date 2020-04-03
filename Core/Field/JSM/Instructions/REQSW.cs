using System;

namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// <para>Request remote execution (asynchronous execution, guaranteed)</para>
    /// <para>Go to the method Label in the group Argument with a specified Priority.</para>
    /// <para>Requests that a remote entity executes one of its member functions at a specified priority. If the specified priority is already busy executing, the request will block until it becomes available and only then return. The remote execution is still carried out asynchronously, with no notification of completion. </para>
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/015_REQSW"/>
    public sealed class REQSW : Abstract.REQ
    {
        #region Constructors

        public REQSW(int objectIndex, int priority, int scriptId) : base(objectIndex, priority, scriptId)
        {
        }

        public REQSW(int objectIndex, IStack<IJsmExpression> stack) : base(objectIndex, stack)
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services)
        {
            formatterContext.GetObjectScriptNamesById(ScriptID, out var typeName, out var methodName);

            sw.AppendLine($"{nameof(REQSW)}(priority: {Priority}, GetObject<{typeName}>().{methodName}());");
        }

        public override IAwaitable TestExecute(IServices services)
        {
            var engine = ServiceId.Field[services].Engine;

            var targetObject = engine.GetObject(ObjectIndex);
            if (!targetObject.IsActive)
                throw new NotSupportedException($"Unknown expected behavior when trying to call a method of the inactive object (Id: {ObjectIndex}).");

            targetObject.Scripts.Execute(ScriptID, Priority);
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(REQSW)}({nameof(ObjectIndex)}: {ObjectIndex}, {nameof(Priority)}: {Priority}, {nameof(ScriptID)}: {ScriptID})";

        #endregion Methods
    }
}