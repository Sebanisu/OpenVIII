using System.Collections.Generic;

namespace OpenVIII
{
    public interface ICluts
    {
        IReadOnlyList<byte> ClutIDs { get; }
        int MaxColors { get; }
        void Save(string path);
        byte MaxClut { get; }
    }
}