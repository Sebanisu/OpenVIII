﻿using System;

namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// <para>Request remote execution</para>
    /// <para>Go to the method Label in the group Argument with a specified Priority.</para>
    /// <para>Requests that a remote entity executes one of its member functions at a specified priority. The request is asynchronous and returns immediately without waiting for the remote execution to start or finish. If the specified priority is already busy executing, the request will fail silently.</para>
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/014_REQ"/>
    public sealed class REQ : Abstract.REQ
    {
        #region Constructors

        public REQ(int objectIndex, int priority, int scriptId) : base(objectIndex, priority, scriptId)
        {
        }

        public REQ(int objectIndex, IStack<IJsmExpression> stack) : base(objectIndex, stack)
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services)
        {
            formatterContext.GetObjectScriptNamesById(ScriptID, out var typeName, out var methodName);

            sw.AppendLine($"{nameof(REQ)}(priority: {Priority}, GetObject<{typeName}>().{methodName}());");
        }

        public override IAwaitable TestExecute(IServices services)
        {
            var engine = ServiceId.Field[services].Engine;

            var targetObject = engine.GetObject(ObjectIndex);
            if (!targetObject.IsActive)
                throw new NotSupportedException($"Unknown expected behavior when trying to call a method of the inactive object (Id: {ObjectIndex}).");

            targetObject.Scripts.TryExecute(ScriptID, Priority);
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(REQ)}({nameof(ObjectIndex)}: {ObjectIndex}, {nameof(Priority)}: {Priority}, {nameof(ScriptID)}: {ScriptID})";

        #endregion Methods
    }
}