using Verse;
using TorannMagic;
using System.Collections.Generic;
using System.Linq;
using TwitchLib.Client.Models.Interfaces;

namespace AdditionalCommands
{
    public class givedescription : CommandBase
    {
        public override void RunCommand(ITwitchMessage twitchMessage)
        {
            Pawn pawn = GetOrFindPawn(twitchMessage.Username, false);
            if (pawn != null)
            {
                string[] messagesplit = twitchMessage.Message.Split(' ');
                if (messagesplit.Length == 1)
                {
                    return;
                }

                string message = "";

                if (pawn.TryGetComp<CompAbilityUserMagic>().IsMagicUser)
                {
                    message = getmagicskill(pawn, messagesplit[1]);
                }
                else if (pawn.TryGetComp<CompAbilityUserMight>().IsMightUser)
                {
                    message = getmightskill(pawn, messagesplit[1]);
                }

                if (message != "")
                {
                    ToolkitCore.TwitchWrapper.SendChatMessage(twitchMessage.Username + " " + messagesplit[1] + ": " + message);
                }
            }
        }

        public string getmagicskill(Pawn pawn, string skillname)
        {
            CompAbilityUserMagic comp = pawn.GetComp<CompAbilityUserMagic>();
            List<MagicPower> listmagic = comp.MagicData.AllMagicPowers;

            MagicPowerSkill globalregen = comp.MagicData.MagicPowerSkill_global_regen.FirstOrDefault();
            MagicPowerSkill globaleff = comp.MagicData.MagicPowerSkill_global_eff.FirstOrDefault();
            MagicPowerSkill globalspirit = comp.MagicData.MagicPowerSkill_global_spirit.FirstOrDefault();

            if (skillname.ToLower() == "manaregen" && globalregen != null)
            {
                string message = globalregen.desc.Translate();
                return message;
            }

            if (skillname.ToLower() == "manaefficiency" && globaleff != null)
            {
                string message = globaleff.desc.Translate();
                return message;
            }

            if (skillname.ToLower() == "manastorage" && globalspirit != null)
            {
                string message = globalspirit.desc.Translate();
                return message;
            }


            foreach (var item in listmagic)
            {
                if (item.learned)
                {
                    MagicPowerSkill skillPower = comp.MagicData.GetSkill_Power((TMAbilityDef)item.abilityDef);
                    MagicPowerSkill skillEfficiency = comp.MagicData.GetSkill_Efficiency((TMAbilityDef)item.abilityDef);
                    MagicPowerSkill skillVersatility = comp.MagicData.GetSkill_Versatility((TMAbilityDef)item.abilityDef);

                    if (skillname.ToLower() == item.abilityDef.defName.ToLower())
                    {
                        string message = item.abilityDef.description;
                        return message;
                    }

                    if (skillname.ToLower() == item.abilityDef.defName.ToLower() + "_power")
                    {
                        string message = skillPower.desc.Translate();
                        
                        return message;
                    }

                    if (skillname.ToLower() == item.abilityDef.defName.ToLower() + "_efficiency")
                    {
                        string message = skillEfficiency.desc.Translate();
                        return message;
                    }


                    if (skillname.ToLower() == item.abilityDef.defName.ToLower() + "_versatility")
                    {
                        string message = skillVersatility.desc.Translate();
                        return message;
                    }
                }
            }

            return "";
        }

        public string getmightskill(Pawn pawn, string skillname)
        {
            CompAbilityUserMight comp = pawn.GetComp<CompAbilityUserMight>();
            List<MightPower> listmight = comp.MightData.AllMightPowers;

            MightPowerSkill globalendurance = comp.MightData.MightPowerSkill_global_endurance.FirstOrDefault();
            MightPowerSkill globalrefresh = comp.MightData.MightPowerSkill_global_refresh.FirstOrDefault();
            MightPowerSkill globalseff = comp.MightData.MightPowerSkill_global_seff.FirstOrDefault();
            MightPowerSkill globalstrength = comp.MightData.MightPowerSkill_global_strength.FirstOrDefault();

            if (skillname.ToLower() == "mightstorage")
            {
                string message = globalendurance.desc.Translate();
                return message;
            }

            if (skillname.ToLower() == "mightregen")
            {
                string message = globalrefresh.desc.Translate();
                return message;
            }

            if (skillname.ToLower() == "mightefficiency")
            {
                string message = globalseff.desc.Translate();
                return message;
            }

            if (skillname.ToLower() == "mightstrength")
            {
                string message = globalstrength.desc.Translate();
                return message;
            }


            foreach (var item in listmight)
            {
                if (item.learned)
                {
                    MightPowerSkill skillPower = comp.MightData.GetSkill_Power((TMAbilityDef)item.abilityDef);
                    MightPowerSkill skillEfficiency = comp.MightData.GetSkill_Efficiency((TMAbilityDef)item.abilityDef);
                    MightPowerSkill skillVersatility = comp.MightData.GetSkill_Versatility((TMAbilityDef)item.abilityDef);

                    if (skillname.ToLower() == item.abilityDef.defName.ToLower())
                    {
                        string message = item.abilityDef.description;
                        return message;
                    }

                    if (skillname.ToLower() == item.abilityDef.defName.ToLower() + "_power")
                    {
                        string message = skillPower.desc.Translate();
                        return message;
                    }

                    if (skillname.ToLower() == item.abilityDef.defName.ToLower() + "_efficiency")
                    {
                        string message = skillEfficiency.desc.Translate();
                        return message;
                    }


                    if (skillname.ToLower() == item.abilityDef.defName.ToLower() + "_versatility")
                    {
                        string message = skillVersatility.desc.Translate();
                        return message;
                    }
                }
            }

            return "";
        }
    }
}
