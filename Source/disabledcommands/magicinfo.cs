using Verse;
using TwitchLib.Client.Models.Interfaces;
using TorannMagic;
using System.Collections.Generic;
using System.Linq;
using AdditionalCommands.Helpers;

namespace AdditionalCommands.DisabledCommands
{
    public class magicinfo : CommandBase
    {
        public override void RunCommand(ITwitchMessage twitchMessage)
        {
            Pawn pawn = GetOrFindPawn(twitchMessage.Username, false);
            
            if(pawn != null)
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
                    message = getmightskill(pawn,messagesplit[1]);
                }

                if (message != "")
                {
                    ToolkitCore.TwitchWrapper.SendChatMessage(twitchMessage.Username + " " + message);
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

            if(skillname.ToLower() == "manaregen" && globalregen != null)
            {
                string message = "Manaregen Level: " + globalregen.level + " Max Level: " + globalregen.levelMax + " Cost to Level: " + globalregen.costToLevel;
                return message;
            }

            if(skillname.ToLower() == "manaefficiency" && globaleff != null)
            {
                string message = "Manaefficiency Level: " + globaleff.level + " Max Level: " + globaleff.levelMax + " Cost to Level: " + globaleff.costToLevel;
                return message;
            }

            if(skillname.ToLower() == "manastorage" && globalspirit != null)
            {
                string message = "Manastorage Level: " + globalspirit.level + " Max Level: " + globalspirit.levelMax + " Cost to Level: " + globalspirit.costToLevel;
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
                        string message = item.abilityDef.defName + " Level: " + item.level + " Max Level: " + item.maxLevel + " Cost to Level: " + item.costToLevel;
                        return message;
                    }

                    if (skillname.ToLower() == item.abilityDef.defName.ToLower() + "_power")
                    {
                        string message = item.abilityDef.defName + "_power" + " Level: " + skillPower.level + " Max Level: " + skillPower.levelMax + " Cost to Level: " + skillPower.costToLevel;
                        return message;
                    }

                    if (skillname.ToLower() == item.abilityDef.defName.ToLower() + "_efficiency")
                    {
                        string message = item.abilityDef.defName + "_efficiency" + " Level: " + skillEfficiency.level + " Max Level: " + skillEfficiency.levelMax + " Cost to Level: " + skillEfficiency.costToLevel;
                        return message;
                    }


                    if (skillname.ToLower() == item.abilityDef.defName.ToLower() + "_versatility")
                    {
                        string message = item.abilityDef.defName + "_versatility" + " Level: " + skillVersatility.level + " Max Level: " + skillVersatility.levelMax + " Cost to Level: " + skillVersatility.costToLevel;
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
                string message = "Mightstorage Level: " + globalendurance.level + " Max Level: " + globalendurance.levelMax + " Cost to Level: " + globalendurance.costToLevel;
                return message;
            }

            if (skillname.ToLower() == "mightregen")
            {
                string message = "Mighregen Level: " + globalrefresh.level + " Max Level: " + globalrefresh.levelMax + " Cost to Level: " + globalrefresh.costToLevel;
                return message;
            }

            if (skillname.ToLower() == "mightefficiency")
            {
                string message = "Mightefficiency Level: " + globalseff.level + " Max Level: " + globalseff.levelMax + " Cost to Level: " + globalseff.costToLevel;
                return message;
            }

            if (skillname.ToLower() == "mightstrength")
            {
                string message = "Mightstrength Level: " + globalstrength.level + " Max Level: " + globalstrength.levelMax + " Cost to Level: " + globalstrength.costToLevel;
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
                        string message = item.abilityDef.defName + " Level: " + item.level + " Max Level: " + item.maxLevel + " Cost to Level: " + item.costToLevel;
                        return message;
                    }

                    if (skillname.ToLower() == item.abilityDef.defName.ToLower() + "_power")
                    {
                        string message = item.abilityDef.defName + "_power" + " Level: " + skillPower.level + " Max Level: " + skillPower.levelMax + " Cost to Level: " + skillPower.costToLevel;
                        return message;
                    }

                    if (skillname.ToLower() == item.abilityDef.defName.ToLower() + "_efficiency")
                    {
                        string message = item.abilityDef.defName + "_efficiency" + " Level: " + skillEfficiency.level + " Max Level: " + skillEfficiency.levelMax + " Cost to Level: " + skillEfficiency.costToLevel;
                        return message;
                    }


                    if (skillname.ToLower() == item.abilityDef.defName.ToLower() + "_versatility")
                    {
                        string message = item.abilityDef.defName + "_versatility" + " Level: " + skillVersatility.level + " Max Level: " + skillVersatility.levelMax + " Cost to Level: " + skillVersatility.costToLevel;
                        return message;
                    }
                }
            }

            return "";
        }
    }
}
