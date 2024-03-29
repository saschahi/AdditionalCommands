﻿using Verse;
using TwitchToolkit;
using System.Linq;
using RimWorld;
using TwitchToolkit.PawnQueue;
using System.Collections.Generic;

namespace AdditionalCommands.Helpers
{
    public class CommandBase : CommandDriver
    {
        //code i yoinked from utils
        private static Pawn FindPawn(string username)
        {
            return Find.ColonistBar.GetColonistsInOrder()
               .Where(p => p.Faction == Faction.OfPlayer)
               .FirstOrDefault(c => ((NameTriple)c.Name)?.Nick.EqualsIgnoreCase(username) ?? false);
        }

        public static Pawn GetOrFindPawn(string username, bool allowKidnapped = false)
        {
            Pawn safe = GetPawn(username);

            if (safe.IsKidnapped() && !allowKidnapped)
            {
                return null;
            }

            if (safe != null)
            {
                return safe;
            }

            Pawn result = FindPawn(username);

            if (result == null)
            {
                return null;
            }

            var component = Current.Game.GetComponent<GameComponentPawns>();

            component.pawnHistory[username] = result;
            component.viewerNameQueue.Remove(username);

            return result;
        }

        public static Pawn GetPawn(string username)
        {
            var component = Current.Game.GetComponent<GameComponentPawns>();
            IEnumerable<Pawn> query = component.pawnHistory.Keys.Where(k => k.EqualsIgnoreCase(username))
               .Select(p => component.pawnHistory[p]);

            return query.FirstOrDefault();
        }
    }
}
