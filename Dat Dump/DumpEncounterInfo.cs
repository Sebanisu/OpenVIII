﻿using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using OpenVIII.Battle;
using OpenVIII.Fields;
using OpenVIII.Fields.Scripts.Instructions;
using OpenVIII.World;
using Sections = OpenVIII.Fields.Sections;

namespace OpenVIII.Dat_Dump
{
    internal static class DumpEncounterInfo
    {
        #region Fields

        public static ConcurrentDictionary<int, Archive> FieldData;
        private static HashSet<KeyValuePair<string, ushort>> _fieldsWithBattleScripts;
        private static HashSet<ushort> _worldEncounters;

        #endregion Fields

        #region Properties

        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        public static string[] BattleStageNames { get; } = {
            "Balamb Garden Quad",
            "Dollet Bridge",
            "Dollet Trasmission Tower path",
            "Dollet Transmission Tower (Top)",
            "Dollet Transmission Tower (Elevator)",
            "Dollet Transmission Tower (Elevator 2 ?)",
            "Dollet City ? (Spice Spice Shop)",
            "Balamb Garden entrance gate",
            "Balamb Garden 1st Floor Hall",
            "Balamb Garden 2nd Floor Corridor",
            "Balamb Garden(Flyng Form) Quad",
            "Balamb Garden Outer Corridor",
            "Balamb Garden Training Center (elevator zone)",
            "Balamb Garden Norg's Floor",
            "Balamb Garden Underground Levels (Tube)",
            "Balamb Garden Underground levels (falling ladder zone?)",
            "Balamb Garden Underground levels (OilBoil Zone?)",
            "Timber Pub Area",
            "Timber Maniacs square",
            "Train (Deling Presidential Vagon)",
            "Deling City Sewers",
            "Deling City (Caraway Residence secret exit path?)",
            "Balamb Garden Class Room",
            "Galbadia Garden Corridor ?",
            "Galbadia Garden Corridor 2 ?",
            "Galbadia Missile Base",
            "Deep Sea Research Center (Entrance?)",
            "Balamb Town (Balamb Hotel road)",
            "Balamb Town (Balamb Hotel Hall)",
            "? Diabolous Lair?",
            "Fire Cavern (path)",
            "Fire Cavern (Ifrit Lair)",
            "Galbadia Garden Hall",
            "Galbadia Garden Auditorium (Edea's battle?)",
            "Galbadia Garden Auditorium 2? (Edea's battle?)",
            "Galbadia Garden Corridor",
            "Galbadia Garden (Ice Hockey Field)",
            "?? Some broken wall place..Ultimecia Castle?",
            "StarField?",
            "Desert Prison? (elevator?)",
            "Desert Prison? (Floor?)",
            "Esthar City (road)",
            "Desert Prison? (Top?)",
            "Esthar City (road2 ?)",
            "Missile Base? Hangar?",
            "Missile Base? Hangar2?",
            "Missile Base? Control room?",
            "Winhill Village main square",
            "Tomb of the Unknown King (Corridor)?",
            "Esthar City (road 3 ?)",
            "Tomb of the Unknown King (Boss Fight room)?",
            "Fisherman Horizon (Road)",
            "Fisherman Horizon (Train Station Square)",
            "Desert Prison? (Floor?)",
            "Salt Lake?",
            "Ultima Weapon Stage",
            "Salt Lake 2?",
            "Esthar Road",
            "Ultimecia's Castle (bridge)",
            "Esthar (square?)",
            "Esthar (?)",
            "Esthar (cave?)",
            "Esthar (cave2?)",
            "Esthar (Centra excavation site)",
            "Esthar (Centra excavation site)",
            "Esthar (Centra excavation site)",
            "Esthar (Centra excavation site)",
            "Lunatic Pandora?",
            "Lunatic Pandora",
            "Lunatic Pandora(Adel?)",
            "(Centra excavation site)",
            "(Centra excavation site)",
            "(Centra excavation site)",
            "(Centra excavation site)",
            "? ?",
            "(Centra excavation site)",
            "Centra Ruins (Lower Level)",
            "Centra Ruins (Tower Level)",
            "Centra Ruins (Tower Level)",
            "Centra Ruins (Odin Room)",
            "Centra excavation site (Entrance)",
            "Trabia Canyon",
            "Ragnarok?",
            "Ragnarok?",
            "? Diabolous Lair?",
            "Deep Sea Research Center (Entrance)",
            "Deep Sea Research Center",
            "Deep Sea Research Center",
            "Deep Sea Research Center",
            "Deep Sea Research Center",
            "Deep Sea Research Center",
            "Deep Sea Research Center",
            "? ?",
            "? Esthar shops?",
            "Tear's Point",
            "Esthar",
            "Ultimecia's Castle",
            "Ultimecia's Castle",
            "Ultimecia's Castle",
            "Ultimecia's Castle",
            "Deling City (Edea's Room)",
            "Balamb Plains?",
            "Desert Canyon?",
            "Desert?",
            "Snow-Covered Plains? (Trabia Region?)",
            "Wood",
            "Snow-Covered Wood",
            "Balamb Isle? (Beach zone?)",
            "?Snow Beach?",
            "Esthar City",
            "Esthar City",
            "Generic Landscape? Dirt Ground",
            "Generic Landscape? Grass Ground",
            "Generic Landscape? Dirt Ground",
            "Generic Landscape? Snow Covered Mountains",
            "Esthar City",
            "Esthar City",
            "Generic Landscape?",
            "Esthar City",
            "Esthar City",
            "Ultimecia's Castle",
            "Ultimecia's Castle",
            "Ultimecia's Castle",
            "Ultimecia's Castle",
            "Ultimecia's Castle",
            "Ultimecia's Castle",
            "Ultimecia's Castle",
            "Ultimecia's Castle",
            "Generic Landscape?",
            "Generic Landscape?",
            "Generic Landscape?",
            "Generic Landscape?",
            "Generic Landscape?",
            "Generic Landscape?",
            "Esthar City",
            "Generic Landscape?",
            "Generic Landscape? (Beach at night?)",
            "Commencement Room",
            "Ultimecia's Castle",
            "Ultimecia's Castle (Tiamat)",
            "Ultimecia's Castle",
            "Ultimecia's Castle",
            "Ultimecia's Castle",
            "Esthar City",
            "Lunatic Pandora Lab",
            "Lunatic Pandora Lab",
            "Edea's Parade Vehicle",
            "Tomb of the Unknown King (Boss Fight room)?",
            "Desert Prison?",
            "Galbadian something?",
            "Generic Landscape?",
            "Generic Landscape?",
            "Balamb Garden (External Corridor?)",
            "Balamb Garden (External Corridor?)",
            "Balamb Garden (External Corridor?)",
            "Balamb Garden (External Corridor?)",
            "Balamb Garden (External Corridor?)",
            "Generic Landscape?",
            "Generic Landscape?",
            "Generic Landscape?",
            "Test Environment? (UV tile texture)",
            "Generic Landscape?",
            "Generic Landscape?" };

        public static HashSet<ushort> WorldEncountersLunar { get; private set; }
        private static string Ls => CultureInfo.CurrentCulture.TextInfo.ListSeparator;

        #endregion Properties

        #region Methods

        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        [SuppressMessage("ReSharper", "AccessToModifiedClosure")]
        internal static async Task Process()
        {
            await Task.WhenAll(Task.Run(() => LoadWorld()), LoadFields(),
                    DumpMonsterAndCharacterDat.LoadMonsters() //load all the monsters.
            );
            
            using (var csvFile = new StreamWriter(new FileStream("BattleEncounters.csv", FileMode.Create, FileAccess.Write, FileShare.ReadWrite), System.Text.Encoding.UTF8))
            {
                var header =
                $"{nameof(Encounter.ID)}{Ls}" +
                $"{nameof(Encounter.Filename)}{Ls}" +
                $"{nameof(BattleStageNames)}{Ls}" +
                $"{nameof(Encounter.BEnemies)}{Ls}" +
                $"{nameof(Fields)}{Ls}";
                csvFile.WriteLine(header);
                foreach (var e in Memory.Encounters)
                {
                    //wip
                    var data =
                        $"{e.ID}{Ls}" +
                        $"{e.Filename}{Ls}" +
                        $"\"{BattleStageNames[e.Scenario]}\"{Ls}";
                    var enemies = "\"";
                    var unique = e.UniqueMonstersList;
                    var counts = e.UniqueMonstersList.Select(x => new KeyValuePair<byte, int>(x, e.EnabledMonsters.Count(y => y.Value == x)));
                    unique.ForEach(x =>
                    {
                        var name = "<unknown>";
                        if (DumpMonsterAndCharacterDat.MonsterData.TryGetValue(x, out var battleDat) && battleDat != null)
                        {
                            name = battleDat.Information.Name.Value_str.Trim();
                            name += $" ({battleDat.FileName})";
                        }

                        Debug.Assert(enemies != null, nameof(enemies) + " != null");
                        enemies += $"{counts.First(y => y.Key == x).Value} × {name}{Ls} ";
                    });
                    enemies = enemies.TrimEnd(Ls[0], ' ') + "\"";
                    data += $"{enemies}{Ls}";
                    //check encounters in fields and confirm encounter rate is above 0.
                    if (FieldData != null)
                    {
                        var fieldMatches = FieldData.Where(x => x.Value.MrtRat != null && (x.Value.MrtRat.Any(y => y.Key == e.ID && y.Value > 0))).Select(x => x.Value.FileName);
                        if (_fieldsWithBattleScripts != null)
                        {
                            var second = _fieldsWithBattleScripts.Where(x => x.Value == e.ID).Select(x => x.Key);
                            if (second.Any())
                            {
                                fieldMatches = fieldMatches.Any() ? fieldMatches.Concat(second).Distinct() : second;
                            }
                        }

                        if (fieldMatches.Any())
                            data += $"\"{string.Join($"{Ls} ", fieldMatches).TrimEnd(Ls[0], ' ')}\"{Ls}";
                        else if (_worldEncounters.Any(x => x == e.ID))
                        {
                            data += $"\"World Map\"{Ls}";
                        }
                        else if (WorldEncountersLunar.Any(x => x == e.ID))
                        {
                            data += $"\"World Map - Lunar Cry\"{Ls}";
                        }
                        else
                            data += Ls;
                    }

                    csvFile.WriteLine(data);
                }
            }
        }

        private static async Task LoadFields()
        {
            if (FieldData == null)
            {
                FieldData = new ConcurrentDictionary<int, Archive>();

                var tasks = new Task[Memory.FieldHolder.Fields.Length];
                void process(ushort i)
                {
                    if (FieldData.ContainsKey(i)) return;
                    var archive = Archive.Load(i, Sections.MRT | Sections.RAT | Sections.JSM | Sections.SYM);

                    if (archive != null)
                        FieldData.TryAdd(i, archive);
                }
                //foreach (var i1 in Enumerable.Range(0, Memory.FieldHolder.Fields.Length))
                //{
                //    var j = (ushort)i1;
                //    await Task.Run(() => process(j));
                //}
                foreach (var i1 in Enumerable.Range(0, Memory.FieldHolder.Fields.Length))
                {
                    var j = (ushort)i1;
                    tasks[j] = (Task.Run(() => process(j)));
                }
                await Task.WhenAll(tasks);
            }

            _fieldsWithBattleScripts =
            (from fieldArchive in FieldData
             where fieldArchive.Value.JSMObjects != null && fieldArchive.Value.JSMObjects.Count > 0
             from jsmObject in fieldArchive.Value.JSMObjects
             from script in jsmObject.Scripts
             from instruction in script.Segment.Flatten()
             where instruction is Fields.Scripts.Instructions.Battle
             let battle = ((Fields.Scripts.Instructions.Battle)instruction)
             select (new KeyValuePair<string, ushort>(fieldArchive.Value.FileName, battle.Encounter))).ToHashSet();

            var output = (from fieldArchive in FieldData
                where fieldArchive.Value.JSMObjects != null && fieldArchive.Value.JSMObjects.Count > 0
                from jsmObject in fieldArchive.Value.JSMObjects
                from script in jsmObject.Scripts
                from jsmInstruction in script.Segment.Flatten()
                where jsmInstruction is SetCamera
                let instruction = jsmInstruction as SetCamera
                select new {fieldArchive.Value.FileName, instruction.Arg}).ToHashSet();

            var outputD = (from fieldArchive in FieldData
                where fieldArchive.Value.JSMObjects != null && fieldArchive.Value.JSMObjects.Count > 0
                from jsmObject in fieldArchive.Value.JSMObjects
                from script in jsmObject.Scripts
                from jsmInstruction in script.Segment.Flatten()
                where jsmInstruction is SetDCamera
                let instruction = jsmInstruction as SetDCamera
                select new { fieldArchive.Value.FileName, instruction.Arg }).ToHashSet();


            var outputDress = (from fieldArchive in FieldData
                where fieldArchive.Value.JSMObjects != null && fieldArchive.Value.JSMObjects.Count > 0
                from jsmObject in fieldArchive.Value.JSMObjects
                from script in jsmObject.Scripts
                from jsmInstruction in script.Segment.Flatten()
                where jsmInstruction is SetDress
                let instruction = jsmInstruction as SetDress
                select new { fieldArchive.Value.FileName, instruction.Character, instruction.Costume }).ToHashSet();

            using (var bw = new StreamWriter(new FileStream("SetCamera.csv", FileMode.Create, FileAccess.Write,
                FileShare.ReadWrite),Encoding.UTF8))
            {
                bw.WriteLine("filename,arg");
                foreach(var line in output)
                    bw.WriteLine($"{line.FileName},{line.Arg}");
            }
            using (var bw = new StreamWriter(new FileStream("SetDCamera.csv", FileMode.Create, FileAccess.Write,
                FileShare.ReadWrite), Encoding.UTF8))
            {
                bw.WriteLine("filename,arg");
                foreach (var line in outputD)
                    bw.WriteLine($"{line.FileName},{line.Arg}");
            }

            using (var bw = new StreamWriter(new FileStream("SetDress.csv", FileMode.Create, FileAccess.Write,
                FileShare.ReadWrite), Encoding.UTF8))
            {
                bw.WriteLine("filename,character,costume");
                foreach (var line in outputDress)
                    bw.WriteLine($"{line.FileName},{line.Character},{line.Costume}");
            }
        }

        private static void LoadWorld()
        {
            var aw = ArchiveWorker.Load(Memory.Archives.A_WORLD);

            // ReSharper disable once StringLiteralTypo
            var wmPath = $"wmset{Extended.GetLanguageShort(true)}.obj";

            using (var worldMapSettings = new Wmset(aw.GetBinaryFile(wmPath)))
            {
                _worldEncounters = worldMapSettings.Encounters.SelectMany(x => x.Select(y => y)).Distinct().ToHashSet();
                WorldEncountersLunar = worldMapSettings.EncountersLunar.SelectMany(x => x.Select(y => y)).Distinct().ToHashSet();
            }
            //rail = new rail(aw.GetBinaryFile(railFile));
        }

        #endregion Methods
    }
}